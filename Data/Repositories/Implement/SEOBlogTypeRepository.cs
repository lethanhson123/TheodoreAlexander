using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class SEOBlogTypeRepository : RepositoryERP<SEOBlogType>, ISEOBlogTypeRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public SEOBlogTypeRepository(TheodoreAlexander_ERPContext context) : base(context)
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
            SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogTypeInitializationByParentID", parameters);
            return result;
        }
        public async Task<int> AsyncInitializationByParentID(int parentID)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID", parentID)
            };
            await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogTypeInitializationByParentID", parameters);
            return result;
        }
        public override List<SEOBlogType> GetByParentIDToList(int parentID)
        {
            var result = _context.Set<SEOBlogType>().Where(model => model.ParentID == parentID).OrderBy(model => model.Title).ToList();
            return result;
        }
    }
}

