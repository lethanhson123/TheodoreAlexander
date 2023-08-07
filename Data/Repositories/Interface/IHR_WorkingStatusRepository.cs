using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_WorkingStatusRepository : IRepositoryERP<HR_WorkingStatus>
    {
        public HR_WorkingStatus GetByCode(string code);
        public HR_WorkingStatus GetByName(string name);
    }
}

