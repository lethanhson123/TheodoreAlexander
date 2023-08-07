using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.EntityService
{
    public class RegionEntityService: ITAWEntityService<Region, Guid>
    {
        public RegionEntityService(TheodoreAlexanderEntities ctx):base(ctx)
        {

        }

        public override bool Add(Region t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Region> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Region> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Region> GetRegions()
        {
            return _ctx.Regions.AsNoTracking().OrderBy(o => o.Name);
        }

        public override bool Update(Region t)
        {
            throw new NotImplementedException();
        }
    }
}
