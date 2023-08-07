using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class System_AuthenticationApplicationRepository : RepositoryERP<System_AuthenticationApplication>, ISystem_AuthenticationApplicationRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public System_AuthenticationApplicationRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public List<System_AuthenticationApplicationDataTransfer> GetDataTransferAllToList()
        {
            List<System_AuthenticationApplicationDataTransfer> result = new List<System_AuthenticationApplicationDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_ERPSQLServerConectionString, "sp_System_AuthenticationApplicationSelectAllItems");
            result = SQLHelper.ToList<System_AuthenticationApplicationDataTransfer>(dt);
            return result;
        }
        public List<System_AuthenticationApplicationDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            List<System_AuthenticationApplicationDataTransfer> result = new List<System_AuthenticationApplicationDataTransfer>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_ERPSQLServerConectionString, "sp_System_AuthenticationApplicationSelectItemsBySearchString", parameters);
                result = SQLHelper.ToList<System_AuthenticationApplicationDataTransfer>(dt);
            }
            return result;
        }
    }
}

