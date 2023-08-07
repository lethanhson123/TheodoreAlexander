using System.Collections.Generic;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_CovidRepository : IRepositoryERP<HR_Covid>
    {        
        public List<HR_Covid> GetByCovidTypeIDToList(int covidTypeID);
        public List<HR_CovidDataTransfer> GetDataTransferByCovidTypeIDToList(int covidTypeID);
        public List<HR_CovidDataTransfer> GetDataTransferBySearchStringToList(string searchString);
        public List<HR_CovidDataTransfer> GetDataTransferByEmployeeIDToList(int employeeID);
        public List<HR_CovidDataTransfer> GetDataTransferBySearchStringAndCodeManageToList(string searchString, string codeManage);
        public List<HR_Covid> GetByWithCodeManageToList();
    }
}

