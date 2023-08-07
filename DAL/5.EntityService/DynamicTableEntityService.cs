using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.ViewModels;

namespace DAL.EntityService
{
    public class DynamicTableEntityService : ITAWEntityService<Guid, Guid>
    {
        public DynamicTableEntityService(TheodoreAlexanderEntities ctx):base(ctx)
        {
           
        }
        public bool IsShowInStock(string Country)
        {
            try
            {
                return _ctx.DynamicTables.Any(o =>
                                        o.TableName == "InstockProgram" &&
                                        o.ColumnName == "AllowCountry" &&
                                        o.ColumnValue == Country.ToUpper());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsAllowMSRP(string Country)
        {
            try
            {
                return _ctx.DynamicTables.Any(o =>
                                        o.TableName == "MSRP" &&
                                        o.ColumnName == "AllowCountry" &&
                                        o.ColumnValue == Country.ToUpper());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override IQueryable<Guid> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Guid> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(Guid t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Guid t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
