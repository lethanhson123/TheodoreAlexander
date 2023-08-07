using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_StatusRepository : IRepositoryERP<HR_Status>
    {
        public HR_Status GetByCode(string code);
        public HR_Status GetByName(string name);
    }
}

