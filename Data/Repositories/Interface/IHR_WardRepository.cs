using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_WardRepository : IRepositoryERP<HR_Ward>
    {
        public HR_Ward GetByCode(string code);
        public HR_Ward GetByName(string name);
        public HR_Ward GetByNameContains(string name);
        public List<HR_Ward> GetBySearchStringToList(string searchString);
        public List<HR_Ward> GetByParentIDToList(int parentID);
    }
}

