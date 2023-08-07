using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.EntityService
{
    public class CountryEntityService : ITAWEntityService<Country, Guid>
    {
        public CountryEntityService(TheodoreAlexanderEntities ctx):base(ctx)
        {
           
        }

        public IQueryable<Country> GetCountryById_Queryable(Guid? Id)
        {
            return _ctx.Countries.Where(o => o.ID == Id);
        }

        public Country GetCountryById(Guid? Id)
        {
            return _ctx.Countries.FirstOrDefault(o => o.ID == Id);
        }

        public IQueryable<Country> GetCountries()
        {
            return _ctx.Countries.AsNoTracking().OrderBy(o => o.Name);
        }

        public override IQueryable<Country> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Country> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(Country t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Country t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
