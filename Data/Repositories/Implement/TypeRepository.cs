using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class TypeRepository : Repository<TA.Data.Models.Type>, ITypeRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public TypeRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(TA.Data.Models.Type model)
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
                TA.Data.Models.Type modelCheck = _context.Set<TA.Data.Models.Type>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
                TA.Data.Models.Type modelCheck = _context.Set<TA.Data.Models.Type>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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

        
        public override int Update(TA.Data.Models.Type model)
        {
            int result = AppGlobal.InitializationNumber;
            TA.Data.Models.Type existModel = GetByID(model.ID);
            if (existModel != null)
            {
                existModel.Name = model.Name;                
                existModel.SortCode = model.SortCode;
                existModel.IsEnabledOnWeb = model.IsEnabledOnWeb;
                existModel.IsActive = model.IsActive;
                existModel.IsStory = model.IsStory;
                existModel.URLCode = model.URLCode;
                existModel.Description = model.Description;
                existModel.METAKeyword = model.METAKeyword;
                existModel.METADescription = model.METADescription;
                existModel.Image = model.Image;
                existModel.ImageName = model.ImageName;
                Initialization(existModel);
                _context.Set<TA.Data.Models.Type>().Update(existModel);
                result = _context.SaveChanges();
            }
            return result;
        }
        public int UpdateItemsURLCode()
        {
            int result = AppGlobal.InitializationNumber;
            List<TA.Data.Models.Type> list = GetAllToList().OrderBy(item => item.Name).ToList();
            int sortCode = AppGlobal.InitializationNumber;

            foreach (TA.Data.Models.Type item in list)
            {
                sortCode = sortCode + 10;
                if (item.RoomAndUsage_ID != null)
                {
                    RoomAndUsage roomAndUsage = _context.Set<RoomAndUsage>().AsNoTracking().FirstOrDefault(model => model.ID == item.RoomAndUsage_ID);
                    if (roomAndUsage != null)
                    {
                        item.GroupCode = roomAndUsage.SortCode;
                    }
                }
                item.SortCode = sortCode;
                item.Name = item.Name.Trim();
                item.URLCode = AppGlobal.SetName(item.Name);
                Update(item);
            }
            return result;
        }
        public int UpdateBySQL(TA.Data.Models.Type model)
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
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_TypeUpdateSingleItemByID", parameters);
            return result;
        }
        public TA.Data.Models.Type GetByID(Guid ID)
        {
            TA.Data.Models.Type result = _context.Set<TA.Data.Models.Type>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = new TA.Data.Models.Type();
                result.ID = ID;
            }
            return result;
        }
        public TA.Data.Models.Type GetByURLCode(string URLCode)
        {
            TA.Data.Models.Type result = new TA.Data.Models.Type();
            if (!string.IsNullOrEmpty(URLCode))
            {
                result = _context.Set<TA.Data.Models.Type>().AsNoTracking().FirstOrDefault(model => model.URLCode == URLCode);
            }
            if (result == null)
            {
                result = new TA.Data.Models.Type();
            }
            return result;
        }
        public override List<TA.Data.Models.Type> GetAllToList()
        {
            List<TA.Data.Models.Type> result = new List<TA.Data.Models.Type>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeSelectAllItems");
            result = SQLHelper.ToList<TA.Data.Models.Type>(dt);
            return result;
        }
        public List<TypeDataTransfer> GetDataTransferAllToList()
        {
            List<TypeDataTransfer> result = new List<TypeDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeDataTransferSelectAllItems");
            result = SQLHelper.ToList<TypeDataTransfer>(dt);
            return result;
        }
        public List<TA.Data.Models.Type> GetByIsEnabledOnWebToList(bool isEnabledOnWeb)
        {
            List<TA.Data.Models.Type> result = new List<TA.Data.Models.Type>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsEnabledOnWeb",isEnabledOnWeb),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeSelectItemsByIsEnabledOnWeb", parameters);
            result = SQLHelper.ToList<TA.Data.Models.Type>(dt);

            return result;
        }
        public List<TA.Data.Models.Type> GetByIsActiveToList(bool isActive)
        {
            List<TA.Data.Models.Type> result = new List<TA.Data.Models.Type>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<TA.Data.Models.Type>(dt);

            return result;
        }
        public List<TA.Data.Models.Type> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<TA.Data.Models.Type> result = new List<TA.Data.Models.Type>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<TA.Data.Models.Type>(dt);

            return result;
        }
        public List<TA.Data.Models.Type> GetBySearchStringToList(string searchString)
        {
            List<TA.Data.Models.Type> result = new List<TA.Data.Models.Type>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                searchString = searchString.Trim();
                SqlParameter[] parameters =
                {
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<TA.Data.Models.Type>(dt);
            }
            return result;
        }
        public List<TypeDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            List<TypeDataTransfer> result = new List<TypeDataTransfer>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetDataTransferAllToList();
            }
            else
            {
                searchString = searchString.Trim();
                SqlParameter[] parameters =
                {
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_TypeDataTransferSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<TypeDataTransfer>(dt);
            }
            return result;
        }
    }
}

