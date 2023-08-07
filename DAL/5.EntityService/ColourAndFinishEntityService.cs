using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class ColourAndFinishEntityService: ITAWEntityService<ColourAndFinish, Guid>
    {
        public ColourAndFinishEntityService(TheodoreAlexanderEntities ctx): base(ctx)
        {

        }

        public override bool Add(ColourAndFinish t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<ColourAndFinish> Get()
        {
            return _ctx.ColourAndFinishes.AsNoTracking();
        }

        public override IQueryable<ColourAndFinish> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Guid> GetIdsFromNames(string names)
        {
            if (!String.IsNullOrEmpty(names))
            {
                string[] namesArray = names.Split(',');
                return _ctx.ColourAndFinishes.AsNoTracking().Where(c => namesArray.Any(ca => ca == c.Name)).Select(c => c.ID);
            }
            else
            {
                return new List<Guid>().AsQueryable();
            }
        }

        public override bool Update(ColourAndFinish t)
        {
            throw new NotImplementedException();
        }
    }
}
