using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class DesignerRepository : Repository<Designer>, IDesignerRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public DesignerRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(Designer model)
        {
            if (string.IsNullOrEmpty(model.URLCode))
            {
                model.URLCode = AppGlobal.SetName(model.Name);
            }
            if (string.IsNullOrEmpty(model.METAKeyword))
            {
                model.METAKeyword = model.Name;
            }
            if (string.IsNullOrEmpty(model.METADescription))
            {
                model.METADescription = model.Description;
            }
            if (string.IsNullOrEmpty(model.DisplayName))
            {
                model.DisplayName = model.Name;
            }
            TA.Data.Models.Designer modelCheck = _context.Set<TA.Data.Models.Designer>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
            if (string.IsNullOrEmpty(model.ImageIcon))
            {
                if (modelCheck != null)
                {
                    if (!string.IsNullOrEmpty(modelCheck.ImageIcon))
                    {
                        model.ImageIcon = modelCheck.ImageIcon;
                    }
                }
            }
            if (string.IsNullOrEmpty(model.ImageMain))
            {
                if (modelCheck != null)
                {
                    if (!string.IsNullOrEmpty(modelCheck.ImageMain))
                    {
                        model.ImageMain = modelCheck.ImageMain;
                    }
                }
            }
            if (string.IsNullOrEmpty(model.ImageBackground))
            {
                if (modelCheck != null)
                {
                    if (!string.IsNullOrEmpty(modelCheck.ImageBackground))
                    {
                        model.ImageBackground = modelCheck.ImageBackground;
                    }
                }
            }
            model.URLImageIcon = AppGlobal.APIURLHTTPS + AppGlobal.Images + "/" + model.ImageIcon;
            model.URLImageMain = AppGlobal.APIURLHTTPS + AppGlobal.Images + "/" + model.ImageMain;
            model.URLImageBackground = AppGlobal.APIURLHTTPS + AppGlobal.Images + "/" + model.ImageBackground;
        }
        public override int Update(Designer model)
        {
            int result = AppGlobal.InitializationNumber;
            Designer existModel = GetByID(model.ID);
            if (existModel != null)
            {
                existModel = model;
                Initialization(existModel);
                _context.Set<Designer>().Update(existModel);
                result = _context.SaveChanges();
            }
            return result;
        }
        public int UpdateBySQL(Designer model)
        {
            int result = AppGlobal.InitializationNumber;
            Initialization(model);
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",model.ID),
                new SqlParameter("@URLCode",model.URLCode),
                new SqlParameter("@URL",model.URL),
                new SqlParameter("@GroupCode",model.GroupCode),
                new SqlParameter("@SortCode",model.SortCode),
                new SqlParameter("@ItemCount",model.ItemCount),
                new SqlParameter("@IsActive",model.IsActive),
                new SqlParameter("@Description",model.Description),
                new SqlParameter("@METAKeyword",model.METAKeyword),
                new SqlParameter("@METADescription",model.METADescription),
                new SqlParameter("@Title001",model.Title001),
                new SqlParameter("@Title002",model.Title002),
                new SqlParameter("@DisplayName",model.DisplayName),
            };
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_DesignerUpdateSingleItemByID", parameters);
            return result;
        }
        public Designer GetByID(Guid ID)
        {
            Designer result = _context.Set<Designer>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = new Designer();
                result.ID = ID;
            }
            return result;
        }

        public override List<Designer> GetAllToList()
        {
            List<Designer> result = new List<Designer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_DesignerSelectAllItems");
            result = SQLHelper.ToList<Designer>(dt);
            return result;
        }
        public List<Designer> GetByIsActiveToList(bool isActive)
        {
            List<Designer> result = new List<Designer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_DesignerSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<Designer>(dt);

            return result;
        }
        public List<Designer> GetByIsActive001ToList(bool isActive)
        {
            List<Designer> result = new List<Designer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_DesignerSelectItemByIsActive001", parameters);
            result = SQLHelper.ToList<Designer>(dt);

            return result;
        }
        public List<Designer> GetBySearchStringToList(string searchString)
        {
            List<Designer> result = new List<Designer>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_DesignerSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<Designer>(dt);
            }
            return result;
        }
        public Designer GetByRandom()
        {
            Designer result = new Designer();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_DesignerSelectItemByRandom");
            List<Designer> list = SQLHelper.ToList<Designer>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }
        public int UpdateItemsURLCode()
        {
            int result = AppGlobal.InitializationNumber;
            List<Designer> list = GetAllToList().OrderBy(item => item.Name).ToList();
            int sortCode = AppGlobal.InitializationNumber;
            foreach (Designer item in list)
            {
                sortCode = sortCode + 10;
                item.Name = item.Name.Trim();
                item.URLCode = AppGlobal.SetName(item.Name);
                item.SortCode = sortCode;
                Update(item);
            }
            return result;
        }
    }
}

