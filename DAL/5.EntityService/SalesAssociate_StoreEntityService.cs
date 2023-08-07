using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DAL.ViewModels;

namespace DAL.EntityService
{
    public class SalesAssociate_StoreEntityService : ITAWEntityService<SalesAssociate_Store, Guid>
    {
        public SalesAssociate_StoreEntityService(TheodoreAlexanderEntities ctx):base(ctx)
        {
            
        }
        public IQueryable<SalesAssociate_Store> GetSalesAssociate_StoresByUserId_Queryable(Guid? Id)
        {
            return _ctx.SalesAssociate_Store.Where(o => o.SalesAssociate.User_ID == Id);
        }

        public SalesAssociate_Store GetSalesAssociate_StoresByUserId(Guid? Id)
        {
            return _ctx.SalesAssociate_Store.FirstOrDefault(o => o.SalesAssociate.User_ID == Id);
        }

        public IQueryable<SalesAssociate_Store> GetSalesAssociate_Stores()
        {
            return _ctx.SalesAssociate_Store;
        }

        public async Task<bool> RemoveAssociate(SalesAssociate_Store salesAssociate)
        {
            _ctx.SalesAssociate_Store.Remove(salesAssociate);
            var result = await SaveChangesAsync();
            return result;
        }

        public async Task<bool> UpdateSalesAssociateStore(SalesAssociate_Store salesAssociate)
        {
            try
            {
                _ctx.Entry(salesAssociate).State = EntityState.Modified;
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RevokeAssociate(SalesAssociate_Store salesAssociate)
        {
            try
            {
                User user = salesAssociate.SalesAssociate.User;
                _ctx.SalesAssociate_Store.Remove(salesAssociate);
                user.UserType_ID = new Guid(LocalUserTypeId.Consumer);
                _ctx.Entry(user).State = EntityState.Modified;
                var result = await SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ApproveAssociateRequest(SalesAssociate_Store salesAssociate)
        {
            try
            {
                salesAssociate.DealerApproved = true;
                User user = salesAssociate.SalesAssociate.User;
                _ctx.Entry(salesAssociate).State = EntityState.Modified;
                user.UserType_ID = new Guid(LocalUserTypeId.SalesAssociate);
                _ctx.Entry(user).State = EntityState.Modified;
                var result = await SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override IQueryable<SalesAssociate_Store> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<SalesAssociate_Store> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(SalesAssociate_Store t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(SalesAssociate_Store t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
