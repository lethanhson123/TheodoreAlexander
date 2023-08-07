using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data2021.DataTransfer;
using TA.Data2021.Models;
namespace TA.Data2021.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task<int> AsyncUpdateBySQL(ShoppingCart model);
        string UpdateBySQL(ShoppingCart model);
        ShoppingCart GetByID(string ID);
    }
}

