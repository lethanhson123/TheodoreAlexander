using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data2021.DataTransfer;
using TA.Data2021.Models;
namespace TA.Data2021.Repositories
{
    public interface IShoppingCart_ItemRepository : IRepository<ShoppingCart_Item>
    {
        Task<int> AsyncUpdateBySQL(ShoppingCart_Item model);
        int UpdateBySQL(ShoppingCart_Item model);
    }
}

