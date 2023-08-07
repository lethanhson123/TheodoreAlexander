
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
    public class BrandRepository : Repository<TA.Data2021.Models.Brand>, IBrandRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public BrandRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public TA.Data2021.Models.Brand GetByURLCode(string URLCode)
        {
            TA.Data2021.Models.Brand result = new TA.Data2021.Models.Brand();
            SqlParameter[] parameters =
             {
                new SqlParameter("@URLCode",URLCode),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BrandSelectItemsByURLCode", parameters);
            List<TA.Data2021.Models.Brand> list = SQLHelper.ToList<TA.Data2021.Models.Brand>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }

        public List<TA.Data2021.Models.Brand> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<TA.Data2021.Models.Brand> result = new List<TA.Data2021.Models.Brand>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BrandSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Brand>(dt);

            return result;
        }
        public List<TA.Data2021.Models.Brand> GetByIsActiveToList(bool isActive)
        {
            List<TA.Data2021.Models.Brand> result = new List<TA.Data2021.Models.Brand>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),                
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BrandSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Brand>(dt);

            return result;
        }

    }
}

