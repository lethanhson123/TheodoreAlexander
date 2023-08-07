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
    public class Item_CenturyRepository : Repository<Item_Century>, IItem_CenturyRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_CenturyRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_Century> GetByItem_IDToList(string Item_ID)
        {
            List<Item_Century> result = new List<Item_Century>();
            result= _context.Set<Item_Century>().Where(model => model.Item_ID == Guid.Parse(Item_ID)).OrderBy(model => model.CenturyName).ToList();
            return result;
        }
        public string InsertBySQL(Item_Century model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@Century_ID",model.Century_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_CenturyInsertSingleItem", parameters);
            return result;
        }
        public string Insert001BySQL(string sKU, string centuryName)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(sKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",sKU),
                    new SqlParameter("@CenturyName",centuryName),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_CenturyInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string Item_ID, string Century_ID)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",Item_ID),
                new SqlParameter("@Century_ID",Century_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_CenturyDeleteSingleItem", parameters);
            return result;
        }

    }
}

