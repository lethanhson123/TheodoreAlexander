using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class WishListItemViewModel2 : ItemDto
    {
        public bool HasNote { get; set; }
        public Guid WishList_ID { get; set; }
        public string WishList_Name { get; set; }
        public DateTime WishList_DateCreated { get; set; }
        public DateTime WishList_LastModified { get; set; }
        public DateTime DateAdded { get; set; }
        public string Note { get; set; }

        public WishListItemViewModel2(Item item) : base(item) {
        }
    }
}
