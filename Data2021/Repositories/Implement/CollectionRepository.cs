
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
    public class CollectionRepository : Repository<TA.Data2021.Models.Collection>, ICollectionRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public CollectionRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public TA.Data2021.Models.Collection GetByID(string ID)
        {
            TA.Data2021.Models.Collection result = new TA.Data2021.Models.Collection();
            SqlParameter[] parameters =
             {
                new SqlParameter("@ID",ID),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByID", parameters);
            List<TA.Data2021.Models.Collection> list = SQLHelper.ToList<TA.Data2021.Models.Collection>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }
        public TA.Data2021.Models.Collection GetByURLCode(string URLCode)
        {
            TA.Data2021.Models.Collection result = new TA.Data2021.Models.Collection();
            SqlParameter[] parameters =
             {
                new SqlParameter("@URLCode",URLCode),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByURLCode", parameters);
            List<TA.Data2021.Models.Collection> list = SQLHelper.ToList<TA.Data2021.Models.Collection>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }

        public List<TA.Data2021.Models.Collection> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            List<TA.Data2021.Models.Collection> result = new List<TA.Data2021.Models.Collection>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByIsActiveAndIsActiveTAUS", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Collection>(dt);

            return result;
        }
        public List<TA.Data2021.Models.Collection> GetByIsActiveToList(bool isActive)
        {
            List<TA.Data2021.Models.Collection> result = new List<TA.Data2021.Models.Collection>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),                
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Collection>(dt);

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
        public List<Collection> GetByBrand_IDAndIsActiveAndIsActiveTAUSToList(string brand_ID, bool isActive, bool isActiveTAUS)
        {
            List<Collection> result = new List<Collection>();
            if (!string.IsNullOrEmpty(brand_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Brand_ID",brand_ID),
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByBrand_IDAndIsActiveAndIsActiveTAUS", parameters);
                result = SQLHelper.ToList<Collection>(dt);
            }
            return result;
        }
        public List<Collection> GetByBrand_IDAndIsActiveAndIsActiveTAUSAndItemCountToList(string brand_ID, bool isActive, bool isActiveTAUS, int itemCount)
        {
            List<Collection> result = new List<Collection>();
            if (!string.IsNullOrEmpty(brand_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Brand_ID",brand_ID),
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@ItemCount",itemCount),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByBrand_IDAndIsActiveAndIsActiveTAUSAndItemCount", parameters);
                result = SQLHelper.ToList<Collection>(dt);
            }
            return result;
        }
        public List<TA.Data2021.Models.Collection> GetByIsActiveAndIsActiveTAUSCovertMenuToList(bool isActive, bool isActiveTAUS)
        {
            List<TA.Data2021.Models.Collection> result = new List<TA.Data2021.Models.Collection>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_CollectionSelectItemsByIsActiveAndIsActiveTAUSCovertMenu", parameters);
            result = SQLHelper.ToList<TA.Data2021.Models.Collection>(dt);

            return result;
        }
    }
}

