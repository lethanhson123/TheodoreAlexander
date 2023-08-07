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
    public class RelatedSkuForSpecialGroupRepository : Repository<RelatedSkuForSpecialGroup>, IRelatedSkuForSpecialGroupRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public RelatedSkuForSpecialGroupRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<RelatedSkuForSpecialGroup> GetByItem_IDToList(Guid Item_ID)
        {
            List<RelatedSkuForSpecialGroup> result = new List<RelatedSkuForSpecialGroup>();
            result = _context.Set<RelatedSkuForSpecialGroup>().Where(model => model.Item_ID == Item_ID).ToList();
            return result;
        }
        public string InsertBySQL(RelatedSkuForSpecialGroup model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@SKU",model.SKU),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RelatedSkuForSpecialGroupInsertSingleItem", parameters);
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
                    new SqlParameter("@SKU",sKU),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RelatedSkuForSpecialGroupInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(RelatedSkuForSpecialGroup model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@SKU",model.SKU),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RelatedSkuForSpecialGroupDeleteByItem_IDAndSKU", parameters);
            return result;
        }
    }
}

