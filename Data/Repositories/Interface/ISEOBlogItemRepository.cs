using System.Threading.Tasks;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ISEOBlogItemRepository : IRepositoryERP<SEOBlogItem>
    {
        public int InitializationByParentID(int parentID);
        public int InitializationByParentIDAndRegion(int parentID, string region);
        public Task<int> AsyncInitializationByParentID(int parentID);
        public Task<int> AsyncInitializationByParentIDAndRegion(int parentID, string region);
    }
}

