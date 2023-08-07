using BL.EntityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BusinessService
{
    public abstract class ITABusinessService<Dto, Entity, Id>
    {
        protected DAL.EntityService.ITAWEntityService<Entity, Id> itaModelService;

        public ITABusinessService(DAL.EntityService.ITAWEntityService<Entity, Id> modelService) {
            itaModelService = modelService;
        }

        protected bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                itaModelService.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract IQueryable<Dto> Get();
        public abstract IQueryable<Dto> Get(Id id);
        public abstract bool Add(Dto t);
        public abstract bool Update(Dto t);
        public abstract bool Delete(Id id);
    }
}
