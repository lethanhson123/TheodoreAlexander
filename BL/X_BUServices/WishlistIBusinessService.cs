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
    public interface IWishlistlItemService : IDisposable
    {
        Task<bool> AddItemListToWishList(Guid wishlistId, List<AnonymousWishList> wishlistItems);
        Task<IList<WishListViewModel>> GetWishListByUserId(JWTIdentityViewModel jwtModel);
        Task<IList<WishListViewModel>> GetWishListByUserIDGuid(Guid userID);
        Task<Guid> DeleteWishList(JWTIdentityViewModel jwtModel, Guid wishListId);
        Task<Guid> AddWishList(Guid UserId, CreateWishListModel createWishListModel);
        Task<Guid> AddWishListByUserIDAndWishlistName(Guid userId, string wishlistName);
        Task<WishListViewModel> GetWishListOfUsersById(Guid userId, Guid wishlistId);
        Task<Guid> EditWishList(Guid UserId, EditWishListModel editWishListModel);
        Task<Guid> AddItemToWishList(Guid ItemId, Guid WishListId, Guid UserId, Guid? CountryId);
        Task<Guid> AddItemToWishListByUserIDAndWishListIDAndItemID(Guid userID, Guid wishListID, Guid itemID);
        Task<bool> EditNoteOfWishlistItem(WishListItemViewModel wishlistItem);
        Task<bool> CreateLookBookShared(Guid fromUserID, ShareWishlistRequest shareWishlistRequest);
        Task<IList<WishListItemViewModel2>> GetWishListItemsByWishListId(JWTIdentityViewModel jwtModel, Guid Id);
        Task<Guid> DeleteItemInWishList(Guid itemId, Guid WishListId, JWTIdentityViewModel jwtModel);
        Task<IList<WishListItemViewModel2>> GetItemsOfSharedWishlist(JWTIdentityViewModel jwtModel, Guid sharedWishlistId);
    }

    public class WishlistIBusinessService : IWishlistlItemService
    {
        private readonly WishListBusinessService _wishListService;
        private readonly ItemBusinessService _itemService;
        private bool disposed = false;
        public WishlistIBusinessService(WishListBusinessService wishListService, ItemBusinessService itemService)
        {
            _wishListService = wishListService;
            _itemService = itemService;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _wishListService.Dispose();
                _itemService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Implement interface
        public async Task<IList<WishListViewModel>> GetWishListByUserId(JWTIdentityViewModel jwtModel)
        {
            return await _wishListService.GetWishListByUserId(jwtModel);
        }
        public async Task<IList<WishListViewModel>> GetWishListByUserIDGuid(Guid userID)
        {
            return await _wishListService.GetWishListByUserIDGuid(userID);
        }
        public async Task<Guid> DeleteWishList(JWTIdentityViewModel jwtModel, Guid wishListId)
        {
            return await _wishListService.DeleteWishList(jwtModel, wishListId);
        }

        public async Task<Guid> AddWishList(Guid UserId, CreateWishListModel createWishListModel)
        {
            return await _wishListService.AddWishList(UserId, createWishListModel);
        }
        public async Task<Guid> AddWishListByUserIDAndWishlistName(Guid userID, string wishlistName)
        {
            return await _wishListService.AddWishListByUserIDAndWishlistName(userID, wishlistName);
        }
        public async Task<WishListViewModel> GetWishListOfUsersById(Guid userId, Guid wishlistId)
        {
            return await _wishListService.GetWishListOfUsersById(userId, wishlistId);
        }

        public async Task<Guid> EditWishList(Guid UserId, EditWishListModel editWishListModel)
        {
            return await _wishListService.EditWishList(UserId, editWishListModel);
        }

        public async Task<Guid> AddItemToWishList(Guid ItemId, Guid WishListId, Guid UserId, Guid? CountryId)
        {
            return await _wishListService.AddItemToWishList(ItemId, WishListId, UserId, CountryId);
        }
        public async Task<Guid> AddItemToWishListByUserIDAndWishListIDAndItemID(Guid userID, Guid wishListID, Guid itemID)
        {
            return await _wishListService.AddItemToWishListByUserIDAndWishListIDAndItemID(userID, wishListID, itemID);
        }


        public async Task<bool> EditNoteOfWishlistItem(WishListItemViewModel wishlistItem)
        {
            return await _wishListService.EditNoteOfWishlistItem(wishlistItem);
        }

        public async Task<bool> CreateLookBookShared(Guid fromUserID, ShareWishlistRequest shareWishlistRequest)
        {
            return await _wishListService.CreateLookBookShared(fromUserID, shareWishlistRequest);
        }

        public async Task<IList<WishListItemViewModel2>> GetWishListItemsByWishListId(JWTIdentityViewModel jwtModel, Guid Id)
        {
            List<Lookbook_Item> items = _wishListService.GetItemsByWishListId(Id).ToList();
            return await ProjectToWishlistItemViewModel(items, jwtModel);
        }
        public async Task<IList<WishListItemViewModel2>> GetItemsOfSharedWishlist(JWTIdentityViewModel jwtModel, Guid sharedWishlistId)
        {
            List<Lookbook_Item> items = _wishListService.GetItemsBySharedWishlistId(sharedWishlistId).ToList();
            return await ProjectToWishlistItemViewModel(items, jwtModel);
        }
        public async Task<Guid> DeleteItemInWishList(Guid itemId, Guid WishListId, JWTIdentityViewModel jwtModel)
        {
            return await _wishListService.DeleteItemInWishList(itemId, WishListId, jwtModel);
        }

        public async Task<bool> AddItemListToWishList(Guid wishlistId, List<AnonymousWishList> wishlistItems)
        {
            return await _wishListService.AddItemListToWishList(wishlistId, wishlistItems);
        }
        #endregion

        private async Task<List<WishListItemViewModel2>> ProjectToWishlistItemViewModel(List<Lookbook_Item> items, JWTIdentityViewModel jwtModel)
        {
            List<WishListItemViewModel2> results = items.Select(i => new WishListItemViewModel2(i.Item)
            {
                WishList_ID = i.Lookbook_ID,
                WishList_Name = i.Lookbook.Name,
                WishList_DateCreated = i.Lookbook.DateCreated,
                WishList_LastModified = i.Lookbook.LastModified,
                Note = i.Note,
                DateAdded = i.DateAdded,
                IsAvailable = _itemService.IsAvailableItem(jwtModel, i.Item_ID),
            }).ToList();

            foreach (WishListItemViewModel2 item in results)
            {
                _itemService.SetupPrices(item, jwtModel);
            }
            return results;
        }
    }
}
