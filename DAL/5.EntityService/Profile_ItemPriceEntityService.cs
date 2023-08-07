using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class Profile_ItemPriceEntityService : ITAWEntityService<Profile_ItemPrice, string>
    {
        public Profile_ItemPriceEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(Profile_ItemPrice t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(string sku)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Profile_ItemPrice> Get()
        {
            return _ctx.Profile_ItemPrice.AsNoTracking();
        }

        public override IQueryable<Profile_ItemPrice> Get(string sku)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Profile_ItemPrice t)
        {
            throw new NotImplementedException();
        }
    }
}
