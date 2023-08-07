using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IMarketingResourceDetailRepository : IRepositoryERP<MarketingResourceDetail>
    {
        public List<MarketingResourceDetail> GetByActiveToList(bool active);
    }
}

