using BL.BusinessService;
using BL.DTO;
using DAL.ViewModels;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BL.BUServices
{
    public interface IContactService : IDisposable
    {
        Task<bool> SendEmailItem(RequestSendEmailItemObj obj);
    }
    public class ContactService: IContactService
    {
        private readonly ItemBusinessService _itemService;
        private bool disposed = false;
        public ContactService(ItemBusinessService itemService)
        {
            this._itemService = itemService;
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _itemService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SendEmailItem(RequestSendEmailItemObj obj)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                bool result = true;
                try
                {
                    {
                        {
                            string _noReplyEmail = ConfigurationManager.AppSettings["SMTPno-reply"];
                            {
                                ItemDto product = await _itemService.GetItemData(null, null, new Guid(obj.ItemId), null);
                                string body = await Helper.RenderEmailProduct(obj.FromName, obj.FromEmail, obj.ToName, obj.Message, product);
                                await Helper.SendMail("Theodore Alexander", _noReplyEmail, obj.ToName, obj.ToEmail, obj.FromName + " has some design inspiration for you", body);
                                if (obj.IsSendCopy)
                                {
                                    await Helper.SendMail("Theodore Alexander", _noReplyEmail, obj.ToName, obj.FromEmail, obj.FromName + " has some design inspiration for you", body);
                                }
                            }
                        }
                    }
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
    }
}
