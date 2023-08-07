using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.EntityService
{
    public class DealerGroup_RegionEntityService : ITAWEntityService<DealerGroup_Region, Guid>
    {
        public DealerGroup_RegionEntityService(TheodoreAlexanderEntities ctx):base(ctx)
        {
            
        }

        public override bool Add(DealerGroup_Region t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<DealerGroup_Region> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<DealerGroup_Region> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DealerGroup_Region> GetDealerGroup_Region()
        {
            return _ctx.DealerGroup_Region.AsNoTracking();
        }

        public DealerGroup_Region GetDealerGroup_Region(string dealergroup)
        {
            return GetDealerGroup_Region().FirstOrDefault(o => o.dealergroup == dealergroup);
        }

        public override bool Update(DealerGroup_Region t)
        {
            throw new NotImplementedException();
        }
    }
}
