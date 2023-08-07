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
    public class ShapeRepository : Repository<Shape>, IShapeRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public ShapeRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(Shape model)
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
                Shape modelCheck = _context.Set<Shape>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
                Shape modelCheck = _context.Set<Shape>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
        
        public override int Update(Shape model)
        {
            int result = AppGlobal.InitializationNumber;
            Shape existModel = GetByID(model.ID);
            if (existModel != null)
            {
                existModel = model;
                Initialization(existModel);
                _context.Set<Shape>().Update(existModel);
                result = _context.SaveChanges();
            }
            return result;
        }
        public int UpdateItemsURLCode()
        {
            int result = AppGlobal.InitializationNumber;
            List<Shape> list = GetAllToList().OrderBy(item => item.Name).ToList();
            int sortCode = AppGlobal.InitializationNumber;
            foreach (Shape item in list)
            {
                sortCode = sortCode + 10;
                item.Name = item.Name.Trim();
                item.URLCode = AppGlobal.SetName(item.Name);
                item.SortCode = sortCode;
                Update(item);
            }
            return result;
        }
        public int UpdateBySQL(Shape model)
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
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_ShapeUpdateSingleItemByID", parameters);
            return result;
        }
        public Shape GetByID(Guid ID)
        {
            Shape result = _context.Set<Shape>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = new Shape();
                result.ID = ID;
            }
            return result;
        }
        public Shape GetByURLCode(string URLCode)
        {
            Shape result = new Shape();
            if (!string.IsNullOrEmpty(URLCode))
            {
                result = _context.Set<Shape>().AsNoTracking().FirstOrDefault(model => model.URLCode == URLCode);
            }
            if (result == null)
            {
                result = new Shape();
            }
            return result;
        }
        public override List<Shape> GetAllToList()
        {
            List<Shape> result = new List<Shape>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShapeSelectAllItems");
            result = SQLHelper.ToList<Shape>(dt);
            return result;
        }
        public List<Shape> GetByIsActiveToList(bool isActive)
        {
            List<Shape> result = new List<Shape>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShapeSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<Shape>(dt);

            return result;
        }
        public List<Shape> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<Shape> result = new List<Shape>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShapeSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<Shape>(dt);

            return result;
        }
        public List<Shape> GetBySearchStringToList(string searchString)
        {
            List<Shape> result = new List<Shape>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShapeSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<Shape>(dt);
            }
            return result;
        }
        
    }
}

