
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
    public class MarketingResourceCategoryRepository : RepositoryERP<TA.Data2021.Models.MarketingResourceCategory>, IMarketingResourceCategoryRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public MarketingResourceCategoryRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<TA.Data2021.Models.MarketingResourceCategory> GetByActiveToList(bool active)
        {
            List<TA.Data2021.Models.MarketingResourceCategory> result = new List<TA.Data2021.Models.MarketingResourceCategory>();
            SqlParameter[] parameters =
            {                
                new SqlParameter("@Active",active),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceCategorySelectItemsByActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResourceCategory>(dt);
            return result;
        }
        public List<TA.Data2021.Models.MarketingResourceCategory> GetByActiveAndIsUSShowToList(bool active, bool isUSShow)
        {
            List<TA.Data2021.Models.MarketingResourceCategory> result = new List<TA.Data2021.Models.MarketingResourceCategory>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Active",active),
                new SqlParameter("@IsUSShow",isUSShow),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceCategorySelectItemsByActiveAndIsUSShow", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResourceCategory>(dt);
            return result;
        }
        public List<TA.Data2021.Models.MarketingResourceCategory> GetByActiveAndIsInternationalShowToList(bool active, bool isInternationalShow)
        {
            List<TA.Data2021.Models.MarketingResourceCategory> result = new List<TA.Data2021.Models.MarketingResourceCategory>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Active",active),
                new SqlParameter("@IsInternationalShow",isInternationalShow),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceCategorySelectItemsByActiveAndIsInternationalShow", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.MarketingResourceCategory>(dt);
            return result;
        }
        public int UpdateBySQL(MarketingResourceCategory model)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",model.ID),               
            };
            string mes = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_MarketingResourceCategoryUpdateSingleItemByID", parameters);
            return result;
        }
    }
}

