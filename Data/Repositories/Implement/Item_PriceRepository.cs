using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class Item_PriceRepository : Repository<Item_Price>, IItem_PriceRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_PriceRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_Price> GetBySKUToList(string SKU)
        {
            List<Item_Price> result = new List<Item_Price>();
            if (!string.IsNullOrEmpty(SKU))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@SKU",SKU),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_PriceSelectItemsBySKU", parameters);
                result = SQLHelper.ToList<Item_Price>(dt);
            }
            return result;
        }
        public int InsertBySQL(Item_Price model)
        {
            int result = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.SKU))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@SKU",model.SKU),
                new SqlParameter("@Region",model.Region),
                new SqlParameter("@Price",model.Price),
                };
                string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_PriceInsertSingleItem", parameters);
            }
            return result;
        }
        public int UpdateBySQL(Item_Price model)
        {
            int result = AppGlobal.InitializationNumber;            
            SqlParameter[] parameters =
            {               
                new SqlParameter("@SKU",model.SKU),
                new SqlParameter("@Region",model.Region),
                new SqlParameter("@Price",model.Price),                
                };
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_PriceUpdateSingleItemBySKUAndRegion", parameters);
            return result;
        }

    }
}

