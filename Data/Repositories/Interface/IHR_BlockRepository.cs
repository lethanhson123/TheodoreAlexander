using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_BlockRepository : IRepositoryERP<HR_Block>
    {
        public HR_Block GetByCode(string code);
        public HR_Block GetByName(string name);
    }
}

