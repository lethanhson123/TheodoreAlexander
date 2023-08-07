using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class StyleEntityService : ITAWEntityService<Style, Guid>
    {

        public StyleEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(Style t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Style> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<DAL.Style> Get()
        {
            return _ctx.Styles.AsNoTracking();
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

        public override bool Update(Style t)
        {
            throw new NotImplementedException();
        }
    }
}
