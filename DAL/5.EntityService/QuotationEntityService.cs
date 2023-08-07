using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QuotationDB;

namespace DAL.EntityService
{
    public class QuotationEntityService
    {
        protected bool disposed = false;
        private readonly QuotationReportEntities _ctx;

        public QuotationEntityService(QuotationReportEntities ctx)
        {
            _ctx = ctx;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _ctx.Dispose();
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> AddQuatation(Request obj)
        {
            try
            {
                _ctx.Requests.Add(obj);
                if (await _ctx.SaveChangesAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IQueryable<Request>  GetQuotations() {
            return _ctx.Requests.AsNoTracking();
        }
    }
}
