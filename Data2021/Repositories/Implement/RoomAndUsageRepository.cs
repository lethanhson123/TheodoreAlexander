
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
    public class RoomAndUsageRepository : Repository<TA.Data2021.Models.RoomAndUsage>, IRoomAndUsageRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public RoomAndUsageRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public TA.Data2021.Models.RoomAndUsage GetByID(string ID)
        {
            TA.Data2021.Models.RoomAndUsage result = new TA.Data2021.Models.RoomAndUsage();
            SqlParameter[] parameters =
             {
                new SqlParameter("@ID",ID),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RoomAndUsageSelectItemsByID", parameters);
            List<TA.Data2021.Models.RoomAndUsage> list = SQLHelper.ToList<TA.Data2021.Models.RoomAndUsage>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }
        public TA.Data2021.Models.RoomAndUsage GetByURLCode(string URLCode)
        {
            TA.Data2021.Models.RoomAndUsage result = new TA.Data2021.Models.RoomAndUsage();
            SqlParameter[] parameters =
             {
                new SqlParameter("@URLCode",URLCode),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RoomAndUsageSelectItemsByURLCode", parameters);
            List<TA.Data2021.Models.RoomAndUsage> list = SQLHelper.ToList<TA.Data2021.Models.RoomAndUsage>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }

        public List<TA.Data2021.Models.RoomAndUsage> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<TA.Data2021.Models.RoomAndUsage> result = new List<TA.Data2021.Models.RoomAndUsage>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RoomAndUsageSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.RoomAndUsage>(dt);

            return result;
        }
        public List<TA.Data2021.Models.RoomAndUsage> GetByIsActiveToList(bool isActive)
        {
            List<TA.Data2021.Models.RoomAndUsage> result = new List<TA.Data2021.Models.RoomAndUsage>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),                
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RoomAndUsageSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.RoomAndUsage>(dt);

            return result;
        }

    }
}

