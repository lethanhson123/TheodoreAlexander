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
    public class Item_HistoricalStyleRepository : Repository<Item_HistoricalStyle>, IItem_HistoricalStyleRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_HistoricalStyleRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_HistoricalStyle> GetByItem_IDToList(string Item_ID)
        {
            List<Item_HistoricalStyle> result = new List<Item_HistoricalStyle>();
            result= _context.Set<Item_HistoricalStyle>().Where(model => model.Item_ID == Guid.Parse(Item_ID)).OrderBy(model => model.HistoricalStyleName).ToList();
            return result;
        }
        public string InsertBySQL(Item_HistoricalStyle model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@HistoricalStyle_ID",model.HistoricalStyle_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_HistoricalStyleInsertSingleItem", parameters);
            return result;
        }
        public string Insert001BySQL(string sKU, string historicalStyleName)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(sKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",sKU),
                    new SqlParameter("@HistoricalStyleName",historicalStyleName),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_HistoricalStyleInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string Item_ID, string HistoricalStyle_ID)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",Item_ID),
                new SqlParameter("@HistoricalStyle_ID",HistoricalStyle_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_HistoricalStyleDeleteSingleItem", parameters);
            return result;
        }

    }
}

