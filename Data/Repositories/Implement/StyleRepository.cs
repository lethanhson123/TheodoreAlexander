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
    public class StyleRepository : Repository<Style>, IStyleRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public StyleRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(Style model)
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
                Style modelCheck = _context.Set<Style>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
                Style modelCheck = _context.Set<Style>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
       
        public override int Update(Style model)
        {
            int result = AppGlobal.InitializationNumber;
            Style existModel = GetByID(model.ID);
            if (existModel != null)
            {
                existModel = model;
                Initialization(existModel);
                _context.Set<Style>().Update(existModel);
                result = _context.SaveChanges();
            }
            return result;
        }
        public int UpdateItemsURLCode()
        {
            int result = AppGlobal.InitializationNumber;
            List<Style> list = GetAllToList().OrderBy(item => item.Name).ToList();
            int sortCode = AppGlobal.InitializationNumber;
            foreach (Style item in list)
            {
                sortCode = sortCode + 10;
                item.Name = item.Name.Trim();                
                item.SortCode = sortCode;
                Update(item);
            }
            return result;
        }
        public int UpdateBySQL(Style model)
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
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_StyleUpdateSingleItemByID", parameters);
            return result;
        }        
        public Style GetByID(Guid ID)
        {
            Style result = _context.Set<Style>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = new Style();
                result.ID = ID;
            }
            return result;
        }
        public Style GetByURLCode(string URLCode)
        {
            Style result = new Style();
            if (!string.IsNullOrEmpty(URLCode))
            {
                result = _context.Set<Style>().AsNoTracking().FirstOrDefault(model => model.URLCode == URLCode);
            }
            if (result == null)
            {
                result = new Style();
            }
            return result;
        }
        public override List<Style> GetAllToList()
        {
            List<Style> result = new List<Style>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StyleSelectAllItems");
            result = SQLHelper.ToList<Style>(dt);
            return result;
        }
        public List<Style> GetByIsActiveToList(bool isActive)
        {
            List<Style> result = new List<Style>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StyleSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<Style>(dt);

            return result;
        }
        public List<Style> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<Style> result = new List<Style>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StyleSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<Style>(dt);

            return result;
        }
        public List<Style> GetBySearchStringToList(string searchString)
        {
            List<Style> result = new List<Style>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StyleSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<Style>(dt);
            }
            return result;
        }
       
    }
}

