using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_Employee_HistoryWorkRepository : RepositoryERP<HR_Employee_HistoryWork>, IHR_Employee_HistoryWorkRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_Employee_HistoryWorkRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }       
        public List<HR_Employee_HistoryWork> GetByEmployeeCodeToList(string employeeCode)
        {
            List<HR_Employee_HistoryWork> result = new List<HR_Employee_HistoryWork>();
            if (!string.IsNullOrEmpty(employeeCode))
            {
                employeeCode = employeeCode.Trim();
                result = _context.Set<HR_Employee_HistoryWork>().Where(model => model.EmployeeCode == employeeCode).OrderByDescending(item => item.DateUpdated).ToList();
            }
            return result;
        }
    }
}

