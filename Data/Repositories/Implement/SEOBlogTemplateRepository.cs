using System.Collections.Generic;
using System.Data;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class SEOBlogTemplateRepository : RepositoryERP<SEOBlogTemplate>, ISEOBlogTemplateRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public SEOBlogTemplateRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(SEOBlogTemplate model)
        {
            model.DateUpdated = AppGlobal.InitializationDateTime;
            if (model.DateCreated == null)
            {
                model.DateCreated = AppGlobal.InitializationDateTime;
            }
            if (!string.IsNullOrEmpty(model.Image))
            {
                model.URLImage = AppGlobal.APIURLHTTPS + AppGlobal.Images + "/" + model.Image;
            }            
        }       
        public SEOBlogTemplate GetByRandom()
        {
            SEOBlogTemplate result = new SEOBlogTemplate();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogTemplateSelectItemByRandom");
            List<SEOBlogTemplate> list = SQLHelper.ToList<SEOBlogTemplate>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }
    }
}

