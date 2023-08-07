using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_Employee_HistoryWorkRepository : IRepositoryERP<HR_Employee_HistoryWork>
    {
        public List<HR_Employee_HistoryWork> GetByEmployeeCodeToList(string employeeCode);
    }
}

