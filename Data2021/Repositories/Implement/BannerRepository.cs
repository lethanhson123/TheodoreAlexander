
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
    public class BannerRepository : RepositoryERP<TA.Data2021.Models.Banner>, IBannerRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public BannerRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }

        public TA.Data2021.Models.Banner GetByID(int ID)
        {
            TA.Data2021.Models.Banner result = new TA.Data2021.Models.Banner();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",ID),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BannerSelectItemByID", parameters);
            List<TA.Data2021.Models.Banner> list = SQLHelper.ToList<TA.Data2021.Models.Banner>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }
    }
}

