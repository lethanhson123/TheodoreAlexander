using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class UPHFabricRepository : Repository<UPHFabric>, IUPHFabricRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public UPHFabricRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<UPHFabric> GetByCategoryToList(string category)
        {
            List<UPHFabric> result = new List<UPHFabric>();
            if (!string.IsNullOrEmpty(category))
            {
                SqlParameter[] parameters =
                   {
                new SqlParameter("@Category",category),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_UPHFabricSelectItemsByCategory", parameters);
                result = SQLHelper.ToList<UPHFabric>(dt);
            }
            return result;
        }
        public List<UPHFabric> GetByCategoryAndSearchStringToList(string category, string searchString)
        {
            List<UPHFabric> result = new List<UPHFabric>();
            if ((!string.IsNullOrEmpty(category)) && (!string.IsNullOrEmpty(searchString)))
            {
                SqlParameter[] parameters =
                   {
                new SqlParameter("@Category",category),
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_UPHFabricSelectItemsByCategoryAndSearchString", parameters);
                result = SQLHelper.ToList<UPHFabric>(dt);
            }
            return result;
        }
        public List<UPHFabric> GetBySearchStringToList(string searchString)
        {
            List<UPHFabric> result = new List<UPHFabric>();
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Replace(@" ", @";");
                searchString = searchString.Replace(@",", @";");
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SearchString",searchString),
                };
                string spName = "sp_UPHFabricSelectItemsBySearchString";
                if (searchString.Contains(@";") == true)
                {
                    spName = "sp_UPHFabricSelectItemsByList";
                }                
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, spName, parameters);
                result = SQLHelper.ToList<UPHFabric>(dt);
            }
            return result;
        }
        public List<UPHFabric> GetByIsFabricAndIsLeatherAndIsTrimsAndSearchStringToList(bool isFabric, bool isLeather, bool isTrims, string searchString)
        {
            List<UPHFabric> result = new List<UPHFabric>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result.AddRange(GetBySearchStringToList(searchString));
            }
            else
            {
                if (isFabric == true)
                {
                    result.AddRange(GetByCategoryToList("FAB"));
                }
                if (isLeather == true)
                {
                    result.AddRange(GetByCategoryToList("LEA"));
                }
                if (isTrims == true)
                {
                    result.AddRange(GetByCategoryToList("TRIM"));
                }
            }
            return result;
        }
    }
}

