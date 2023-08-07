using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class MarketingResourceCategoryRepository : RepositoryERP<MarketingResourceCategory>, IMarketingResourceCategoryRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public MarketingResourceCategoryRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override List<MarketingResourceCategory> GetByActiveToList(bool active)
        {
            List<MarketingResourceCategory> result = new List<MarketingResourceCategory>();
            result = _context.Set<MarketingResourceCategory>().Where(item => item.Active == active).OrderBy(model => model.SortOrder).ToList();
            return result;
        }
        public override List<MarketingResourceCategory> GetAllToList()
        {
            List<MarketingResourceCategory> result = new List<MarketingResourceCategory>();
            result = _context.Set<MarketingResourceCategory>().OrderBy(model => model.SortOrder).ToList();
            return result;
        }
    }
}

