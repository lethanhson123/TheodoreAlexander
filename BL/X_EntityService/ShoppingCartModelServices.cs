using BL.CustomExceptions;
using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BL.EntityService
{
    public class ShoppingCartModelServices : ITAWModelService<ShoppingCart,Guid>//, IShoppingCartModelServices
    {
        public ShoppingCartModelServices(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public IQueryable<ShoppingCart> GetShoppingCartByUserId(Guid UserId)
        {
            try
            {
                return _ctx.ShoppingCarts.AsNoTracking().Where(o => o.UserID == UserId && !o.DateOrderCreated.HasValue);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public IQueryable<ShoppingCart_Item> GetShoppingCartItemByUserId(Guid UserId)
        {
            return _ctx.ShoppingCart_Item.AsNoTracking().Where(o => o.ShoppingCart.UserID == UserId && !o.ShoppingCart.DateOrderCreated.HasValue);
        }

        public int AddShopingCart(ShoppingCart shoppingCart)
        {
            try
            {
                _ctx.ShoppingCarts.Add(shoppingCart);
                return _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddShoppingCartItem(ShoppingCart_Item shoppingCartItem)
        {
            try
            {
                _ctx.ShoppingCart_Item.Add(shoppingCartItem);
                return _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EditShoppingCartItem(ShoppingCart_Item shoppingCartItem)
        {
            try
            {
                _ctx.Entry(shoppingCartItem).State = EntityState.Modified;
                return _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<ShoppingCart_Item> GetShoppingCartItems()
        {
            return _ctx.ShoppingCart_Item;
        }

        public async Task RemoveShoppingCartItem(ShoppingCart_Item shoppingCartItem)
        {
            try
            {
                _ctx.ShoppingCart_Item.Remove(shoppingCartItem);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveShoppingCartItemShippingStatus(ShoppingCart_Item_ShippingStatus shoppingCartItemShippingStatus)
        {
            try
            {
                _ctx.ShoppingCart_Item_ShippingStatus.Remove(shoppingCartItemShippingStatus);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<ShoppingCart_Item_ShippingStatus> GetShoppingCartItemShippingStatuses()
        {
            return _ctx.ShoppingCart_Item_ShippingStatus;
        }

        public async Task RemoveRangeShoppingCartItemShippingStatus(List<ShoppingCart_Item_ShippingStatus> lstShoppingCartItemShippingStatus)
        {
            try
            {
                _ctx.ShoppingCart_Item_ShippingStatus.RemoveRange(lstShoppingCartItemShippingStatus);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<BL.DTO.Inventories> GetInventories(Guid UserId)
        {
            try
            {
                var lastShippingStatus = GetLastShippingStatus().First();

                // This table provides the inventories for the items in shopping cart.
                // Add a record for the last shipping status (12-24 weeks) if not existent, and add 1000000000 to its quantity so it is always available and still 
                // keep its original value
                var inventories = (from s in _ctx.Item_ShippingStatus
                                   from i in _ctx.ShoppingCart_Item.Where(o => o.ShoppingCart.UserID == UserId && !o.ShoppingCart.DateOrderCreated.HasValue)
                                   where s.Item_ID == i.Item_ID
                                   select new Inventories
                                   {
                                       Item_ID = i.Item_ID,
                                       ShippingStatus_ID = s.ShippingStatus_ID,
                                       DeliveryTime = s.ShippingStatu.DeliveryTime,
                                       MinimumDelay = s.ShippingStatu.MinimumDelay,
                                       Quantity = s.Quantity
                                   }).Union(
                                  from i in _ctx.ShoppingCart_Item.Where(o => o.ShoppingCart.UserID == UserId && !o.ShoppingCart.DateOrderCreated.HasValue)
                                  select new Inventories
                                  {
                                      Item_ID = i.Item_ID,
                                      ShippingStatus_ID = lastShippingStatus.ID,
                                      DeliveryTime = lastShippingStatus.DeliveryTime,
                                      MinimumDelay = lastShippingStatus.MinimumDelay,
                                      Quantity = 1000000000
                                  })
                                  .GroupBy(o => new { o.Item_ID, o.ShippingStatus_ID, o.DeliveryTime, o.MinimumDelay })
                                  .Select(o => new BL.DTO.Inventories {
                                      Item_ID = o.Key.Item_ID,
                                      ShippingStatus_ID = o.Key.ShippingStatus_ID,
                                      DeliveryTime = o.Key.DeliveryTime,
                                      MinimumDelay = o.Key.MinimumDelay, 
                                      Quantity = o.Sum(p => p.Quantity) 
                                  })
                                  .OrderBy(o => o.MinimumDelay);
                return inventories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveShopingCartItems(List<ShoppingCart_Item> shoppingCart_Items)
        {
            try
            {
                _ctx.ShoppingCart_Item.RemoveRange(shoppingCart_Items);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertShoppingCartItemShippingStatuses(List<ShoppingCart_Item_ShippingStatus> item_ShippingStatuses)
        {
            try
            {
                _ctx.ShoppingCart_Item_ShippingStatus.AddRange(item_ShippingStatuses);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Inventories> GetCurrentInventories(Guid shoppingCartId)
        {
            var inventories = from s in _ctx.Item_ShippingStatus
                               join i in _ctx.ShoppingCart_Item.Where(o => o.ShoppingCart_ID == shoppingCartId)
                               on s.Item_ID equals i.Item_ID
                               select new Inventories
                               {
                                   Item_ID = i.Item_ID,
                                   ShippingStatus_ID = s.ShippingStatus_ID,
                                   DeliveryTime = s.ShippingStatu.DeliveryTime,
                                   MinimumDelay = s.ShippingStatu.MinimumDelay,
                                   Quantity = s.Quantity
                               };
            return inventories;
        }

        public IQueryable<ShippingStatu> GetLastShippingStatus()
        {
            return _ctx.ShippingStatus.OrderByDescending(o => o.MinimumDelay);
        }

        public async Task ReduceInventory(ShoppingCart shoppingCart)
        {
            var updatedShoppingCart =_ctx.ShoppingCarts.Where(o => o.UserID == shoppingCart.UserID & !o.DateOrderCreated.HasValue).FirstOrDefault();
            updatedShoppingCart.DateOrderCreated = DateTime.UtcNow;
            List<Item_ShippingStatus> lstItemToDelete = new List<Item_ShippingStatus>();
            foreach (ShoppingCart_Item item in _ctx.ShoppingCart_Item.Where(o => o.ShoppingCart_ID == shoppingCart.ID))
            {
                foreach (ShoppingCart_Item_ShippingStatus siss in _ctx.ShoppingCart_Item_ShippingStatus.Where(o => o.ShoppingCart_ID == item.ShoppingCart_ID && o.Item_ID == item.Item_ID))
                {
                    Item_ShippingStatus iss = _ctx.Item_ShippingStatus.FirstOrDefault(o => o.Item_ID == item.Item_ID && o.ShippingStatus_ID == siss.ShippingStatus_ID);
                    if (iss != null)
                    {
                        int newQuantity = Math.Min(iss.Quantity - siss.Quantity, 0);
                        if (newQuantity > 0)
                            iss.Quantity = newQuantity;
                        else
                            lstItemToDelete.Add(iss);
                    }
                }
            }
            _ctx.Item_ShippingStatus.RemoveRange(lstItemToDelete);
            await _ctx.SaveChangesAsync();
        }

        public IQueryable<ShippingStatu> GetShippingDates(Guid shoppingCartId)
        {
            try
            {
                return _ctx.ShoppingCart_Item_ShippingStatus.Where(o => o.ShoppingCart_ID == shoppingCartId).Select(o => o.ShippingStatu).Distinct();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public override IQueryable<ShoppingCart> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<ShoppingCart> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(ShoppingCart t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(ShoppingCart t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
