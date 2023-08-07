using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class MarketingResourceDetailRepository : RepositoryERP<MarketingResourceDetail>, IMarketingResourceDetailRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public MarketingResourceDetailRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(MarketingResourceDetail model)
        {
            model.DateUpdated = AppGlobal.InitializationDateTime;
            if (model.DateCreated == null)
            {
                model.DateCreated = AppGlobal.InitializationDateTime;
            }
            if (model.Active == null)
            {
                model.Active = false;
            }
            model.URLThumbnail = model.URL + "?profile=pdfThumbnail&w=202&h=262";
        }
        public override List<MarketingResourceDetail> GetByParentIDToList(int parentID)
        {
            var result = _context.Set<MarketingResourceDetail>().Where(model => model.ParentID == parentID).OrderBy(model => model.SortOrder).ToList();
            return result;
        }
        public override List<MarketingResourceDetail> GetByParentIDAndActiveToList(int parentID, bool active)
        {
            var result = _context.Set<MarketingResourceDetail>().Where(model => model.ParentID == parentID && model.Active == active).OrderBy(model => model.SortOrder).ToList();
            return result;
        }
    }
}

