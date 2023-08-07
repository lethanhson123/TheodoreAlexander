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
    public class LifeStyleRepository : Repository<LifeStyle>, ILifeStyleRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public LifeStyleRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(LifeStyle model)
        {
            if (string.IsNullOrEmpty(model.URLCode))
            {
                model.URLCode = AppGlobal.SetName(model.Name);
            }
            if (string.IsNullOrEmpty(model.DisplayName))
            {
                model.DisplayName = model.Name;
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = model.Name;
            }
            if (string.IsNullOrEmpty(model.METADescription))
            {
                model.METADescription = model.Name;
            }
            if (string.IsNullOrEmpty(model.METAKeyword))
            {
                model.METAKeyword = model.Name;
            }
            if (string.IsNullOrEmpty(model.Image))
            {
                LifeStyle modelCheck = _context.Set<LifeStyle>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
                if (modelCheck != null)
                {
                    if (!string.IsNullOrEmpty(modelCheck.Image))
                    {
                        model.Image = modelCheck.Image;
                    }
                }
            }
            if (string.IsNullOrEmpty(model.ImageName))
            {
                LifeStyle modelCheck = _context.Set<LifeStyle>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
                if (modelCheck != null)
                {
                    if (!string.IsNullOrEmpty(modelCheck.ImageName))
                    {
                        model.ImageName = modelCheck.ImageName;
                    }
                }
            }
            model.ImageURL = AppGlobal.APIURLHTTPS + AppGlobal.Images + "/" + model.Image;
            model.URLImageName = AppGlobal.APIURLHTTPS + AppGlobal.Images + "/" + model.ImageName;
        }

        public override int Update(LifeStyle model)
        {
            int result = AppGlobal.InitializationNumber;
            LifeStyle existModel = GetByID(model.ID);
            if (existModel != null)
            {
                existModel = model;
                Initialization(existModel);
                _context.Set<LifeStyle>().Update(existModel);
                result = _context.SaveChanges();
            }
            return result;
        }
        public int UpdateItemsURLCode()
        {
            int result = AppGlobal.InitializationNumber;
            List<LifeStyle> list = GetAllToList().OrderBy(item => item.Name).ToList();
            int sortCode = AppGlobal.InitializationNumber;
            foreach (LifeStyle item in list)
            {
                sortCode = sortCode + 10;
                item.Name = item.Name.Trim();
                item.URLCode = AppGlobal.SetName(item.Name);
                item.SortCode = sortCode;
                Update(item);
            }
            return result;
        }
        public int UpdateBySQL(LifeStyle model)
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
                new SqlParameter("@DisplayName",model.DisplayName),
                };
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_LifeStyleUpdateSingleItemByID", parameters);
            return result;
        }
        public LifeStyle GetByID(Guid ID)
        {
            LifeStyle result = _context.Set<LifeStyle>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = new LifeStyle();
                result.ID = ID;
            }
            return result;
        }
        public LifeStyle GetByURLCode(string URLCode)
        {
            LifeStyle result = new LifeStyle();
            try
            {
                if (!string.IsNullOrEmpty(URLCode))
                {
                    result = _context.Set<LifeStyle>().AsNoTracking().FirstOrDefault(model => model.URLCode == URLCode);
                }
                if (result == null)
                {
                    result = new LifeStyle();
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        public override List<LifeStyle> GetAllToList()
        {
            List<LifeStyle> result = new List<LifeStyle>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_LifeStyleSelectAllItems");
            result = SQLHelper.ToList<LifeStyle>(dt);
            return result;
        }
        public List<LifeStyle> GetByIsActiveToList(bool isActive)
        {
            List<LifeStyle> result = new List<LifeStyle>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_LifeStyleSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<LifeStyle>(dt);

            return result;
        }
        public List<LifeStyle> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<LifeStyle> result = new List<LifeStyle>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_LifeStyleSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<LifeStyle>(dt);

            return result;
        }
        public List<LifeStyle> GetBySearchStringToList(string searchString)
        {
            List<LifeStyle> result = new List<LifeStyle>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_LifeStyleSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<LifeStyle>(dt);
            }
            return result;
        }

    }
}

