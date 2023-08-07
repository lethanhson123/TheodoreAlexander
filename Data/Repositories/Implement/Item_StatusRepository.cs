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

    public class Item_StatusRepository : Repository<Item_Status>, IItem_StatusRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_StatusRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_Status> GetBySKUToList(string SKU)
        {
            List<Item_Status> result = new List<Item_Status>();
            if (!string.IsNullOrEmpty(SKU))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@SKU",SKU),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_StatusSelectItemsBySKU", parameters);
                result = SQLHelper.ToList<Item_Status>(dt);
            }
            return result;
        }
        public int InsertBySQL(Item_Status model)
        {
            int result = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.SKU))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@SKU",model.SKU),
                new SqlParameter("@Region",model.Region),
                new SqlParameter("@IsActive",model.IsActive),
                };
                string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_StatusInsertSingleItem", parameters);
            }
            return result;
        }
        public int UpdateBySQL(Item_Status model)
        {
            int result = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.SKU))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@SKU",model.SKU),
                new SqlParameter("@Region",model.Region),
                new SqlParameter("@IsActive",model.IsActive),
                };
                string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_StatusUpdateSingleItemBySKUAndRegion", parameters);
            }
            
            return result;
        }

    }
}

