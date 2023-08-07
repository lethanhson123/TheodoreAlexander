using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IMarketingResourceCategoryRepository : IRepositoryERP<MarketingResourceCategory>
    {
        public List<MarketingResourceCategory> GetByActiveToList(bool active);
    }
}

