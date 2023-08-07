using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_DepartmentRepository : IRepositoryERP<HR_Department>
    {
        public HR_Department GetByCode(string code);
        public HR_Department GetByName(string name);
    }
}

