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
    public class SKUListingForSizeAvailabilityRepository : Repository<SKUListingForSizeAvailability>, ISKUListingForSizeAvailabilityRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public SKUListingForSizeAvailabilityRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<SKUListingForSizeAvailability> GetByItem_IDToList(Guid Item_ID)
        {
            List<SKUListingForSizeAvailability> result = new List<SKUListingForSizeAvailability>();
            result = _context.Set<SKUListingForSizeAvailability>().Where(model => model.Item_ID == Item_ID).ToList();
            return result;
        }
        public string InsertBySQL(SKUListingForSizeAvailability model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@SKU",model.SKU),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SKUListingForSizeAvailabilityInsertSingleItem", parameters);
            return result;
        }
        public string Insert001BySQL(string itemSKU, string sKU)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(itemSKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ItemSKU",itemSKU),
                    new SqlParameter("@Item02SKU",sKU),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SKUListingForSizeAvailabilityInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string ID)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",ID),                
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SKUListingForSizeAvailabilityDeleteByID", parameters);
            return result;
        }
    }
}

