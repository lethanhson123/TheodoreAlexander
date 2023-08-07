using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityService
{
    public class DealerEntityService : ITAWEntityService<Dealer, Guid>
    {
        public DealerEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }
        public IQueryable<Dealer> GetDealerByUserId_Queryable(Guid? Id)
        {
            var result = _ctx.Dealers.Where(o => o.User_ID == Id);
            return result;
        }

        public Dealer GetDealerByUserId(Guid? Id)
        {
            try
            {
                return _ctx.Dealers.FirstOrDefault(o => o.User_ID == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Store> GetUserStoreID(Guid UserId)
        {
            var storeIds = _ctx.Dealers.Where(d => d.User_ID == UserId).SelectMany(s => s.Stores).Union(
                _ctx.SalesAssociate_Store.Where(ss => ss.SalesAssociate.User_ID == UserId).Select(s => s.Store));
            return storeIds;
        }

        public ObjectResult<usp_GetDealerBillingAddressByUserID_Result> GetDealerBillingAddressByUserID(Guid UserId)
        {
            return _ctx.usp_GetDealerBillingAddressByUserID(UserId);
        }

        public ObjectResult<usp_GetDealerShippingAddressByUserID_Result> GetDealerShippingAddressByUserID(Guid UserId)
        {
            return _ctx.usp_GetDealerShippingAddressByUserID(UserId);
        }

        public ObjectResult<usp_GetDealerPageSettingsByUserID_Result> GetDealerPageSettingsByUserID(Guid UserId)
        {
            return _ctx.usp_GetDealerPageSettingsByUserID(UserId);
        }

        public IQueryable<Store> GetStores()
        {
            return _ctx.Stores;
        }

        public async Task<bool> UpdateDealerStore(Store store)
        {
            try
            {
                _ctx.Entry(store).State = EntityState.Modified;
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateDealer(Dealer dealer)
        {
            try
            {
                _ctx.Entry(dealer).State = EntityState.Modified;
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override IQueryable<Dealer> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Dealer> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(Dealer t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dealer t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
