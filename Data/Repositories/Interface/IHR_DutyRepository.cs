using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_DutyRepository : IRepositoryERP<HR_Duty>
    {
        public HR_Duty GetByCode(string code);
        public HR_Duty GetByName(string name);
    }
}

