using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        public ShoppingCart GetByID(string ID);        
        public List<ShoppingCart> GetBySearchStringToList(string searchString);
        public Task<int> AsyncUpdateBySQL(ShoppingCart model);
        public int UpdateBySQL(ShoppingCart model);
    }
}

