using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.EntityService
{
    public class StoreEntityService:ITAWEntityService<Store, Guid>
    {
        public StoreEntityService(TheodoreAlexanderEntities ctx):base(ctx)
        {

        }

        public override bool Add(Store t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Store> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Store> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Store> GetStorebyId(Guid Id)
        {
            return _ctx.Stores.AsNoTracking().Where(s => s.ID == Id);
        }

        public IQueryable<Store> GetStores()
        {
            var stores = _ctx.Stores.AsNoTracking();
            return stores;
        }

        public IQueryable<Store> GetStores_Queryable()
        {
            return _ctx.Stores;
        }

        public override bool Update(Store t)
        {
            throw new NotImplementedException();
        }
    }
}
