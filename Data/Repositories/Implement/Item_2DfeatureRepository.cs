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
    public class Item_2DfeatureRepository : Repository<Item_2Dfeature>, IItem_2DfeatureRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_2DfeatureRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_2Dfeature> GetByItem_IDToList(string Item_ID)
        {
            List<Item_2Dfeature> result = new List<Item_2Dfeature>();
            result = _context.Set<Item_2Dfeature>().Where(model => model.Item_ID == Guid.Parse(Item_ID)).OrderBy(model => model.FeatureName).ToList();
            return result;
        }
        public string InsertBySQL(Item_2Dfeature model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@2Dfeature_ID",model.Feature_ID2D),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_2DfeatureInsertSingleItem", parameters);
            return result;
        }
        public string Insert001BySQL(string sKU, string featureName)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(sKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",sKU),
                    new SqlParameter("@FeatureName",featureName),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_2DfeatureInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string Item_ID, string Feature_ID2D)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",Item_ID),
                new SqlParameter("@2Dfeature_ID",Feature_ID2D),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_2DfeatureDeleteSingleItem", parameters);
            return result;
        }
    }
}