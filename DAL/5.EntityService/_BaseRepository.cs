using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.EntityService
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly TheodoreAlexanderEntities _ctx;
        protected bool disposed = false;
        public BaseRepository(TheodoreAlexanderEntities ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException("contextLocator");
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
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public abstract class ITAWEntityService<Entity,Id>:BaseRepository
    {
        public ITAWEntityService(TheodoreAlexanderEntities ctx): base(ctx){}

        public abstract IQueryable<Entity> Get();
        public abstract IQueryable<Entity> Get(Id id);
        public abstract bool Add(Entity t);
        public abstract bool Update(Entity t);
        public abstract bool Delete(Id id);
    }
}
