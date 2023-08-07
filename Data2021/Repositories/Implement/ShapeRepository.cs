
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
    public class ShapeRepository : Repository<TA.Data2021.Models.Shape>, IShapeRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public ShapeRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public TA.Data2021.Models.Shape GetByURLCode(string URLCode)
        {
            TA.Data2021.Models.Shape result = new TA.Data2021.Models.Shape();
            SqlParameter[] parameters =
             {
                new SqlParameter("@URLCode",URLCode),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShapeSelectItemsByURLCode", parameters);
            List<TA.Data2021.Models.Shape> list = SQLHelper.ToList<TA.Data2021.Models.Shape>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }

        public List<TA.Data2021.Models.Shape> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<TA.Data2021.Models.Shape> result = new List<TA.Data2021.Models.Shape>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShapeSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Shape>(dt);

            return result;
        }
        public List<TA.Data2021.Models.Shape> GetByIsActiveToList(bool isActive)
        {
            List<TA.Data2021.Models.Shape> result = new List<TA.Data2021.Models.Shape>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),                
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShapeSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Shape>(dt);

            return result;
        }

    }
}

