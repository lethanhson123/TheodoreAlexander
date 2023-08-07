using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ISEOBlogTemplateRepository : IRepositoryERP<SEOBlogTemplate>
    {
        public SEOBlogTemplate GetByRandom();
    }
}

