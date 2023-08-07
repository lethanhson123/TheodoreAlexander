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
    public class Item_ColourAndFinishRepository : Repository<Item_ColourAndFinish>, IItem_ColourAndFinishRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_ColourAndFinishRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Item_ColourAndFinish> GetByItem_IDToList(string Item_ID)
        {
            List<Item_ColourAndFinish> result = new List<Item_ColourAndFinish>();
            result= _context.Set<Item_ColourAndFinish>().Where(model => model.Item_ID == Guid.Parse(Item_ID)).OrderBy(model => model.ColourAndFinishName).ToList();
            return result;
        }
        public string InsertBySQL(Item_ColourAndFinish model)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",model.Item_ID),
                new SqlParameter("@ColourAndFinish_ID",model.ColourAndFinish_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ColourAndFinishInsertSingleItem", parameters);
            return result;
        }
        public string Insert001BySQL(string sKU, string colourAndFinishName)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(sKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",sKU),
                    new SqlParameter("@ColourAndFinishName",colourAndFinishName),
                };
                result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ColourAndFinishInsertSingleItem001", parameters);
            }
            return result;
        }
        public string DeleteBySQL(string Item_ID, string ColourAndFinish_ID)
        {
            string result = AppGlobal.InitializationString;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Item_ID",Item_ID),
                new SqlParameter("@ColourAndFinish_ID",ColourAndFinish_ID),
            };
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_ColourAndFinishDeleteSingleItem", parameters);
            return result;
        }
    }
}

