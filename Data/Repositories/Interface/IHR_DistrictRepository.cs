using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_DistrictRepository : IRepositoryERP<HR_District>
    {
        public HR_District GetByCode(string code);
        public HR_District GetByName(string name);
        public HR_District GetByNameContains(string name);
        public List<HR_District> GetBySearchStringToList(string searchString);        
    }
}

