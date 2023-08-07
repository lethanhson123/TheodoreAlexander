using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class OptionGroupEntityService : ITAWEntityService<OptionGroup, Guid>
    {
        public OptionGroupEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(OptionGroup t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<OptionGroup> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<OptionGroup> Get()
        {
            return _ctx.OptionGroups.AsNoTracking();
        }

        public IQueryable<Guid> GetIdsFromNames(string names)
        {
            if (!String.IsNullOrEmpty(names))
            {
                string[] namesArray = names.Split(',');
                return this.Get().Where(c => namesArray.Any(ca => ca == c.GroupName)).Select(c => c.ID);
            }
            else
            {
                return new List<Guid>().AsQueryable();
            }
        }

        public override bool Update(OptionGroup t)
        {
            throw new NotImplementedException();
        }
    }
}
