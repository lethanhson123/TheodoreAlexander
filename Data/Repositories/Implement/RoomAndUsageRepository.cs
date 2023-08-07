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
    public class RoomAndUsageRepository : Repository<RoomAndUsage>, IRoomAndUsageRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public RoomAndUsageRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(RoomAndUsage model)
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
                RoomAndUsage modelCheck = _context.Set<RoomAndUsage>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
                RoomAndUsage modelCheck = _context.Set<RoomAndUsage>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
        public override int Update(RoomAndUsage model)
        {
            int result = AppGlobal.InitializationNumber;
            RoomAndUsage existModel = GetByID(model.ID);
            if (existModel != null)
            {
                existModel = model;
                Initialization(existModel);
                _context.Set<RoomAndUsage>().Update(existModel);
                result = _context.SaveChanges();
            }
            return result;
        }
        public int UpdateItemsURLCode()
        {
            int result = AppGlobal.InitializationNumber;
            List<RoomAndUsage> list = GetAllToList().OrderBy(item => item.Name).ToList();
            int sortCode = AppGlobal.InitializationNumber;
            foreach (RoomAndUsage item in list)
            {
                sortCode = sortCode + 1000;
                item.Name = item.Name.Trim();
                item.URLCode = AppGlobal.SetName(item.Name);
                item.SortCode = sortCode;
                Update(item);
            }
            return result;
        }
        public int UpdateBySQL(RoomAndUsage model)
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
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_RoomAndUsageUpdateSingleItemByID", parameters);
            return result;
        }
        public RoomAndUsage GetByID(Guid ID)
        {
            RoomAndUsage result = _context.Set<RoomAndUsage>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = new RoomAndUsage();
                result.ID = ID;
            }
            return result;
        }
        public RoomAndUsage GetByURLCode(string URLCode)
        {
            RoomAndUsage result = new RoomAndUsage();
            if (!string.IsNullOrEmpty(URLCode))
            {
                result = _context.Set<RoomAndUsage>().AsNoTracking().FirstOrDefault(model => model.URLCode == URLCode);
            }
            if (result == null)
            {
                result = new RoomAndUsage();
            }
            return result;
        }
        public override List<RoomAndUsage> GetAllToList()
        {
            List<RoomAndUsage> result = new List<RoomAndUsage>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RoomAndUsageSelectAllItems");
            result = SQLHelper.ToList<RoomAndUsage>(dt);
            return result;
        }
        public List<RoomAndUsage> GetByIsActiveToList(bool isActive)
        {
            List<RoomAndUsage> result = new List<RoomAndUsage>();
            SqlParameter[] parameters =
           {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RoomAndUsageSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<RoomAndUsage>(dt);
            return result;
        }
        public List<RoomAndUsage> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<RoomAndUsage> result = new List<RoomAndUsage>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RoomAndUsageSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<RoomAndUsage>(dt);

            return result;
        }
        public List<RoomAndUsage> GetBySearchStringToList(string searchString)
        {
            List<RoomAndUsage> result = new List<RoomAndUsage>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_RoomAndUsageSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<RoomAndUsage>(dt);
            }
            return result;
        }
       
    }
}

