using BL.BusinessService;
using BL.EntityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BusinessService
{
    public abstract class ITAService<ViewModel, Dto, Entity, Id>
    {
        protected ITABusinessService<Dto, Entity, Id> businessService;

        public ITAService(ITABusinessService<Dto, Entity, Id> itaBusinessService) {
            businessService = itaBusinessService;
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
                businessService.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public abstract IQueryable<ViewModel> Get();
        //public abstract ViewModel Get(Id id);
        //public abstract bool Add(ViewModel t);
        //public abstract bool Update(ViewModel t);
        //public abstract bool Delete(Id id);
    }
}
