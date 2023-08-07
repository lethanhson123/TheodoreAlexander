
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
    public class TypeRepository : Repository<TA.Data2021.Models.Type>, ITypeRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public TypeRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public TA.Data2021.Models.Type GetByID(string ID)
        {
            TA.Data2021.Models.Type result = new TA.Data2021.Models.Type();
            if (string.IsNullOrEmpty(ID))
            {
                ID = AppGlobal.InitializationGUICodeEmpty;
            }
            SqlParameter[] parameters =
             {
                new SqlParameter("@ID",ID),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeSelectItemsByID", parameters);
            List<TA.Data2021.Models.Type> list = SQLHelper.ToList<TA.Data2021.Models.Type>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }
        public TA.Data2021.Models.Type GetByURLCode(string URLCode)
        {
            TA.Data2021.Models.Type result = new TA.Data2021.Models.Type();
            SqlParameter[] parameters =
             {
                new SqlParameter("@URLCode",URLCode),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeSelectItemsByURLCode", parameters);
            List<TA.Data2021.Models.Type> list = SQLHelper.ToList<TA.Data2021.Models.Type>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }

        public List<TA.Data2021.Models.Type> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<TA.Data2021.Models.Type> result = new List<TA.Data2021.Models.Type>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Type>(dt);

            return result;
        }
        public List<TA.Data2021.Models.Type> GetByIsActiveToList(bool isActive)
        {
            List<TA.Data2021.Models.Type> result = new List<TA.Data2021.Models.Type>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),                
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Type>(dt);

            return result;
        }

    }
}

