using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class ItemEntityService : ITAWEntityService<Item, Guid>
    {

        public ItemEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(Item t)
        {
            try
            {
                _ctx.Items.Add(t);
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Delete(Guid id)
        {
            try
            {
                Item item = _ctx.Items.Where(i => i.ID == id).FirstOrDefault();
                if (item != null)
                {
                    _ctx.Items.Remove(item);
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

        public override IQueryable<Item> Get()
        {
            return _ctx.Items.AsNoTracking();
        }

        public override IQueryable<Item> Get(Guid id)
        {
            return _ctx.Items.AsNoTracking().Where(i => i.ID == id);
        }

        public IQueryable<Item> Get(string sku)
        {
            return _ctx.Items.AsNoTracking().Where(i => i.SKU == sku);
        }

        public override bool Update(Item t)
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
