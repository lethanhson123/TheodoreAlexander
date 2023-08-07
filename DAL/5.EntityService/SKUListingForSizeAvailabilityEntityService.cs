using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class SKUListingForSizeAvailabilityEntityService : ITAWEntityService<SKUListingForSizeAvailability, Guid>
    {

        public SKUListingForSizeAvailabilityEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(SKUListingForSizeAvailability t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<SKUListingForSizeAvailability> Get()
        {
            return _ctx.SKUListingForSizeAvailabilities.AsNoTracking();
        }

        public override IQueryable<SKUListingForSizeAvailability> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(SKUListingForSizeAvailability t)
        {
            throw new NotImplementedException();
        }
    }
}
