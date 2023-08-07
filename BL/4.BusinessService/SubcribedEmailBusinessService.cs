using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.CustomExceptions;
using DAL.ViewModels;
using DAL;
using System.Transactions;
using TA_Web_2020_API.Helper;
using BL.EntityService;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class SubcribedEmailBusinessService
    {
        private readonly SubcribedEmailEntityServices _subcribedEmailServices;
        private bool disposed = false;
        public SubcribedEmailBusinessService(SubcribedEmailEntityServices subcribedEmailServices)
        {
            _subcribedEmailServices = subcribedEmailServices;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _subcribedEmailServices.Dispose();
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> RegisterSubcribedEmail(SubcribedEmailResigterObj subcribedEmailResigterObj, JWTIdentityViewModel jwtModel)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    new TAEmailMarketer().AddSubscriberMember(subcribedEmailResigterObj.Email, jwtModel.Region);
                    //Helper.AddSubscriberMember(subcribedEmailResigterObj.Email, jwtModel.Region);
                    var checkEmailExists = await _subcribedEmailServices.GetAllSubcribedEmail().Where(e => e.Email.Equals(subcribedEmailResigterObj.Email)).FirstOrDefaultAsync();
                    if (checkEmailExists != null)
                    {
                        return true;
                    }
                    var result = false;
                    SubcribedEmail subcribedEmail = new SubcribedEmail
                    {
                        ID = Guid.NewGuid(),
                        Email = subcribedEmailResigterObj.Email,
                        DateCreated = DateTime.Now
                    };
                    result = await _subcribedEmailServices.RegisterSubcribedEmail(subcribedEmail);
                    scope.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }

            }
        }
        public async Task<bool> RegisterSubcribedEmail2021(string email, JWTIdentityViewModel jwtModel)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    new TAEmailMarketer().AddSubscriberMember(email, jwtModel.Region);
                    //Helper.AddSubscriberMember(subcribedEmailResigterObj.Email, jwtModel.Region);
                    var checkEmailExists = await _subcribedEmailServices.GetAllSubcribedEmail().Where(e => e.Email.Equals(email)).FirstOrDefaultAsync();
                    if (checkEmailExists != null)
                    {
                        return true;
                    }
                    var result = false;
                    SubcribedEmail subcribedEmail = new SubcribedEmail
                    {
                        ID = Guid.NewGuid(),
                        Email = email,
                        DateCreated = DateTime.Now
                    };
                    result = await _subcribedEmailServices.RegisterSubcribedEmail(subcribedEmail);
                    scope.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }

            }
        }

        public async Task<List<SubcribedEmailViewModel>> GetAllSubcribedEmail()
        {
            var lstEmail = await _subcribedEmailServices.GetAllSubcribedEmail().ToListAsync();
            List<SubcribedEmailViewModel> subcribedEmailViews = new List<SubcribedEmailViewModel>();
            foreach(var item in lstEmail)
            {
                subcribedEmailViews.Add(new SubcribedEmailViewModel
                {
                    Email = item.Email
                });
            }
            return subcribedEmailViews;
        }
    }
}
