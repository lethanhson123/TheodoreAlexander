using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class BrandEntityService : ITAWEntityService<Brand, Guid>
    {

        public BrandEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(Brand t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Brand> Get()
        {
            return _ctx.Brands.AsNoTracking();
        }

        public override IQueryable<Brand> Get(Guid id)
        {
            return _ctx.Brands.AsNoTracking().Where(i => i.ID == id);
        }

        public override bool Update(Brand t)
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
    }
}
