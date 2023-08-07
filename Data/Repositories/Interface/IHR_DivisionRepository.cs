using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_DivisionRepository : IRepositoryERP<HR_Division>
    {
        public HR_Division GetByCode(string code);
        public HR_Division GetByName(string name);
    }
}

