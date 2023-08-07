using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_GroupRepository : IRepositoryERP<HR_Group>
    {
        public HR_Group GetByCode(string code);
        public HR_Group GetByName(string name);
    }
}

