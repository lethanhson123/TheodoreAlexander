
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data2021.Models;
using TA.Helpers2021;
using TA.Data2021.Repositories;
using System.Threading.Tasks;

namespace TA.Data2021.Repositories
{
    public class ShoppingCart_ItemRepository : Repository<ShoppingCart_Item>, IShoppingCart_ItemRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public ShoppingCart_ItemRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public async Task<int> AsyncUpdateBySQL(ShoppingCart_Item model)
        {
            int result = AppGlobal.InitializationNumber;
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
            string mes = await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCart_ItemUpdateSingleItemByID", parameters);
            return result;
        }
        public int UpdateBySQL(ShoppingCart_Item model)
        {
            int result = AppGlobal.InitializationNumber;
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
            string mes = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCart_ItemUpdateSingleItemByID", parameters);
            return result;
        }
    }
}

