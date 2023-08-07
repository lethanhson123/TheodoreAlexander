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
    public class Item_3DfeatureRepository : Repository<Item_3Dfeature>, IItem_3DfeatureRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_3DfeatureRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_3Dfeature> GetByItem_IDToList(string Item_ID)
        {
            List<Item_3Dfeature> result = new List<Item_3Dfeature>();
            result = _context.Set<Item_3Dfeature>().Where(model => model.Item_ID == Guid.Parse(Item_ID)).OrderBy(model => model.FeatureName).ToList();
            return result;
        }
        public string InsertBySQL(Item_3Dfeature model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@3Dfeature_ID",model.Feature_ID3D),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_3DfeatureInsertSingleItem", parameters);
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
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_3DfeatureInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string Item_ID, string Feature_ID3D)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",Item_ID),
                new SqlParameter("@3Dfeature_ID",Feature_ID3D),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_3DfeatureDeleteSingleItem", parameters);
            return result;
        }
    }
}



