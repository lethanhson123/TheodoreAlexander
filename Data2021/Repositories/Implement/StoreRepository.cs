
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data2021.Models;
using TA.Helpers2021;
using TA.Data2021.Repositories;
using TA.Data2021.DataTransfer;

namespace TA.Data2021.Repositories
{
    public class StoreRepository : Repository<TA.Data2021.Models.Store>, IStoreRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public StoreRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }

        public List<TA.Data2021.Models.Store> GetByUserIDToList(string userID)
        {
            List<TA.Data2021.Models.Store> result = new List<TA.Data2021.Models.Store>();
            if (!string.IsNullOrEmpty(userID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@UserID",userID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectItemsByUserID", parameters);
                result = SQLHelper.ToList<TA.Data2021.Models.Store>(dt);
            }
            return result;
        }
        public List<Store> GetByIsActiveToList(bool isActive)
        {
            List<Store> result = new List<Store>();

            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<Store>(dt);

            return result;
        }
        public List<Store> GetByIsActiveAndSearchStringToList(bool isActive, string searchString)
        {
            List<Store> result = new List<Store>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetByIsActiveToList(isActive);
            }
            else
            {
                searchString = searchString.Trim();
                SqlParameter[] parameters =
                {
                    new SqlParameter("@IsActive",isActive),
                    new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectItemsByIsActiveAndSearchString", parameters);
                result = SQLHelper.ToList<Store>(dt);
            }
            return result;
        }

        public List<Store> GetByFilterToList(bool isActive, string searchString, string countryISO, string regionName, decimal latitude, decimal longitude, bool isDealerNearYou)
        {
            List<Store> result = new List<Store>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@IsActive",isActive),
                    new SqlParameter("@SearchString",searchString),
                    new SqlParameter("@CountryISO",countryISO),
                    new SqlParameter("@RegionName",regionName),
                    new SqlParameter("@Latitude",latitude),
                    new SqlParameter("@Longitude",longitude),
                    new SqlParameter("@IsDealerNearYou",isDealerNearYou),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectItemsByFilter", parameters);
            result = SQLHelper.ToList<Store>(dt);
            return result;
        }
        public List<Store> GetByIsActiveAndLatitudeAndLongitudeToList(bool isActive, decimal latitude, decimal longitude)
        {
            List<Store> result = new List<Store>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@IsActive",isActive),
                    new SqlParameter("@Latitude",latitude),
                    new SqlParameter("@Longitude",longitude),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectItemsByIsActiveAndLatitudeAndLongitude", parameters);
            result = SQLHelper.ToList<Store>(dt);
            return result;
        }
        public List<Store> GetByIsActiveAndLatitudeAndLongitudeAndRadiusToList(bool isActive, decimal latitude, decimal longitude, decimal radius)
        {
            List<Store> result = new List<Store>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@IsActive",isActive),
                    new SqlParameter("@Latitude",latitude),
                    new SqlParameter("@Longitude",longitude),
                    new SqlParameter("@Radius",radius),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectItemsByIsActiveAndLatitudeAndLongitudeAndRadius", parameters);
            result = SQLHelper.ToList<Store>(dt);
            return result;
        }
        public List<Store> GetByIsActiveAndLatitudeAndLongitudeAndRadiusAndSearchStringToList(bool isActive, decimal latitude, decimal longitude, decimal radius, string searchString)
        {
            List<Store> result = new List<Store>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@IsActive",isActive),
                    new SqlParameter("@Latitude",latitude),
                    new SqlParameter("@Longitude",longitude),
                    new SqlParameter("@Radius",radius),
                    new SqlParameter("@SearchString",searchString),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectItemsByIsActiveAndLatitudeAndLongitudeAndRadiusAndSearchString", parameters);
            result = SQLHelper.ToList<Store>(dt);
            return result;
        }
        public List<Store> GetByFilter2022ToList(bool isActive, string searchString, decimal latitude, decimal longitude, decimal radius)
        {
            List<Store> result = new List<Store>();
            if (!string.IsNullOrEmpty(searchString))
            {
                if (radius == 0)
                {
                    result = GetByIsActiveAndSearchStringToList(isActive, searchString);
                }
                else
                {
                    result = GetByIsActiveAndLatitudeAndLongitudeAndRadiusAndSearchStringToList(isActive, latitude, longitude, radius, searchString);
                }

            }
            else
            {
                if (radius == 0)
                {
                    result = GetByIsActiveAndLatitudeAndLongitudeToList(isActive, latitude, longitude);
                }
                else
                {
                    result = GetByIsActiveAndLatitudeAndLongitudeAndRadiusToList(isActive, latitude, longitude, radius);
                }                
                if (result.Count == 0)
                {
                    result = GetByIsActiveToList(isActive);
                }
            }
            return result;
        }
    }
}

