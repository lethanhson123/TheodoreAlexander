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
    public class RelatedItemRepository : Repository<RelatedItem>, IRelatedItemRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public RelatedItemRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<RelatedItem> GetByItem_IDToList(Guid Item_ID)
        {
            List<RelatedItem> result = new List<RelatedItem>();
            result = _context.Set<RelatedItem>().Where(model => model.Item_ID == Item_ID).ToList();
            return result;
        }
        public string InsertBySQL(RelatedItem model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@RelatedItemSKU",model.Item02SKU),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RelatedItemInsertByItem_IDAndRelatedItemSKU", parameters);
            return result;
        }
        public string Insert001BySQL(string item01SKU, string item02SKU)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(item01SKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Item01SKU",item01SKU),
                    new SqlParameter("@Item02SKU",item02SKU),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RelatedItemInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(RelatedItem model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@RelatedItem_ID",model.RelatedItem_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RelatedItemDeleteByItem_IDAndRelatedItem_ID", parameters);
            return result;
        }
    }
}

