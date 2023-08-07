using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ISystem_ApplicationRepository : IRepositoryERP<System_Application>
    {
        public List<System_Application> GetBySearchStringToList(string searchString);
    }
}

