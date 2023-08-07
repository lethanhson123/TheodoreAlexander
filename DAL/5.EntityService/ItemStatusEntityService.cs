using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class ItemStatusEntityService : ITAWEntityService<Item_Status, string>
    {
        public ItemStatusEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(Item_Status t)
        {
            try
            {
                _ctx.Item_Status.Add(t);
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Delete(string sku)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Item_Status> Get()
        {
            return _ctx.Item_Status.AsNoTracking();
        }

        public override IQueryable<Item_Status> Get(string sku)
        {
            return _ctx.Item_Status.AsNoTracking().Where(i => i.SKU == sku);
        }

        public override bool Update(Item_Status t)
        {
            try
            {
                _ctx.Entry(t).State = EntityState.Modified;
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
