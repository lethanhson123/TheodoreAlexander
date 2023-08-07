using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_TeamRepository : IRepositoryERP<HR_Team>
    {
        public HR_Team GetByCode(string code);
        public HR_Team GetByName(string name);
    }
}

