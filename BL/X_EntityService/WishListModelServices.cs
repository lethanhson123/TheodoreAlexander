using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DAL;
using DAL.ViewModels;
using BL.CustomExceptions;

namespace BL.EntityService
{
    public class WishListModelServices : ITAWModelService<Lookbook, Guid>//, IWishListModelServices
    {
        public WishListModelServices(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public async Task<LookbookShared> CreateLookBookShared(Guid fromUserID, string fromName, string fromEmail, Guid lookBookID, string toName, string toEmail, bool includeNotes, string message)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    LookbookShared lookbookShared = new LookbookShared()
                    {
                        ID = Guid.NewGuid(),
                        FromUser_ID = fromUserID,
                        FromName = fromName,
                        FromEmail = fromEmail,
                        Lookbook_ID = lookBookID,
                        ToName = toName,
                        ToEmail = toEmail,
                        Message = message,
                        IncludeNotes = includeNotes,
                        DateCreated = DateTime.UtcNow
                    };
                    _ctx.LookbookShareds.Add(lookbookShared);
                    if (await _ctx.SaveChangesAsync() > 0)
                    {
                        transaction.Complete();
                        return lookbookShared;
                    }
                    else {
                        transaction.Dispose();
                        return null;
                    }
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<bool> EditWishlistItemNote(Guid wishlistId, Guid wishlistItemId, string note)
        {
            bool returnValue = false;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    Lookbook_Item item = await _ctx.Lookbook_Item.FirstOrDefaultAsync(i => i.Item_ID == wishlistItemId && i.Lookbook_ID == wishlistId);
                    item.Note = note;
                    returnValue = await SaveChangesAsync();

                    if (returnValue)
                    {
                        transaction.Complete();
                    }
                    else
                    {
                        transaction.Dispose();
                    }
                    return returnValue;
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<bool> AddItemToWishList(Lookbook_Item wishListItem)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var addItemResult = false;
                    var editWishListResult = false;
                    _ctx.Lookbook_Item.Add(wishListItem);
                    addItemResult = await SaveChangesAsync();

                    var wishList = await _ctx.Lookbooks.FirstOrDefaultAsync(o => o.ID == wishListItem.Lookbook_ID);
                    if (wishList != null)
                    {
                        wishList.LastModified = DateTime.UtcNow;
                        editWishListResult = await SaveChangesAsync();
                    }
                    if (editWishListResult && addItemResult)
                    {
                        transaction.Complete();
                        return true;
                    }
                    else
                    {
                        transaction.Dispose();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<bool> AddWishListWithItems(List<Lookbook_Item> wishListItems)
        {
            try
            {
                var result = true;
                if (wishListItems.Count > 0)
                {
                    _ctx.Lookbook_Item.AddRange(wishListItems);
                    result = await SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> CreateNewWishListAndAddItem(string WishListName, Guid ItemId, Guid UserId)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //Add new wishlist
                    var AddWishListIsSuccess = false;
                    var AddItemToWishListIsSuccess = false;
                    Guid WishListId = Guid.Empty;
                    var WishList = await _ctx.Lookbooks.FirstOrDefaultAsync(o => o.Name.ToUpper() == WishListName.ToUpper() && o.User_ID == UserId);
                    if (WishList != null)
                    {
                        WishListId = WishList.ID;
                    }
                    else
                    {
                        Lookbook newWishList = new Lookbook
                        {
                            ID = Guid.NewGuid(),
                            Name = WishListName,
                            User_ID = UserId,
                            DateCreated = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow
                        };
                        AddWishListIsSuccess = await CreateWishList(newWishList);
                        if (AddWishListIsSuccess)
                        {
                            WishListId = newWishList.ID;
                        }
                    }
                    //Add item to new wishlist
                    if (WishListId != Guid.Empty)
                    {
                        var WishListItem = new Lookbook_Item
                        {
                            Item_ID = ItemId,
                            Lookbook_ID = WishListId,
                            DateAdded = DateTime.UtcNow
                        };
                        AddItemToWishListIsSuccess = await AddItemToWishList(WishListItem);
                    }
                    if (AddWishListIsSuccess && AddItemToWishListIsSuccess)
                    {
                        transaction.Complete();
                    }
                    else
                    {
                        transaction.Dispose();
                    }
                    return WishListId;
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<bool> CreateWishList(Lookbook wishList)
        {
            try
            {
                _ctx.Lookbooks.Add(wishList);
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteItemInWishList(Lookbook_Item wishListItem)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var removeItemResult = false;
                    var editWishListResult = false;
                    _ctx.Lookbook_Item.Remove(wishListItem);
                    removeItemResult = await SaveChangesAsync();

                    var wishList = await _ctx.Lookbooks.FirstOrDefaultAsync(o => o.ID == wishListItem.Lookbook_ID);
                    if (wishList != null)
                    {
                        wishList.LastModified = DateTime.UtcNow;
                        editWishListResult = await SaveChangesAsync();
                    }
                    if (removeItemResult && editWishListResult)
                    {
                        transaction.Complete();
                        return true;
                    }
                    else
                    {
                        transaction.Dispose();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<bool> DeleteWishList(Guid WishListId, Guid UserId)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var removeWishListItem = false;
                    var removeWishListShared = false;
                    var removeWishList = false;

                    //Remove item in wishlist
                    List<Lookbook_Item> wishListItems = await _ctx.Lookbook_Item.Where(o => o.Lookbook_ID == WishListId).ToListAsync();
                    _ctx.Lookbook_Item.RemoveRange(wishListItems);
                    removeWishListItem = await SaveChangesAsync();

                    //Remove wishlist shared
                    List<LookbookShared> lookbookShareds = await _ctx.LookbookShareds.Where(o => o.Lookbook_ID == WishListId).ToListAsync();
                    _ctx.LookbookShareds.RemoveRange(lookbookShareds);
                    removeWishListShared = await SaveChangesAsync();

                    //Remove wishlist
                    Lookbook wishList = await _ctx.Lookbooks.FirstOrDefaultAsync(o => o.ID == WishListId && o.User_ID == UserId);
                    _ctx.Lookbooks.Remove(wishList);
                    removeWishList = await SaveChangesAsync();

                    if (removeWishListItem && removeWishListShared && removeWishList)
                    {
                        transaction.Complete();
                        return true;
                    }
                    else
                    {
                        transaction.Dispose();
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<bool> EditWishList(Lookbook wishList)
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var result = false;
                    result = await SaveChangesAsync();
                    scope.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public LookbookShared GetWishlistBySharedWishlistId(Guid sharedWishlistId) {
            return _ctx.LookbookShareds.AsNoTracking().FirstOrDefault(o => o.ID == sharedWishlistId);
        }

        public IQueryable<Lookbook> GetWishList()
        {
            return _ctx.Lookbooks.AsNoTracking();
        }
        public IQueryable<Lookbook> GetWishListTracking()
        {
            return _ctx.Lookbooks;
        }

        public IQueryable<Lookbook_Item> GetWishListItems(Guid? CountryId)
        {
            if (CountryId.HasValue)
            {
                var blackoutItems = _ctx.Items.AsNoTracking().Where(o => o.Countries.Any(c => c.ID == CountryId));
                return _ctx.Lookbook_Item.Where(o => !blackoutItems.Any(b => b.ID == o.Item_ID));
            }
            else {
                return _ctx.Lookbook_Item;
            }
        }

        public IQueryable<Lookbook_Item> GetWishListItemsForCheckingItemExists(Guid wishListId)
        {
            return _ctx.Lookbook_Item.Where(o => o.Lookbook_ID == wishListId);
        }

        public bool IsItemInWishlist(string productSku, JWTIdentityViewModel jwtModel)
        {
            bool isInWishlist = false;
            List<WishListViewModel> lstWishList = new List<WishListViewModel>();
            try
            {
                var count = this.GetWishList().Where(o => o.User_ID == jwtModel.UserId).Where(w => w.Lookbook_Item.Any(i => i.Item.SKU == productSku)).Count();
                if ((count) > 0)
                {
                    isInWishlist = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isInWishlist;
        }

        public override IQueryable<Lookbook> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Lookbook> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(Lookbook t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Lookbook t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
