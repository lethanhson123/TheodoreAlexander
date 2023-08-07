using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class RoomEntityService : ITAWEntityService<RoomAndUsage, Guid>
    {

        public RoomEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(RoomAndUsage t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<RoomAndUsage> Get()
        {
            return _ctx.RoomAndUsages.AsNoTracking();
        }

        public override IQueryable<RoomAndUsage> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Guid> GetIdsFromNames(string names)
        {
            if (!String.IsNullOrEmpty(names))
            {
                string[] namesArray = names.Split(',');
                return this.Get().Where(c => namesArray.Any(ca => ca == c.Name)).Select(c => c.ID);
            }
            else
            {
                return new List<Guid>().AsQueryable();
            }
        }

        public override bool Update(RoomAndUsage t)
        {
            throw new NotImplementedException();
        }
    }
}
