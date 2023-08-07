using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_EmployeeRepository : RepositoryERP<HR_Employee>, IHR_EmployeeRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_EmployeeRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
       
       
        public HR_Employee GetByCode(string code)
        {
            HR_Employee result = new HR_Employee();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Employee>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public List<HR_EmployeeDataTransfer> GetDataTransferAllToList()
        {
            List<HR_EmployeeDataTransfer> result = new List<HR_EmployeeDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectAllItems");
            result = SQLHelper.ToList<HR_EmployeeDataTransfer>(dt);
            return result;
        }
        public async Task<List<HR_EmployeeDataTransfer>> AsyncGetDataTransferAllToList()
        {
            List<HR_EmployeeDataTransfer> result = new List<HR_EmployeeDataTransfer>();
            DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectAllItems");
            result = SQLHelper.ToList<HR_EmployeeDataTransfer>(dt);
            return result;
        }
        public List<HR_EmployeeDataTransfer> GetDataTransferByRowNumberToList()
        {
            List<HR_EmployeeDataTransfer> result = new List<HR_EmployeeDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectByRowNumber");
            result = SQLHelper.ToList<HR_EmployeeDataTransfer>(dt);
            return result;
        }
        public async Task<List<HR_EmployeeDataTransfer>> AsyncGetDataTransferByRowNumberToList()
        {
            List<HR_EmployeeDataTransfer> result = new List<HR_EmployeeDataTransfer>();
            DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectByRowNumber");
            result = SQLHelper.ToList<HR_EmployeeDataTransfer>(dt);
            return result;
        }
        public async Task<List<HR_EmployeeDataTransfer001>> AsyncGetDataTransfer001ByIDToList(int ID)
        {
            List<HR_EmployeeDataTransfer001> result = new List<HR_EmployeeDataTransfer001>();
            SqlParameter[] parameters =
              {
                new SqlParameter("@ID",ID),
                };
            DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectByRowNumberAndID001", parameters);
            result = SQLHelper.ToList<HR_EmployeeDataTransfer001>(dt);
            return result;
        }
        public List<HR_EmployeeDataTransfer001> GetDataTransfer001ByIDToList(int ID)
        {
            List<HR_EmployeeDataTransfer001> result = new List<HR_EmployeeDataTransfer001>();
            SqlParameter[] parameters =
                  {
                new SqlParameter("@ID",ID),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectByRowNumberAndID001", parameters);
            result = SQLHelper.ToList<HR_EmployeeDataTransfer001>(dt);
            return result;
        }
        public List<HR_EmployeeDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            List<HR_EmployeeDataTransfer> result = new List<HR_EmployeeDataTransfer>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetDataTransferByRowNumberToList();
            }
            else
            {
                searchString = searchString.Trim();
                SqlParameter[] parameters =
                   {
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectBySearchString", parameters);
                result = SQLHelper.ToList<HR_EmployeeDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<HR_EmployeeDataTransfer>> AsyncGetDataTransferBySearchStringToList(string searchString)
        {
            List<HR_EmployeeDataTransfer> result = new List<HR_EmployeeDataTransfer>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = await AsyncGetDataTransferByRowNumberToList();
            }
            else
            {
                searchString = searchString.Trim();
                SqlParameter[] parameters =
                   {
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectBySearchString", parameters);
                result = SQLHelper.ToList<HR_EmployeeDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<HR_EmployeeDataTransfer001>> AsyncGetDataTransferAll001ToList()
        {
            List<HR_EmployeeDataTransfer001> result = new List<HR_EmployeeDataTransfer001>();
            DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectAllItems001");
            result = SQLHelper.ToList<HR_EmployeeDataTransfer001>(dt);
            return result;
        }
        public async Task<List<HR_EmployeeDataTransfer001>> AsyncGetDataTransferBySearchString001ToList(string searchString)
        {
            List<HR_EmployeeDataTransfer001> result = new List<HR_EmployeeDataTransfer001>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = await AsyncGetDataTransferAll001ToList();
            }
            else
            {
                searchString = searchString.Trim();
                SqlParameter[] parameters =
                   {
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectBySearchString001", parameters);
                result = SQLHelper.ToList<HR_EmployeeDataTransfer001>(dt);
            }
            return result;
        }
        public async Task<List<HR_EmployeeDataTransfer001>> AsyncGetDataTransfer001BySearchStringAndIDToList(string searchString, int ID)
        {
            List<HR_EmployeeDataTransfer001> result = new List<HR_EmployeeDataTransfer001>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = await AsyncGetDataTransfer001ByIDToList(ID);
            }
            else
            {
               
                    searchString = searchString.Trim();
                    SqlParameter[] parameters =
                       {
                new SqlParameter("@SearchString",searchString),
                new SqlParameter("@ID",ID),
                };
                    DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectBySearchStringAndID001", parameters);
                    result = SQLHelper.ToList<HR_EmployeeDataTransfer001>(dt);                
            }
            return result;
        }
        public List<HR_EmployeeDataTransfer001> GetDataTransfer001BySearchStringAndIDToList(string searchString, int ID)
        {
            List<HR_EmployeeDataTransfer001> result = new List<HR_EmployeeDataTransfer001>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetDataTransfer001ByIDToList(ID);
            }
            else
            {
                searchString = searchString.Trim();
                SqlParameter[] parameters =
               {
                new SqlParameter("@SearchString",searchString),
                new SqlParameter("@ID",ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_EmployeeSelectBySearchStringAndID001", parameters);
                result = SQLHelper.ToList<HR_EmployeeDataTransfer001>(dt);
            }        
            return result;
        }
}
}

