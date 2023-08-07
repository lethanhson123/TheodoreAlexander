using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_CovidRepository : RepositoryERP<HR_Covid>, IHR_CovidRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_CovidRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(HR_Covid model)
        {
            if (model.DateCreated == null)
            {
                model.DateCreated = AppGlobal.InitializationDateTime;
            }
            if (model.DateUpdated == null)
            {
                model.DateUpdated = AppGlobal.InitializationDateTime;
            }
            if (model.Active == null)
            {
                model.Active = false;
            }
            if (!string.IsNullOrEmpty(model.AddressContact))
            {
                List<string> listAddress = AppGlobal.SetProvinceAndDistrictAndWard(model.AddressContact);
                if (listAddress.Count > 0)
                {
                    model.AddressContactProvince = listAddress[0];
                }
                if (listAddress.Count > 1)
                {
                    model.AddressContactDistrict = listAddress[1];
                }
                if (listAddress.Count > 2)
                {
                    model.AddressContactWard = listAddress[2];
                }
            }
        }       
        public List<HR_Covid> GetByCovidTypeIDToList(int covidTypeID)
        {
            List<HR_Covid> result = new List<HR_Covid>();
            if (covidTypeID > 0)
            {
                result = _context.Set<HR_Covid>().Where(model => model.CovidTypeID == covidTypeID).OrderByDescending(item => item.CovidTestDate).ToList();
            }
            return result;
        }

        public List<HR_CovidDataTransfer> GetDataTransferAllToList()
        {
            List<HR_CovidDataTransfer> result = new List<HR_CovidDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_CovidSelectAllItems");
            result = SQLHelper.ToList<HR_CovidDataTransfer>(dt);
            return result;
        }
        public List<HR_CovidDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            List<HR_CovidDataTransfer> result = new List<HR_CovidDataTransfer>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_CovidSelectBySearchString", parameters);
                result = SQLHelper.ToList<HR_CovidDataTransfer>(dt);
            }
            return result;
        }

        public List<HR_CovidDataTransfer> GetDataTransferByCovidTypeIDToList(int covidTypeID)
        {
            List<HR_CovidDataTransfer> result = new List<HR_CovidDataTransfer>();
            if (covidTypeID > 0)
            {
                SqlParameter[] parameters =
                   {
                new SqlParameter("@CovidTypeID",covidTypeID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_CovidSelectByCovidTypeID", parameters);
                result = SQLHelper.ToList<HR_CovidDataTransfer>(dt);
            }
            return result;
        }
        public List<HR_CovidDataTransfer> GetDataTransferByEmployeeIDToList(int employeeID)
        {
            List<HR_CovidDataTransfer> result = new List<HR_CovidDataTransfer>();
            if (employeeID > 0)
            {
                SqlParameter[] parameters =
                   {
                new SqlParameter("@EmployeeID",employeeID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_CovidSelectByEmployeeID", parameters);
                result = SQLHelper.ToList<HR_CovidDataTransfer>(dt);
            }
            return result;
        }

        public List<HR_CovidDataTransfer> GetDataTransferBySearchStringAndCodeManageToList(string searchString, string codeManage)
        {
            List<HR_CovidDataTransfer> result = new List<HR_CovidDataTransfer>();
            if (string.IsNullOrEmpty(codeManage))
            {
                result = GetDataTransferBySearchStringToList(searchString);
            }
            else
            {
                if (string.IsNullOrEmpty(searchString))
                {
                    result = GetDataTransferByCodeManageToList(codeManage);
                }
                else
                {
                    SqlParameter[] parameters =
                   {
                new SqlParameter("@SearchString",searchString),
                new SqlParameter("@CodeManage",codeManage),
                };
                    DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_CovidSelectBySearchStringAndCodeManage", parameters);
                    result = SQLHelper.ToList<HR_CovidDataTransfer>(dt);
                }
            }
            return result;
        }
        public List<HR_CovidDataTransfer> GetDataTransferByCodeManageToList(string codeManage)
        {
            List<HR_CovidDataTransfer> result = new List<HR_CovidDataTransfer>();
            if (!string.IsNullOrEmpty(codeManage))
            {
                codeManage = codeManage.Trim();
                SqlParameter[] parameters =
                   {
                new SqlParameter("@CodeManage",codeManage),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_CovidSelectByCodeManage", parameters);
                result = SQLHelper.ToList<HR_CovidDataTransfer>(dt);
            }
            return result;
        }
        public List<HR_Covid> GetByWithCodeManageToList()
        {
            List<HR_Covid> result = new List<HR_Covid>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_CovidSelectWithCodeManage");
            result = SQLHelper.ToList<HR_Covid>(dt);
            return result;
        }
    }
}

