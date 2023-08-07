using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IGhostBlogRepository : IRepositoryERP<GhostBlog>
    {
        public GhostBlog GetByURLCode(string URLCode);
        public List<GhostBlog> GetBySearchStringToList(string searchString);
        public List<GhostBlog> GetByNumberToList(int number);
        public List<GhostBlog> GetByNumberAndIDToList(int number, int ID);
        public string DeleteAllItems();
    }
}

