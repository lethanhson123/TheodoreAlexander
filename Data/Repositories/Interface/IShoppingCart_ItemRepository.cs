using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IShoppingCart_ItemRepository : IRepository<ShoppingCart_Item>
    {
        public List<ShoppingCart_Item> GetByShoppingCart_IDToList(string shoppingCart_ID);
        public Task<int> AsyncUpdateBySQL(ShoppingCart_Item model);
    }
}

