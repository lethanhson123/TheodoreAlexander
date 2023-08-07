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
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public BrandRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(Brand model)
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
                Brand modelCheck = _context.Set<Brand>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
                Brand modelCheck = _context.Set<Brand>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
        public override int Update(Brand model)
        {
            int result = AppGlobal.InitializationNumber;
            Brand existModel = GetByID(model.ID);
            if (existModel != null)
            {
                existModel = model;
                Initialization(existModel);
                _context.Set<Brand>().Update(existModel);
                result = _context.SaveChanges();
            }
            return result;
        }
        public int UpdateItemsURLCode()
        {
            int result = AppGlobal.InitializationNumber;
            List<Brand> list = GetAllToList().OrderBy(item => item.Name).ToList();
            int sortCode = AppGlobal.InitializationNumber;
            foreach (Brand item in list)
            {
                sortCode = sortCode + 1000;
                item.Name = item.Name.Trim();
                item.URLCode = AppGlobal.SetName(item.Name);
                item.SortCode = sortCode;
                Update(item);
            }
            return result;
        }
        public int UpdateBySQL(Brand model)
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
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BrandUpdateSingleItemByID", parameters);
            return result;
        }
        public Brand GetByID(Guid ID)
        {
            Brand result = _context.Set<Brand>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = new Brand();
                result.ID = ID;
            }
            return result;
        }
        public Brand GetByURLCode(string URLCode)
        {
            Brand result = new Brand();
            if (!string.IsNullOrEmpty(URLCode))
            {
                result = _context.Set<Brand>().AsNoTracking().FirstOrDefault(model => model.URLCode == URLCode);
            }
            if (result == null)
            {
                result = new Brand();
            }
            return result;
        }

        public override List<Brand> GetAllToList()
        {
            List<Brand> result = new List<Brand>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BrandSelectAllItems");
            result = SQLHelper.ToList<Brand>(dt);
            return result;
        }
        public List<Brand> GetByIsActiveToList(bool isActive)
        {
            List<Brand> result = new List<Brand>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BrandSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<Brand>(dt);

            return result;
        }
        public List<Brand> GetBySearchStringToList(string searchString)
        {
            List<Brand> result = new List<Brand>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_BrandSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<Brand>(dt);
            }
            return result;
        }

    }
}

