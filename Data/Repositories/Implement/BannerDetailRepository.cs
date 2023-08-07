using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class BannerDetailRepository : RepositoryERP<BannerDetail>, IBannerDetailRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public BannerDetailRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(BannerDetail model)
        {
            model.DateUpdated = AppGlobal.InitializationDateTime;
            if (model.DateCreated == null)
            {
                model.DateCreated = AppGlobal.InitializationDateTime;
            }            
            if (!string.IsNullOrEmpty(model.ImageDesktop))
            {
                model.URLImageDesktop = AppGlobal.APIURLHTTPS + AppGlobal.Images + "/" + model.ImageDesktop;
            }
            if (!string.IsNullOrEmpty(model.ImageMobile))
            {
                model.URLImageMobile = AppGlobal.APIURLHTTPS + AppGlobal.Images + "/" + model.ImageMobile;
            }
            if (!string.IsNullOrEmpty(model.ImageName))
            {
                model.URLImageName = AppGlobal.APIURLHTTPS + AppGlobal.Images + "/" + model.ImageName;
            }
        }
        public override List<BannerDetail> GetByParentIDToList(int parentID)
        {
            var result = _context.Set<BannerDetail>().Where(model => model.ParentID == parentID).OrderBy(model => model.SortOrder).ToList();
            return result;
        }
    }
}

