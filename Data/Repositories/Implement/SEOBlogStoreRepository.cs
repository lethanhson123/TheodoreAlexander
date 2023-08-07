using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class SEOBlogStoreRepository : RepositoryERP<SEOBlogStore>, ISEOBlogStoreRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public SEOBlogStoreRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public int InitializationByParentID(int parentID)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID", parentID)
            };
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogStoreInitializationByParentID", parameters);
            return result;
        }
        public async Task<int> AsyncInitializationByParentID(int parentID)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID", parentID)
            };
            await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogStoreInitializationByParentID", parameters);
            return result;
        }
        public override List<SEOBlogStore> GetByParentIDToList(int parentID)
        {
            var result = _context.Set<SEOBlogStore>().Where(model => model.ParentID == parentID).OrderBy(model => model.Title).ToList();
            return result;
        }
    }
}

