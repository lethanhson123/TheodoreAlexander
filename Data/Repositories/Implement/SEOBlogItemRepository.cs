using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class SEOBlogItemRepository : RepositoryERP<SEOBlogItem>, ISEOBlogItemRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public SEOBlogItemRepository(TheodoreAlexander_ERPContext context) : base(context)
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
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogItemInitializationByParentID", parameters);
            return result;
        }
        public int InitializationByParentIDAndRegion(int parentID, string region)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID", parentID),
                new SqlParameter("@Region", region),
            };
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogItemInitializationByParentIDAndRegion", parameters);
            return result;
        }
        public async Task<int> AsyncInitializationByParentID(int parentID)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID", parentID)
            };
            await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogItemInitializationByParentID", parameters);
            return result;
        }
        public async Task<int> AsyncInitializationByParentIDAndRegion(int parentID, string region)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID", parentID),
                new SqlParameter("@Region", region),
            };
            await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogItemInitializationByParentIDAndRegion", parameters);
            return result;
        }
        public override List<SEOBlogItem> GetByParentIDToList(int parentID)
        {
            var result = _context.Set<SEOBlogItem>().Where(model => model.ParentID == parentID).OrderBy(model => model.TypeID).ToList();
            return result;
        }
    }
}

