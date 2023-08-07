using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class OptionEntityService : ITAWEntityService<Option, Guid>
    {

        public OptionEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(Option t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Option> Get()
        {
            throw new NotImplementedException(); //return _ctx.Options.AsNoTracking();
        }

        public override IQueryable<Option> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Option t)
        {
            throw new NotImplementedException();
        }
    }
}
