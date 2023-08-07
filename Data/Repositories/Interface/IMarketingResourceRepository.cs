using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IMarketingResourceRepository : IRepositoryERP<MarketingResource>
    {
        public List<MarketingResource> GetByActiveToList(bool active);
    }
}

