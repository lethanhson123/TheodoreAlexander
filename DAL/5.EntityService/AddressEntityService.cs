using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.EntityService
{
    public class AddressEntityService:ITAWEntityService<Address, Guid>
    {
        public AddressEntityService(TheodoreAlexanderEntities ctx):base(ctx)
        {

        }

        public override bool Add(Address t)
        {
            try
            {
                _ctx.Addresses.Add(t);
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public override bool Delete(Guid id)
        {
            try
            {
                Address item = _ctx.Addresses.Where(i => i.ID == id).FirstOrDefault();
                if (item != null)
                {
                    _ctx.Addresses.Remove(item);
                    return _ctx.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override IQueryable<Address> Get()
        {
            try
            {
                return _ctx.Addresses.AsNoTracking();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public override IQueryable<Address> Get(Guid id)
        {
            try
            {
                return Get().Where(o => o.ID == id);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public override bool Update(Address t)
        {
            try
            {
                _ctx.Entry(t).State = EntityState.Modified;
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
