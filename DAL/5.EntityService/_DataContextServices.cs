using DAL;
using DAL.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class DataContextServices : BaseRepository
    {
        public DataContextServices(TheodoreAlexanderEntities ctx):base(ctx)
        {
            
        }
        public async Task<bool?> IsSiteAccessAllowed(string ipAddress)
        {
            try
            {
                bool rtn = await _ctx.Database.SqlQuery<bool>("select dbo.udf_IsSiteAccessAllowed(@p0)", ipAddress).SingleOrDefaultAsync();
                return rtn;
                //_ctx.IsSiteAccessAllowed(ipAddress);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid?> GetCountryId(string ipAddress)
        {
            try
            {
                Guid? rtn = await _ctx.Database.SqlQuery<Guid?>("select dbo.udf_GetCountryID(@p0)", ipAddress).SingleOrDefaultAsync();
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
