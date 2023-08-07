using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class udf_FreeTextSearchEntityService : ITAWEntityService<udf_FreeTextSearch_Result, Guid>
    {
        public udf_FreeTextSearchEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {
            
        }

        public override bool Add(udf_FreeTextSearch_Result t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<udf_FreeTextSearch_Result> Search(string text)
        {
            return _ctx.udf_FreeTextSearch(text);
        }

        public override IQueryable<udf_FreeTextSearch_Result> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<udf_FreeTextSearch_Result> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(udf_FreeTextSearch_Result t)
        {
            throw new NotImplementedException();
        }
    }
}
