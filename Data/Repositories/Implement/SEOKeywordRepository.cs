using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class SEOKeywordRepository : RepositoryERP<SEOKeyword>, ISEOKeywordRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public SEOKeywordRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(SEOKeyword model)
        {
            model.DateUpdated = AppGlobal.InitializationDateTime;
            if (model.DateCreated == null)
            {
                model.DateCreated = AppGlobal.InitializationDateTime;
            }
            model.Title = model.Title.Trim();            
            model.Title = model.Title.Replace(@"   ", " ");
            if (string.IsNullOrEmpty(model.Code))
            {
                model.Code = AppGlobal.SetName(model.Title);
                model.Code = model.Code.Replace(@" ", @"");
                model.Code = model.Code.Replace(@"  ", @"");
            }
        }
        
    }
}

