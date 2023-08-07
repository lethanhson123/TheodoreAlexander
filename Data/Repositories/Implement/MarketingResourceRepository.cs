using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class MarketingResourceRepository : RepositoryERP<MarketingResource>, IMarketingResourceRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public MarketingResourceRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override List<MarketingResource> GetByParentIDToList(int parentID)
        {
            var result = _context.Set<MarketingResource>().Where(model => model.ParentID == parentID).OrderBy(model => model.SortOrder).ToList();
            return result;
        }
        public override List<MarketingResource> GetByParentIDAndActiveToList(int parentID, bool active)
        {
            var result = _context.Set<MarketingResource>().Where(model => model.ParentID == parentID && model.Active == active).OrderBy(model => model.SortOrder).ToList();
            return result;
        }
    }
}

