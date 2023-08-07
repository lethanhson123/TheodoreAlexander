using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;

namespace DAL.EntityService
{
    public class CityEntityServices :ITAWEntityService<City, Guid>
    {

        public CityEntityServices(TheodoreAlexanderEntities ctx):base(ctx)
        {
            
        }

        public override bool Add(City t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<City> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<City> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<City> GetCities()
        {
            return _ctx.Cities.AsNoTracking().OrderBy(c => c.Name);
        }

        public override bool Update(City t)
        {
            throw new NotImplementedException();
        }
    }
}
