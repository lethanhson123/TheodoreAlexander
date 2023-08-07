using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class LifeStyleEntityService : ITAWEntityService<LifeStyle, Guid>
    {

        public LifeStyleEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(LifeStyle t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<LifeStyle> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<DAL.LifeStyle> Get()
        {
            return _ctx.LifeStyles.AsNoTracking();
        }

        public IQueryable<Guid> GetIdsFromNames(string names)
        {
            names = names ?? String.Empty;
            string[] nameArray = names.Split(',');
            return this.Get().Where(c => nameArray.Any(ca => ca == c.Name)).Select(c => c.ID);
        }

        public override bool Update(LifeStyle t)
        {
            throw new NotImplementedException();
        }
    }
}
