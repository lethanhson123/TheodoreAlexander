
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
    public class DesignerRepository : Repository<TA.Data2021.Models.Designer>, IDesignerRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public DesignerRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public TA.Data2021.Models.Designer GetByURLCode(string URLCode)
        {
            TA.Data2021.Models.Designer result = new TA.Data2021.Models.Designer();
            SqlParameter[] parameters =
             {
                new SqlParameter("@URLCode",URLCode),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_DesignerSelectItemsByURLCode", parameters);
            List<TA.Data2021.Models.Designer> list = SQLHelper.ToList<TA.Data2021.Models.Designer>(dt);
            if (list.Count > 0)
            {
                result = list[0];
                if (!string.IsNullOrEmpty(result.ImageIcon))
                {
                    result.URLImageIcon = AppGlobal.DomainURLLIVE + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + result.ImageIcon;
                }
                if (!string.IsNullOrEmpty(result.ImageMain))
                {
                    result.URLImageMain = AppGlobal.DomainURLLIVE + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + result.ImageMain;
                }
                if (!string.IsNullOrEmpty(result.ImageBackground))
                {
                    result.URLImageBackground = AppGlobal.DomainURLLIVE + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + result.ImageBackground;
                }
            }
            return result;
        }
        public List<TA.Data2021.Models.Designer> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<TA.Data2021.Models.Designer> result = new List<TA.Data2021.Models.Designer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BrandSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Designer>(dt);
            for (int i = 0; i < result.Count; i++)
            {
                if (!string.IsNullOrEmpty(result[i].ImageIcon))
                {
                    result[i].URLImageIcon = AppGlobal.DomainURLLIVE + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + result[i].ImageIcon;
                }
                if (!string.IsNullOrEmpty(result[i].ImageMain))
                {
                    result[i].URLImageMain = AppGlobal.DomainURLLIVE + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + result[i].ImageMain;
                }
                if (!string.IsNullOrEmpty(result[i].ImageBackground))
                {
                    result[i].URLImageBackground = AppGlobal.DomainURLLIVE + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + result[i].ImageBackground;
                }
            }
            return result;
        }

        public List<TA.Data2021.Models.Designer> GetByIsActiveToList(bool isActive)
        {
            List<TA.Data2021.Models.Designer> result = new List<TA.Data2021.Models.Designer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_DesignerSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Designer>(dt);
            for (int i = 0; i < result.Count; i++)
            {
                if (!string.IsNullOrEmpty(result[i].ImageIcon))
                {
                    result[i].URLImageIcon = AppGlobal.DomainURLLIVE + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + result[i].ImageIcon;
                }
                if (!string.IsNullOrEmpty(result[i].ImageMain))
                {
                    result[i].URLImageMain = AppGlobal.DomainURLLIVE + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + result[i].ImageMain;
                }
                if (!string.IsNullOrEmpty(result[i].ImageBackground))
                {
                    result[i].URLImageBackground = AppGlobal.DomainURLLIVE + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + result[i].ImageBackground;
                }
            }
            return result;
        }

    }
}

