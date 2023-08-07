
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
    public class LifeStyleRepository : Repository<TA.Data2021.Models.LifeStyle>, ILifeStyleRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public LifeStyleRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public TA.Data2021.Models.LifeStyle GetByURLCode(string URLCode)
        {
            TA.Data2021.Models.LifeStyle result = new TA.Data2021.Models.LifeStyle();
            SqlParameter[] parameters =
             {
                new SqlParameter("@URLCode",URLCode),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_LifeStyleSelectItemsByURLCode", parameters);
            List<TA.Data2021.Models.LifeStyle> list = SQLHelper.ToList<TA.Data2021.Models.LifeStyle>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }

        public List<TA.Data2021.Models.LifeStyle> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<TA.Data2021.Models.LifeStyle> result = new List<TA.Data2021.Models.LifeStyle>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_LifeStyleSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.LifeStyle>(dt);

            return result;
        }
        public List<TA.Data2021.Models.LifeStyle> GetByIsActiveToList(bool isActive)
        {
            List<TA.Data2021.Models.LifeStyle> result = new List<TA.Data2021.Models.LifeStyle>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),                
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_LifeStyleSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.LifeStyle>(dt);

            return result;
        }

    }
}

