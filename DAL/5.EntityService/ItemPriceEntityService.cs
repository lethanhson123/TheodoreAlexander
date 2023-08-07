using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class ItemPriceEntityService : ITAWEntityService<Item_Price, string>
    {
        public ItemPriceEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(Item_Price t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(string sku)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Item_Price> Get()
        {
            return _ctx.Item_Price.AsNoTracking();
        }

        public override IQueryable<Item_Price> Get(string sku)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Item_Price t)
        {
            throw new NotImplementedException();
        }
    }
}
