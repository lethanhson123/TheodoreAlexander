using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class TypeEntityService : ITAWEntityService<DAL.Type, Guid>
    {

        public TypeEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(DAL.Type t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<DAL.Type> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<DAL.Type> Get()
        {
            return _ctx.Types.AsNoTracking();
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

        public override bool Update(DAL.Type t)
        {
            throw new NotImplementedException();
        }
    }
}
