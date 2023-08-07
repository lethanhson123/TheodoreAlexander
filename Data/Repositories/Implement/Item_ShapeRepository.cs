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
    public class Item_ShapeRepository : Repository<Item_Shape>, IItem_ShapeRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_ShapeRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_Shape> GetByItem_IDToList(string Item_ID)
        {
            List<Item_Shape> result = new List<Item_Shape>();
            if (!string.IsNullOrEmpty(Item_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Item_ID",Item_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ShapeSelectItemsByItem_ID", parameters);
                result = SQLHelper.ToList<Item_Shape>(dt);
            }
            return result;
        }
        public string InsertBySQL(Item_Shape item_Shape)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",item_Shape.Item_ID),
                new SqlParameter("@Shape_ID",item_Shape.Shape_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ShapeInsertSingleItem", parameters);
            return result;
        }
        public string Insert001BySQL(string sKU, string shapeName)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(sKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",sKU),
                    new SqlParameter("@ShapeName",shapeName),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ShapeInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string Item_ID, string Shape_ID)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",Item_ID),
                new SqlParameter("@Shape_ID",Shape_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ShapeDeleteSingleItemByItem_IDAndShape_ID", parameters);
            return result;
        }

    }
}

