using System;
using System.Linq;
using DAL;

namespace DAL.EntityService
{
    public class ExclusivityGroupEntityService : ITAWEntityService<ExclusivityGroup, Guid>
    {
        public ExclusivityGroupEntityService(TheodoreAlexanderEntities ctx):base(ctx)
        {
            
        }
        public IQueryable<ExclusivityGroup> GetExclusivityGroupsById_Queryable(Guid? Id)
        {
            return _ctx.ExclusivityGroups.Where(o => o.ID == Id);
        }

        public ExclusivityGroup GetExclusivityGroupsById(Guid? Id)
        {
            return _ctx.ExclusivityGroups.FirstOrDefault(o => o.ID == Id);
        }

        public override IQueryable<ExclusivityGroup> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<ExclusivityGroup> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(ExclusivityGroup t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(ExclusivityGroup t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
