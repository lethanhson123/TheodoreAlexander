using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class WishListItemViewModel: ItemDetailsViewModel//TODO: Need to change to ItemDetailsViewModel2
    {
        public bool HasNote { get; set; }
        public Guid WishList_ID { get; set; }
        public string WishList_Name { get; set; }
        public DateTime WishList_DateCreated { get; set; }
        public DateTime WishList_LastModified { get; set; }
        public DateTime DateAdded { get; set; }
        public string Note { get; set; }
    }
    public class WishListItemsRequestObj
    {
        public string WishListId { get; set; }
        public string ItemIDs { get; set; }
    }
    public class WishListItemRequestObj
    {
        public string WishListId { get; set; }
        public string ItemId { get; set; }
    }
    public class CreateWishListModel
    {
        public string WishListName { get; set; }
    }
    public class EditWishListModel: CreateWishListModel
    {
        public string ID { get; set; }
    }
    public class CreateWishListAndAddItemModel:CreateWishListModel
    {
        public string ItemId { get; set; }
    }
    public class CoppyItemToWishListModel
    {
        public string OldWishListId { get; set; }
        public string NewWishListId { get; set; }
        public string ItemId { get; set; }
    }
    public class WishListViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int NumberOfItems { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public List<string> ProductSKUList { get; set; }
    }
    public class AnonymousWishList
    {
        public Guid ItemId { get; set; }
        public DateTime DateAdded { get; set; }
        public AnonymousWishList()
        {
            DateAdded = DateTime.UtcNow;
        }
    }

    public class ShareWishlistRequest {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public List<dynamic> ToList { get; set; }
        public Guid WishlistId { get; set; }
        public string Message { get; set; }
        public bool IncludeNotes { get; set; }
        public bool IsSelfCopy { get; set; }
    }
}
