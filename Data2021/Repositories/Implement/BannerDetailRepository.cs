
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data2021.Models;
using TA.Helpers2021;
using TA.Data2021.Repositories;
using System.Threading.Tasks;

namespace TA.Data2021.Repositories
{
    public class BannerDetailRepository : RepositoryERP<TA.Data2021.Models.BannerDetail>, IBannerDetailRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public BannerDetailRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }

        public List<TA.Data2021.Models.BannerDetail> GetByParentIDAndActiveAndIsUSShowToList(int parentID, bool active, bool isUSShow)
        {
            List<TA.Data2021.Models.BannerDetail> result = new List<TA.Data2021.Models.BannerDetail>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID",parentID),
                new SqlParameter("@Active",active),
                new SqlParameter("@IsUSShow",isUSShow),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BannerDetailSelectItemsByParentIDAndActiveAndIsUSShow", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.BannerDetail>(dt);
            return result;
        }
        public List<TA.Data2021.Models.BannerDetail> GetByParentIDAndActiveAndIsInternationalShowToList(int parentID, bool active, bool isInternationalShow)
        {
            List<TA.Data2021.Models.BannerDetail> result = new List<TA.Data2021.Models.BannerDetail>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID",parentID),
                new SqlParameter("@Active",active),
                new SqlParameter("@IsInternationalShow",isInternationalShow),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BannerDetailSelectItemsByParentIDAndActiveAndIsInternationalShow", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.BannerDetail>(dt);
            return result;
        }
    }
}

