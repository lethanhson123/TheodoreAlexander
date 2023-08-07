using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public class System_ApplicationRepository : RepositoryERP<System_Application>, ISystem_ApplicationRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public System_ApplicationRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
       
        public List<System_Application> GetBySearchStringToList(string searchString)
        {
            List<System_Application> result = new List<System_Application>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                result = _context.Set<System_Application>().Where(model => model.Name.Contains(searchString) || model.URL.Contains(searchString)).ToList();
            }
            return result.OrderBy(model => model.Name).ToList();
        }
    }
}

