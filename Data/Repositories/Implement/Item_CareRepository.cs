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
    public class Item_CareRepository : Repository<Item_Care>, IItem_CareRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_CareRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_Care> GetByItem_IDToList(string Item_ID)
        {
            List<Item_Care> result = new List<Item_Care>();
            result= _context.Set<Item_Care>().Where(model => model.Item_ID == Guid.Parse(Item_ID)).OrderBy(model => model.CareName).ToList();
            return result;
        }
        public string InsertBySQL(Item_Care model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@Care_ID",model.Care_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_CareInsertSingleItem", parameters);
            return result;
        }
        public string Insert001BySQL(string sKU, string careName)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(sKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",sKU),
                    new SqlParameter("@CareName",careName),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_CareInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string Item_ID, string Care_ID)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",Item_ID),
                new SqlParameter("@Care_ID",Care_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_CareDeleteSingleItem", parameters);
            return result;
        }
    }
}

