
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
    public class MarketingResourceDetailRepository : RepositoryERP<TA.Data2021.Models.MarketingResourceDetail>, IMarketingResourceDetailRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public MarketingResourceDetailRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<TA.Data2021.Models.MarketingResourceDetail> GetByParentIDAndActiveToList(int parentID, bool active)
        {
            List<TA.Data2021.Models.MarketingResourceDetail> result = new List<TA.Data2021.Models.MarketingResourceDetail>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID",parentID),
                new SqlParameter("@Active",active),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceDetailSelectItemsByParentIDAndActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResourceDetail>(dt);
            return result;
        }
        public List<TA.Data2021.Models.MarketingResourceDetail> GetByActiveToList(bool active)
        {
            List<TA.Data2021.Models.MarketingResourceDetail> result = new List<TA.Data2021.Models.MarketingResourceDetail>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Active",active),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceDetailSelectItemsByActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResourceDetail>(dt);
            return result;
        }
        public List<TA.Data2021.Models.MarketingResourceDetail> GetByActiveAndIsUSShowToList(bool active, bool isUSShow)
        {
            List<TA.Data2021.Models.MarketingResourceDetail> result = new List<TA.Data2021.Models.MarketingResourceDetail>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Active",active),
                new SqlParameter("@IsUSShow",isUSShow),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceDetailSelectItemsByActiveAndIsUSShow", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResourceDetail>(dt);
            return result;
        }
        public List<TA.Data2021.Models.MarketingResourceDetail> GetByActiveAndIsInternationalShowToList(bool active, bool isInternationalShow)
        {
            List<TA.Data2021.Models.MarketingResourceDetail> result = new List<TA.Data2021.Models.MarketingResourceDetail>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Active",active),
                new SqlParameter("@IsInternationalShow",isInternationalShow),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceDetailSelectItemsByActiveAndIsInternationalShow", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResourceDetail>(dt);
            return result;
        }
    }
}

