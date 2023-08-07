using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_EmployeeRepository : IRepositoryERP<HR_Employee>
    {        
        public HR_Employee GetByCode(string code);
        public List<HR_EmployeeDataTransfer> GetDataTransferBySearchStringToList(string searchString);
        public Task<List<HR_EmployeeDataTransfer>> AsyncGetDataTransferBySearchStringToList(string searchString);
        public Task<List<HR_EmployeeDataTransfer001>> AsyncGetDataTransferBySearchString001ToList(string searchString);
        public Task<List<HR_EmployeeDataTransfer001>> AsyncGetDataTransfer001BySearchStringAndIDToList(string searchString, int ID);
        public List<HR_EmployeeDataTransfer001> GetDataTransfer001BySearchStringAndIDToList(string searchString, int ID);
    }
}

