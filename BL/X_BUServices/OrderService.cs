using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using DAL.ViewModels;
using BL.Extensions;
using BL.EntityService;
using System.Configuration;
using System.Transactions;
using System.Text;
using BL.DTO;
using BL.BusinessService;
//using System.Data.Linq.SqlClient;

namespace BL.BUServices
{
    public interface IOrderService : IDisposable
    {
        DTO.ShoppingCartViewModel GetShoppingCartByUserId(JWTIdentityViewModel jwtModel);
        DTO.ShoppingCartViewModel UpdateShoppingCart(DTO.AddToCardRequestObj addToCardRequestObj, JWTIdentityViewModel jwtModel, out string errorMessage);
        Task<DTO.ShoppingCartViewModel> RemoveItemInShoppingCart(Guid itemId, JWTIdentityViewModel jwtModel);
        Task<BL.DTO.AvailabilityChangedShoppingCart> CheckOutShoppingCart(JWTIdentityViewModel jwtModel);
        OrderDto GetInfosToCreateNewOrder(JWTIdentityViewModel jwtModel);
        Task<OrderDto> SubmitOrder(OrderDto orderUpdateModel, JWTIdentityViewModel jwtModel);
    }

    public class OrderService : IOrderService
    {
        private readonly ItemBusinessService _itemService;
        private readonly BL.BusinessService.OrderBusinessService _orderService;
        private bool disposed = false;
        public OrderService(ItemBusinessService itemService
            , BL.BusinessService.OrderBusinessService orderService)
        {
            _itemService = itemService;
            _orderService = orderService;
        }

        #region Implement interface
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _itemService.Dispose();
                _orderService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DTO.ShoppingCartViewModel GetShoppingCartByUserId(JWTIdentityViewModel jwtModel)
        {
            List<ShoppingCart_Item> cartItems = _orderService.GetShoppingCartByUserId(jwtModel.UserId.Value);
            return ProjectToShoppingCartViewModel(cartItems, jwtModel);
        }

        public async Task<DTO.ShoppingCartViewModel> RemoveItemInShoppingCart(Guid itemId, JWTIdentityViewModel jwtModel)
        {
            List<ShoppingCart_Item> cartItems = await _orderService.RemoveItemInShoppingCart(itemId, jwtModel);
            return ProjectToShoppingCartViewModel(cartItems, jwtModel);
        }

        public DTO.ShoppingCartViewModel UpdateShoppingCart(DTO.AddToCardRequestObj addToCardRequestObj, JWTIdentityViewModel jwtModel, out string errorMessage)
        {
            List<ShoppingCart_Item> cartItems =  _orderService.UpdateShoppingCart(addToCardRequestObj, jwtModel, out errorMessage);
            if (cartItems != null)
            {
                return ProjectToShoppingCartViewModel(cartItems, jwtModel);
            }
            else {
                return null;
            }
        }

        public async Task<BL.DTO.AvailabilityChangedShoppingCart> CheckOutShoppingCart(JWTIdentityViewModel jwtModel) {
            try
            {
                if (jwtModel.UserId != Guid.Empty)
                {
                    List<ShoppingCart_Item> cartItems = _orderService.GetShoppingCartByUserId(jwtModel.UserId.Value);
                    BL.DTO.AvailabilityChangedShoppingCart cartViewModel = ProjectToShoppingCartViewModel(cartItems, jwtModel);
                    await _orderService.CheckAvailabilityChangedItem(jwtModel, cartViewModel.LstItem);

                    var anyChanged = cartViewModel.LstItem.FirstOrDefault(o => o.IsAvailabiliyChanged);
                    if (anyChanged != null)
                    {
                        cartViewModel.IsAvailabiliyChanged = true;
                    }
                    if (!cartViewModel.IsAvailabiliyChanged) //If have no availability changed item => Reserve items in shopping cart
                    {
                        try
                        {
                            var Reserve = await _orderService.ReserveItemsInShoppingCart((Guid)jwtModel.UserId);
                            if (!Reserve)
                            {
                                //return new GenerateResponeHelper<string>("Check out shopping cart failed, Can not Reserve", false, Request, HttpStatusCode.BadRequest);
                            }
                        }
                        catch
                        {
                            //return new GenerateResponeHelper<string>("Check out shopping cart failed, Can not Reserve", false, Request, HttpStatusCode.BadRequest);
                        }
                    }

                    return cartViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public OrderDto GetInfosToCreateNewOrder(JWTIdentityViewModel jwtModel)
        {
            if (jwtModel.UserId != Guid.Empty)
            {
                var shoppingCartInfos = GetShoppingCartByUserId(jwtModel);
                OrderDto result = new OrderDto
                {
                    ShoppingCartInfos = shoppingCartInfos
                };
                return result;
            }
            else {
                return null;
            }
        }

        public async Task<OrderDto> SubmitOrder(OrderDto orderUpdateModel, JWTIdentityViewModel jwtModel)
        {
            try
            {
                if (jwtModel.UserId != Guid.Empty)
                {
                    var checkOrder = await _orderService.CheckingShoppingCartOrder(orderUpdateModel, (Guid)jwtModel.UserId);
                    if (String.IsNullOrEmpty(checkOrder))
                    {
                        var result = await _orderService.ProcessOrder(orderUpdateModel, (Guid)jwtModel.UserId);
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) 
            {
                string mes = ex.Message;
                throw ex;
            }
        }
        #endregion

        #region Private method
        private DTO.AvailabilityChangedShoppingCart ProjectToShoppingCartViewModel(List<ShoppingCart_Item> cartItems, JWTIdentityViewModel jwtModel) {
            var itemsInCart = cartItems.Select(i => new ShoppingCartItemViewMoel(i.Item)
            {
                Quantity = i.Quantity,
                Volume = i.Item.CBM ?? 0,
            }).ToList();

            foreach (var item in itemsInCart)
            {
                item.IsAvailable = _itemService.IsAvailableItem(jwtModel, item.SKU);
                if (item.IsAvailable)
                {
                    _itemService.SetupPrices(item, jwtModel);
                    if (jwtModel.UserType == LocalUserType.Dealer)
                    {
                        item.ItemTotal = item.WholesalePriceList.DealerPrice.Price * item.Quantity;
                    }
                    if (jwtModel.UserType == LocalUserType.Designer)
                    {
                        item.ItemTotal = item.WholesalePriceList.DesignerPrice.Price * item.Quantity;
                    }
                }
            }

            DTO.AvailabilityChangedShoppingCart shoppingCartViewModel = new DTO.AvailabilityChangedShoppingCart
            {
                Count = itemsInCart.Sum(o => o.Quantity).ToString(),
                Volume = itemsInCart.Sum(o => o.Volume * o.Quantity).ToString("N2"),
                Total = itemsInCart.Sum(o => o.ItemTotal).ToString(),
                LstItem = itemsInCart.ToList()
            };
            return shoppingCartViewModel;
        }
        #endregion

        #region Public method
        #endregion
    }
}
