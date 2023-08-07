using System.Threading.Tasks;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ISEOBlogStoreRepository : IRepositoryERP<SEOBlogStore>
    {
        public int InitializationByParentID(int parentID);
        public Task<int> AsyncInitializationByParentID(int parentID);
    }
}

