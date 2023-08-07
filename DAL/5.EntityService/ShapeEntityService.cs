using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class ShapeEntityService : ITAWEntityService<Shape, Guid>
    {

        public ShapeEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override bool Add(Shape t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Shape> Get()
        {
            return _ctx.Shapes.AsNoTracking();
        }

        public override IQueryable<Shape> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DAL.Shape> GetAll()
        {
            return _ctx.Shapes.AsNoTracking();
        }
        public IQueryable<Guid> GetIdsFromNames(string names)
        {
            if (!String.IsNullOrEmpty(names))
            {
                string[] namesArray = names.Split(',');
                return this.GetAll().Where(c => namesArray.Any(ca => ca == c.Name)).Select(c => c.ID);
            }
            else
            {
                return new List<Guid>().AsQueryable();
            }
        }

        public override bool Update(Shape t)
        {
            throw new NotImplementedException();
        }
    }
}
