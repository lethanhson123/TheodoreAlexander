using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class RelatedSkuForSpecialGroupEntityService : ITAWEntityService<RelatedSkuForSpecialGroup, Guid>
    {
        public RelatedSkuForSpecialGroupEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(RelatedSkuForSpecialGroup t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<RelatedSkuForSpecialGroup> Get()
        {
            return _ctx.RelatedSkuForSpecialGroups.AsNoTracking();
        }

        public override IQueryable<RelatedSkuForSpecialGroup> Get(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public override bool Update(RelatedSkuForSpecialGroup t)
        {
            throw new NotImplementedException();
        }
    }
}
