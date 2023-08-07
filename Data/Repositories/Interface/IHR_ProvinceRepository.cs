using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_ProvinceRepository : IRepositoryERP<HR_Province>
    {
        public HR_Province GetByCode(string code);
        public HR_Province GetByName(string name);
        public HR_Province GetByNameContains(string name);
        public List<HR_Province> GetBySearchStringToList(string searchString);
    }
}

