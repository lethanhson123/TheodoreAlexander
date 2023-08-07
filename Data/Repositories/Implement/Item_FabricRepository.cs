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
    public class Item_FabricRepository : Repository<Item_Fabric>, IItem_FabricRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_FabricRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_Fabric> GetByItemIDToList(string ItemID)
        {           
            List<Item_Fabric> result = new List<Item_Fabric>();
            result = _context.Set<Item_Fabric>().Where(model => model.ItemID == Guid.Parse(ItemID)).OrderBy(model => model.FabricCode).ToList();
            return result;
        }
        public string InsertBySQL(Item_Fabric model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {                
                new SqlParameter("@ItemID",model.ItemID),
                new SqlParameter("@FabricCode",model.FabricCode),                
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_FabricInsertSingleItemByID", parameters);
            return result;
        }
        public string Insert001BySQL(string sKU, string fabricCode)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(sKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",sKU),
                    new SqlParameter("@FabricCode",fabricCode),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_FabricInsertSingleItem001", parameters);
            }
            return result;
        }
        public string UpdateBySQL(Item_Fabric model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",model.ID),
                new SqlParameter("@Note",model.Note),
                new SqlParameter("@IsActive",model.IsActive),
                };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_FabricUpdateSingleItemByID", parameters);
            return result;
        }
        public string DeleteBySQL(string ID)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",ID),                
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_FabricDeleteSingleItemByID", parameters);
            return result;
        }
    }
}

