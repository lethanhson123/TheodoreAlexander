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
    public class Item_GeographyRepository : Repository<Item_Geography>, IItem_GeographyRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_GeographyRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_Geography> GetByItem_IDToList(string Item_ID)
        {
            List<Item_Geography> result = new List<Item_Geography>();
            result= _context.Set<Item_Geography>().Where(model => model.Item_ID == Guid.Parse(Item_ID)).OrderBy(model => model.GeographyName).ToList();
            return result;
        }
        public string InsertBySQL(Item_Geography model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@Geography_ID",model.Geography_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_GeographyInsertSingleItem", parameters);
            return result;
        }
        public string Insert001BySQL(string sKU, string geographyName)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(sKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",sKU),
                    new SqlParameter("@GeographyName",geographyName),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_GeographyInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string Item_ID, string Geography_ID)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",Item_ID),
                new SqlParameter("@Geography_ID",Geography_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_GeographyDeleteSingleItem", parameters);
            return result;
        }
    }
}

