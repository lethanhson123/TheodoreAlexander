using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class ShoppingCart_ItemRepository : Repository<ShoppingCart_Item>, IShoppingCart_ItemRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public ShoppingCart_ItemRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<ShoppingCart_Item> GetByShoppingCart_IDToList(string shoppingCart_ID)
        {
            List<ShoppingCart_Item> result = new List<ShoppingCart_Item>();
            if (!string.IsNullOrEmpty(shoppingCart_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ShoppingCart_ID",shoppingCart_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCart_ItemSelectItemsByShoppingCart_ID", parameters);
                result = SQLHelper.ToList<ShoppingCart_Item>(dt);
            }
            return result;
        }
        public async Task<int> AsyncUpdateBySQL(ShoppingCart_Item model)
        {
            int result = AppGlobal.InitializationNumber;
            Initialization(model);
            SqlParameter[] parameters =
            {
                new SqlParameter("@ShoppingCart_ID",model.ShoppingCart_ID),
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@ItemTotal",model.ItemTotal),
                new SqlParameter("@Price",model.Price),
                new SqlParameter("@DesignerPrice",model.DesignerPrice),
                new SqlParameter("@DealerPrice",model.DealerPrice),
                new SqlParameter("@ImageURL",model.ImageURL),
                new SqlParameter("@URL",model.URL),
                new SqlParameter("@ProductName",model.ProductName),
                new SqlParameter("@SKU",model.SKU),
                new SqlParameter("@Volume",model.Volume),
                new SqlParameter("@Availability",model.Availability),
                };
            await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCart_ItemUpdateSingleItemByID", parameters);
            return result;
        }
    }
}

