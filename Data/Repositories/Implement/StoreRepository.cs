using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public StoreRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override List<Store> GetAllToList()
        {
            List<Store> result = new List<Store>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectAllItems");
            result = SQLHelper.ToList<Store>(dt);
            return result;
        }
        public List<StoreDataTransfer> GetDataTransferAllToList()
        {
            List<StoreDataTransfer> result = new List<StoreDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectDataTransferAllItems");
            result = SQLHelper.ToList<StoreDataTransfer>(dt);
            return result;
        }
        public List<Store> GetBySearchStringToList(string searchString)
        {
            List<Store> result = new List<Store>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectDataTransferBySearchString", parameters);
                result = SQLHelper.ToList<Store>(dt);
            }
            return result;
        }
        public List<StoreDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            List<StoreDataTransfer> result = new List<StoreDataTransfer>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_StoreSelectDataTransferBySearchString", parameters);
                result = SQLHelper.ToList<StoreDataTransfer>(dt);
            }
            return result;
        }
    }
}

