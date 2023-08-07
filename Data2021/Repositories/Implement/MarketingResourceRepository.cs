
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
    public class MarketingResourceRepository : RepositoryERP<TA.Data2021.Models.MarketingResource>, IMarketingResourceRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public MarketingResourceRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<TA.Data2021.Models.MarketingResource> GetByParentIDAndActiveToList(int parentID, bool active)
        {
            List<TA.Data2021.Models.MarketingResource> result = new List<TA.Data2021.Models.MarketingResource>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID",parentID),
                new SqlParameter("@Active",active),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceSelectItemsByParentIDAndActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResource>(dt);
            return result;
        }
        public List<TA.Data2021.Models.MarketingResource> GetByActiveToList(bool active)
        {
            List<TA.Data2021.Models.MarketingResource> result = new List<TA.Data2021.Models.MarketingResource>();
            SqlParameter[] parameters =
            {                
                new SqlParameter("@Active",active),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceSelectItemsByActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResource>(dt);
            return result;
        }
        public List<TA.Data2021.Models.MarketingResource> GetByActiveAndIsUSShowToList(bool active, bool isUSShow)
        {
            List<TA.Data2021.Models.MarketingResource> result = new List<TA.Data2021.Models.MarketingResource>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Active",active),
                new SqlParameter("@IsUSShow",isUSShow),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceSelectItemsByActiveAndIsUSShow", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResource>(dt);
            return result;
        }
        public List<TA.Data2021.Models.MarketingResource> GetByActiveAndIsInternationalShowToList(bool active, bool isInternationalShow)
        {
            List<TA.Data2021.Models.MarketingResource> result = new List<TA.Data2021.Models.MarketingResource>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Active",active),
                new SqlParameter("@IsInternationalShow",isInternationalShow),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceSelectItemsByActiveAndIsInternationalShow", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResource>(dt);
            return result;
        }
    }
}

