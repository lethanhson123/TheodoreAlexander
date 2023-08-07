using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class BannerRepository : RepositoryERP<Banner>, IBannerRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public BannerRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override List<Banner> GetAllToList()
        {
            List<Banner> result = new List<Banner>();
            result = _context.Set<Banner>().OrderBy(model => model.SortOrder).ToList();
            return result;
        }
    }
}

