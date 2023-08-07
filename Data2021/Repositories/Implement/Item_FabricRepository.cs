
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data2021.Models;
using TA.Helpers2021;
using TA.Data2021.Repositories;

namespace TA.Data2021.Repositories
{
    public class Item_FabricRepository : Repository<TA.Data2021.Models.Item_Fabric>, IItem_FabricRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Item_FabricRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }

        public List<TA.Data2021.Models.Item_Fabric> GetByItemIDAndIsActiveToList(string ItemID, bool isActive)
        {
            List<TA.Data2021.Models.Item_Fabric> result = new List<TA.Data2021.Models.Item_Fabric>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ItemID",ItemID),
                new SqlParameter("@IsActive",isActive),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Item_FabricSelectItemsByItemIDAndIsActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Item_Fabric>(dt);
            return result;
        }
    }
}

