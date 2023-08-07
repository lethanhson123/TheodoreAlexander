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
    public class Item_ProcessAndTechniqueRepository : Repository<Item_ProcessAndTechnique>, IItem_ProcessAndTechniqueRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_ProcessAndTechniqueRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_ProcessAndTechnique> GetByItem_IDToList(string Item_ID)
        {
            List<Item_ProcessAndTechnique> result = new List<Item_ProcessAndTechnique>();
            result= _context.Set<Item_ProcessAndTechnique>().Where(model => model.Item_ID == Guid.Parse(Item_ID)).OrderBy(model => model.ProcessAndTechniqueName).ToList();
            return result;
        }
        public string InsertBySQL(Item_ProcessAndTechnique model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@ProcessAndTechnique_ID",model.ProcessAndTechnique_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ProcessAndTechniqueInsertSingleItem", parameters);
            return result;
        }
        public string Insert001BySQL(string sKU, string processAndTechniqueName)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(sKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",sKU),
                    new SqlParameter("@ProcessAndTechniqueName",processAndTechniqueName),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ProcessAndTechniqueInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string Item_ID, string ProcessAndTechnique_ID)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",Item_ID),
                new SqlParameter("@ProcessAndTechnique_ID",ProcessAndTechnique_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ProcessAndTechniqueDeleteSingleItem", parameters);
            return result;
        }
    }
}

