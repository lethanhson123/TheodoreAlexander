using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL.EntityService
{
    public class SubcribedEmailEntityServices : ITAWEntityService<SubcribedEmail, Guid>
    {
        public SubcribedEmailEntityServices(TheodoreAlexanderEntities ctx) : base (ctx)
        {

        }

        public override bool Add(SubcribedEmail t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<SubcribedEmail> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<SubcribedEmail> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubcribedEmail> GetAllSubcribedEmail()
        {
            return _ctx.SubcribedEmails;
        }

        public async Task<bool> RegisterSubcribedEmail(SubcribedEmail subcribedEmail)
        {
            try
            {
                _ctx.SubcribedEmails.Add(subcribedEmail);
                var result = await SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Update(SubcribedEmail t)
        {
            throw new NotImplementedException();
        }
    }
}
