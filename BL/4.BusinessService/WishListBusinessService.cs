using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BL.CustomExceptions;
using System.Configuration;
using BL.EntityService;
using BL.DTO;
using System.Dynamic;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class WishListBusinessService
    {
        private bool disposed = false;
        private readonly WishListModelServices _wishListModelServices;
        private readonly ItemEntityService _itemModelServices;

        public WishListBusinessService(WishListModelServices wishListServices, ItemEntityService itemModelServices)
        {
            _wishListModelServices = wishListServices;
            _itemModelServices = itemModelServices;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _wishListModelServices.Dispose();
                _itemModelServices.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task<bool> AddItemListToWishList(Guid wishlistId, List<AnonymousWishList> wishlistItems)
        {
            try
            {
                List<Guid> tobeAddedList = new List<Guid>();
                //de-duplicate
                wishlistItems = wishlistItems.GroupBy(i => i.ItemId).Select(i => i.First()).ToList();
                List<Lookbook_Item> wishListItemForinsert = new List<Lookbook_Item>();
                foreach (var wlItem in wishlistItems)
                {
                    var existsItem = await _wishListModelServices.GetWishListItemsForCheckingItemExists(wishlistId).Where(o => o.Item_ID == wlItem.ItemId).ToListAsync();
                    if (existsItem.Count < 1)
                    {
                        wishListItemForinsert.Add(new Lookbook_Item { Lookbook_ID = wishlistId, Item_ID = wlItem.ItemId, DateAdded = wlItem.DateAdded != null ? wlItem.DateAdded : DateTime.UtcNow });
                    }
                }
                return await _wishListModelServices.AddWishListWithItems(wishListItemForinsert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IList<WishListViewModel>> GetWishListByUserId(JWTIdentityViewModel jwtModel)
        {
            List<WishListViewModel> lstWishList = new List<WishListViewModel>();
            try
            {
                lstWishList = await _wishListModelServices.GetWishList().Where(o => o.User_ID == jwtModel.UserId).Select(o => new WishListViewModel
                {
                    ID = o.ID,
                    Name = o.Name,
                    NumberOfItems = o.Lookbook_Item.Count(),
                    DateCreated = o.DateCreated,
                    LastModified = o.LastModified,
                    ProductSKUList = o.Lookbook_Item.Select(i => i.Item.SKU).ToList()
                }).OrderByDescending(i => i.DateCreated).ToListAsync();
                return lstWishList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IList<WishListViewModel>> GetWishListByUserIDGuid(Guid userID)
        {
            List<WishListViewModel> lstWishList = new List<WishListViewModel>();
            try
            {
                lstWishList = await _wishListModelServices.GetWishList().Where(o => o.User_ID == userID).Select(o => new WishListViewModel
                {
                    ID = o.ID,
                    Name = o.Name,
                    NumberOfItems = o.Lookbook_Item.Count(),
                    DateCreated = o.DateCreated,
                    LastModified = o.LastModified,
                    ProductSKUList = o.Lookbook_Item.Select(i => i.Item.SKU).ToList()
                }).OrderByDescending(i => i.DateCreated).ToListAsync();
                return lstWishList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> DeleteWishList(JWTIdentityViewModel jwtModel, Guid wishListId)
        {
            try
            {
                var result = Guid.Empty;
                var deleteResult = await _wishListModelServices.DeleteWishList(wishListId, (Guid)jwtModel.UserId);
                if (deleteResult)
                {
                    result = wishListId;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> AddWishList(Guid UserId, CreateWishListModel createWishListModel)
        {
            try
            {
                var addResult = false;
                var result = Guid.Empty;
                var wishList = await _wishListModelServices.GetWishListTracking().FirstOrDefaultAsync(o => o.Name.ToUpper() == createWishListModel.WishListName.ToUpper() && o.User_ID == UserId);
                if (wishList == null)
                {
                    Lookbook newWishList = new Lookbook
                    {
                        ID = Guid.NewGuid(),
                        Name = createWishListModel.WishListName,
                        User_ID = UserId,
                        DateCreated = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow
                    };
                    addResult = await _wishListModelServices.CreateWishList(newWishList);
                    if (addResult)
                    {
                        result = newWishList.ID;
                    }
                }
                else
                {
                    result = wishList.ID;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid> AddWishListByUserIDAndWishlistName(Guid userID, string wishlistName)
        {
            try
            {
                var addResult = false;
                var result = Guid.Empty;
                var wishList = await _wishListModelServices.GetWishListTracking().FirstOrDefaultAsync(o => o.Name.ToUpper() == wishlistName.ToUpper() && o.User_ID == userID);
                if (wishList == null)
                {
                    Lookbook newWishList = new Lookbook
                    {
                        ID = Guid.NewGuid(),
                        Name = wishlistName,
                        User_ID = userID,
                        DateCreated = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow
                    };
                    addResult = await _wishListModelServices.CreateWishList(newWishList);
                    if (addResult)
                    {
                        result = newWishList.ID;
                    }
                }
                else
                {
                    result = wishList.ID;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WishListViewModel> GetWishListOfUsersById(Guid userId, Guid wishlistId)
        {
            try
            {
                var wishList = await _wishListModelServices.GetWishListTracking().Where(w => w.User_ID == userId && w.ID == wishlistId).FirstOrDefaultAsync();
                if (wishList == null)
                {
                    return null;
                }
                WishListViewModel wishListViewModel = new WishListViewModel
                {
                    ID = wishList.ID,
                    Name = wishList.Name,
                    NumberOfItems = wishList.Lookbook_Item.Count(),
                    DateCreated = wishList.DateCreated,
                    LastModified = wishList.LastModified
                };
                return wishListViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> EditWishList(Guid UserId, EditWishListModel editWishListModel)
        {
            try
            {
                var editResult = false;
                var result = Guid.Empty;
                var wishListId = Helper.TryParseStringToGuid(editWishListModel.ID);
                var wishList = await _wishListModelServices.GetWishListTracking().FirstOrDefaultAsync(o => o.ID == wishListId && o.User_ID == UserId);
                if (wishList != null)
                {
                    if (wishList.Name.ToUpper() == editWishListModel.WishListName.ToUpper())
                    {
                        result = wishList.ID;
                    }
                    else
                    {
                        wishList.LastModified = DateTime.UtcNow;
                        wishList.Name = editWishListModel.WishListName;

                        editResult = await _wishListModelServices.EditWishList(wishList);
                        if (editResult)
                        {
                            result = wishList.ID;
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> AddItemToWishList(Guid ItemId, Guid WishListId, Guid UserId, Guid? CountryId)
        {
            try
            {
                var result = Guid.Empty;
                //Check User WishList
                var newWishList = await _wishListModelServices.GetWishList().FirstOrDefaultAsync(o => o.ID == WishListId && o.User_ID == UserId);
                if (newWishList == null)
                {
                    return result;
                }
                //Check Item in New WishList
                var newWishListItem = await _wishListModelServices.GetWishListItems(CountryId).FirstOrDefaultAsync(o => o.Item_ID == ItemId && o.Lookbook_ID == WishListId);
                if (newWishListItem != null)
                {
                    return WishListId;
                }
                newWishListItem = new Lookbook_Item
                {
                    Item_ID = ItemId,
                    Lookbook_ID = WishListId,
                    DateAdded = DateTime.UtcNow
                };

                var moveResult = await _wishListModelServices.AddItemToWishList(newWishListItem);

                if (moveResult)
                {
                    result = WishListId;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid> AddItemToWishListByUserIDAndWishListIDAndItemID(Guid userID, Guid wishListID, Guid itemID)
        {
            try
            {
                var result = Guid.Empty;                
                var newWishList = await _wishListModelServices.GetWishList().FirstOrDefaultAsync(o => o.ID == wishListID && o.User_ID == userID);
                if (newWishList == null)
                {
                    return result;
                }               
                Lookbook_Item newWishListItem = new Lookbook_Item
                {
                    Item_ID = itemID,
                    Lookbook_ID = wishListID,
                    DateAdded = DateTime.UtcNow
                };

                var moveResult = await _wishListModelServices.AddItemToWishList(newWishListItem);

                if (moveResult)
                {
                    result = wishListID;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditNoteOfWishlistItem(WishListItemViewModel wishlistItem)
        {
            try
            {
                return await _wishListModelServices.EditWishlistItemNote(wishlistItem.WishList_ID, wishlistItem.ID, wishlistItem.Note);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreateLookBookShared(Guid fromUserID, ShareWishlistRequest shareWishlistRequest)
        {
            try
            {
                LookbookShared sharedLookBook = await _wishListModelServices.CreateLookBookShared(fromUserID, shareWishlistRequest.FromName, shareWishlistRequest.FromEmail, shareWishlistRequest.WishlistId, null, null, shareWishlistRequest.IncludeNotes, shareWishlistRequest.Message);
                if (sharedLookBook != null)
                {
                    //send mail
                    return await SendEmailShareWishlist(sharedLookBook, shareWishlistRequest);
                }
                else
                {
                    throw new Exception(String.Format("Cannot send email to ${0}", ""));
                }
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "The specified string is not in the form required for an e-mail address.":
                        ex = new Exception("The email you entered is incorrect. Please review it and try again.", ex);
                        break;
                    default:
                        break;
                }
                throw ex;
            }
        }

        private async Task<bool> SendEmailShareWishlist(LookbookShared sharedLookbook, ShareWishlistRequest shareWishlistRequest)
        {
            try
            {
                string sirvProductPhotos = ConfigurationManager.AppSettings["SirvProductPhoto"];
                string webURL = ConfigurationManager.AppSettings["WebURL"];
                string lookBookShareLink = String.Format("{0}/shared-wishlist/{1}", webURL, sharedLookbook.ID);
                Lookbook lookBook = _wishListModelServices.GetWishList().FirstOrDefault(o => o.ID == sharedLookbook.Lookbook_ID);
                List<Task<bool>> listTask = new List<Task<bool>>();
                foreach (var recipient in shareWishlistRequest.ToList)
                {
                    listTask.Add(Helper.SendMail(sharedLookbook.FromName, sharedLookbook.FromEmail, recipient.Name.ToString(), recipient.Email.ToString(), sharedLookbook.FromName + " has some design inspiration for you", await Helper.RenderEmailSharedWishlist(lookBook.Lookbook_Item, recipient.Name.ToString(), sharedLookbook.FromName, sharedLookbook.FromEmail, sharedLookbook.Message, lookBookShareLink)));
                }
                if (shareWishlistRequest.IsSelfCopy)
                {
                    listTask.Add(Helper.SendMail(sharedLookbook.FromName, sharedLookbook.FromEmail, sharedLookbook.FromName, sharedLookbook.FromEmail, sharedLookbook.FromName + " has some design inspiration for you", await Helper.RenderEmailSharedWishlist(lookBook.Lookbook_Item, sharedLookbook.FromName, sharedLookbook.FromName, sharedLookbook.FromEmail, sharedLookbook.Message, lookBookShareLink)));
                }
                bool[] results = await Task.WhenAll<bool>(listTask);
                return results.All(v => v == true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> DeleteItemInWishList(Guid itemId, Guid WishListId, JWTIdentityViewModel jwtModel)
        {
            var item = await _wishListModelServices.GetWishListItems(jwtModel.CountryId).FirstOrDefaultAsync(o => o.Item_ID == itemId && o.Lookbook_ID == WishListId);
            if (item == null)
            {
                return Guid.Empty;
            }
            else
            {
                bool deleteResult = await _wishListModelServices.DeleteItemInWishList(item);
                if (deleteResult)
                {
                    //var result = await GetWishListItemsByWishListId(jwtModel, WishListId.ToString());
                    return WishListId;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        public ICollection<Lookbook_Item> GetItemsBySharedWishlistId(Guid sharedWishlistId)
        {
            //get wishlist id
            LookbookShared sharedWishlist = _wishListModelServices.GetWishlistBySharedWishlistId(sharedWishlistId);
            //get items of wishlist id
            var items = this.GetItemsByWishListId(sharedWishlist.Lookbook_ID);
            //exculde the note if needed
            if (!sharedWishlist.IncludeNotes)
            {
                foreach (var item in items)
                {
                    item.Note = String.Empty;
                }
            }
            return items;
        }

        public ICollection<Lookbook_Item> GetItemsByWishListId(Guid wishlistId)
        {
            Lookbook lookbook = _wishListModelServices.GetWishList().Where(w => w.ID == wishlistId).FirstOrDefault();
            return lookbook.Lookbook_Item;
        }
    }
}
