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
    public class CollectionRepository : Repository<Collection>, ICollectionRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public CollectionRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(Collection model)
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
                Collection modelCheck = _context.Set<Collection>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
                Collection modelCheck = _context.Set<Collection>().AsNoTracking().FirstOrDefault(item => item.ID == model.ID);
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
        public override int Update(Collection model)
        {
            int result = AppGlobal.InitializationNumber;
            Collection existModel = GetByID(model.ID);
            if (existModel != null)
            {
                existModel.Name = model.Name;
                existModel.DisplayName = model.DisplayName;
                existModel.SortCode = model.SortCode;
                existModel.IsActive = model.IsActive;
                existModel.IsStory = model.IsStory;
                existModel.URLCode = model.URLCode;
                existModel.Description = model.Description;
                existModel.METAKeyword = model.METAKeyword;
                existModel.METADescription = model.METADescription;
                existModel.Image = model.Image;
                existModel.ImageName = model.ImageName;
                Initialization(existModel);
                _context.Set<Collection>().Update(existModel);
                result = _context.SaveChanges();
            }
            return result;
        }
        public int UpdateItemsURLCode()
        {
            int result = AppGlobal.InitializationNumber;
            List<Collection> list = GetAllToList().OrderBy(item => item.Name).ToList();
            int sortCode = AppGlobal.InitializationNumber;
            foreach (Collection item in list)
            {
                sortCode = sortCode + 10;
                if (item.Brand_ID != null)
                {
                    Brand brand = _context.Set<Brand>().AsNoTracking().FirstOrDefault(model => model.ID == item.Brand_ID);
                    if (brand != null)
                    {
                        item.GroupCode = brand.SortCode;
                    }
                }
                item.SortCode = sortCode;
                item.Name = item.Name.Trim();
                item.URLCode = AppGlobal.SetName(item.Name);
                Update(item);
            }
            return result;
        }
        public int UpdateBySQL(Collection model)
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
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_CollectionUpdateSingleItemByID", parameters);
            return result;
        }
        public Collection GetByID(Guid ID)
        {
            Collection result = _context.Set<Collection>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = new Collection();
                result.ID = ID;
            }
            return result;
        }
        public Collection GetByURLCode(string URLCode)
        {
            Collection result = new Collection();
            if (!string.IsNullOrEmpty(URLCode))
            {
                result = _context.Set<Collection>().AsNoTracking().FirstOrDefault(model => model.URLCode == URLCode);
            }
            if (result == null)
            {
                result = new Collection();
            }
            return result;
        }
        
        public override List<Collection> GetAllToList()
        {
            List<Collection> result = new List<Collection>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectAllItems");
            result = SQLHelper.ToList<Collection>(dt);
            return result;
        }
        public List<CollectionDataTransfer> GetDataTransferAllToList()
        {
            List<CollectionDataTransfer> result = new List<CollectionDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionDataTransferSelectAllItems");
            result = SQLHelper.ToList<CollectionDataTransfer>(dt);
            return result;
        }
        public List<Collection> GetWithItemCountToList()
        {
            List<Collection> result = new List<Collection>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsWithItemCount");
            result = SQLHelper.ToList<Collection>(dt);
            return result;
        }
        public List<Collection> GetByIsActiveToList(bool isActive)
        {
            List<Collection> result = new List<Collection>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<Collection>(dt);

            return result;
        }        
        public List<Collection> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<Collection> result = new List<Collection>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive", isActive),
                new SqlParameter("@IsActiveTAUS", isActiveTAUS),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<Collection>(dt);

            return result;
        }

        public List<Collection> GetBySearchStringToList(string searchString)
        {
            List<Collection> result = new List<Collection>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<Collection>(dt);
            }
            return result;
        }
        public List<CollectionDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            List<CollectionDataTransfer> result = new List<CollectionDataTransfer>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetDataTransferAllToList();
            }
            else
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionDataTransferSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<CollectionDataTransfer>(dt);
            }
            return result;
        }

        public List<Collection> GetByBrand_IDAndIsActiveToList(string brand_ID, bool isActive)
        {
            List<Collection> result = new List<Collection>();
            if (!string.IsNullOrEmpty(brand_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Brand_ID",brand_ID),
                new SqlParameter("@IsActive",isActive),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByBrand_IDAndIsActive", parameters);
                result = SQLHelper.ToList<Collection>(dt);
            }

            return result;
        }

    }
}

