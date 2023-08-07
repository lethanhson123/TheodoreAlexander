using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ViewModels;
using DAL.QuotationDB;
using BL.EntityService;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Transactions;
using BL.CustomExceptions;
using TA_Web_2020_API.Helper;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class QuotationBusinessService
    {
        private bool disposed = false;
        private readonly QuotationEntityService _quotationServices;

        public QuotationBusinessService(QuotationEntityService quotationServices)
        {
            _quotationServices = quotationServices;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _quotationServices.Dispose();
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
        public async Task<long> AddQuotation(RequestQuoteObj quotationViewModel)
        {
            Request request = new Request
            {
                Types = quotationViewModel.Types,
                Name = quotationViewModel.Name,
                Email = quotationViewModel.Email,
                Phone = quotationViewModel.Phone,
                Designer = quotationViewModel.Designer ? "Yes" : "No",// not use for new website
                Detail = quotationViewModel.Detail,
                Item = quotationViewModel.Item,
                Brand = quotationViewModel.Brand,
                Collection = quotationViewModel.Collection,
                RoomAndUsage = quotationViewModel.RoomAndUsage,
                ProductType = quotationViewModel.ProductType,
                LifeStyle = quotationViewModel.LifeStyle,
                ProductStyle = quotationViewModel.ProductStyle,
                City = quotationViewModel.City,
                State = quotationViewModel.State,
                Zip = quotationViewModel.Zip,
                Country = quotationViewModel.Country,
                RequestDate = DateTime.UtcNow
            };
            bool rtn = await _quotationServices.AddQuatation(request);
            if (rtn)
            {
                return request.ID;
            }
            return 0;
        }

        public IQueryable<Request> GetQuotations() {
            return this._quotationServices.GetQuotations();
        }

        public async Task<bool> QuotationRequestProcess(RequestQuoteObj quotationViewModel, HttpContext request, JWTIdentityViewModel jwtModel)
        {
            var result = true;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    long addQuotation = await AddQuotation(quotationViewModel);
                    bool sendMailSuccess = false;
                    if (addQuotation == 0)
                    {
                        result = false;
                        scope.Dispose();
                        return result;
                    }
                    //Helper.AddRequestQuoteMember(quotationViewModel.Email, jwtModel.Region);
                    new TAEmailMarketer().AddRequestQuoteMember(quotationViewModel.Email, jwtModel.Region);

                    sendMailSuccess = await SendQuotationRequestEmail(quotationViewModel, request);
                    if (!sendMailSuccess)
                    {
                        result = false;
                        scope.Dispose();
                        return result;
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

        public async Task<bool> SendQuotationRequestEmail(RequestQuoteObj quotationViewModel, HttpContext request)
        {
            try
            {
                string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                string webUrl = ConfigurationManager.AppSettings["WebURL"];
                //string emailFrom = "duyhau.206@gmail.com";
                string emailTo = ConfigurationManager.AppSettings["RequestQuoteEmailTo"]; //"hdhau@theodorealexander.com"; 
                string about = !quotationViewModel.IsWishListItem
                               ? "this product"
                               : "products in a lookbook";
                string link = "<a href=\""+webUrl+"/product-detail/" + quotationViewModel.ItemId + "\">" + about + "</a>"; //setup link by new web site url waiting frontend

                StringBuilder sb =
                    new StringBuilder("You've received a new request for a price quote for " + link + ".<br/>All the contact information for the sender, plus a few additional pieces of personal information are listed for you below.<br/><br />");

                sb.Append("<table width='100%'>");
                sb.Append("<tr><td width='35%'><b>Name:</b> </td><td>").Append(quotationViewModel.Name).Append("</td></tr>");
                sb.Append("<tr><td><b>Daytime Phone Number:</b> </td><td>").Append(quotationViewModel.Phone).Append("</td></tr>");
                sb.Append("<tr><td><b>Email address:</b> </td><td>").Append(quotationViewModel.Email).Append("</td></tr>");
                sb.Append("<tr><td><b>Address: </b></td><td>").Append(quotationViewModel.Address).Append("</td></tr>");
                sb.Append("<tr><td><b>City: </b></td><td>").Append(quotationViewModel.City).Append("</td></tr>");
                sb.Append("<tr><td><b>State/Province: </b></td><td>").Append(quotationViewModel.State).Append("</td></tr>");
                sb.Append("<tr><td><b>Country: </b></td><td>").Append(quotationViewModel.Country).Append("</td></tr>");
                sb.Append("<tr><td><b>Zip / Postal Code:</b> </td><td>").Append(quotationViewModel.Zip).Append("</td></tr>");
                sb.Append("<tr><td><b>Comments:</b> </td><td>").Append(quotationViewModel.Detail).Append("</td></tr>");
                sb.Append("<tr><td><b>Preferred Contact Media:</b> </td><td>").Append(quotationViewModel.PreferredContactMedia).Append("</td></tr>");
                sb.Append("<tr><td><b>Are you a designer:</b> </td><td>").Append(quotationViewModel.Designer ? "Yes" : "No").Append("</td></tr>");

                //================ New website layout have no Preferred Contact and Check Designer

                //sb.Append("<tr><td><b>Preferred Contact Media:</b> </td><td>").Append(rblContactRequestQuote.SelectedValue).Append(
                //    "</td></tr>");
                //sb.Append("<tr><td><b>Are you a designer: </b></td><td>").Append(rblDesignerRequestQuote.SelectedValue).Append(
                //    "</td></tr>");
                //sb.Append("<tr><td>" + rblDesignerRequestQuote.SelectedValue == "Yes"
                //              ? "Receive A Quote From: </td><td>" + rblFromRequestQuote.SelectedValue
                //              : "").Append("</td></tr>");

                if (quotationViewModel.IsWishListItem)
                {
                    if (quotationViewModel.WishListItems.Count() > 0)
                    {
                        foreach (var item in quotationViewModel.WishListItems)
                        {
                            //sb.Append(GenerateProductLink(dataRow["ProductName"] as string, dataRow["ID"].ToString(), Request.Url.AbsoluteUri.ToString(), true));
                            sb.Append("<a href=\""+webUrl+"/product-detail/" + item.ID + "\">" + item.SKU + "</a>");
                            sb.Append("<tr><td>SKU: </td><td>").Append(item.SKU).Append("</td></tr>");
                            sb.Append("<tr><td colspan='2' align='left'><b>&nbsp;</b></td><tr>");
                        }
                    }
                }
                else
                {
                    sb.Append("<tr><td colspan='2' align='left'><b>&nbsp;</b></td><tr>");
                    sb.Append("<tr><td colspan='2' align='left'><b>Requested Items</b></td><tr>");
                    sb.Append("<a href=\""+webUrl+"\\product-detail\\" + quotationViewModel.ItemId + "\">" + quotationViewModel.Item + "</a>");
                    sb.Append("<tr><td>SKU: </td><td>").Append(quotationViewModel.Item).Append("</td></tr>");
                    sb.Append("<tr><td colspan='2' align='left'><b>&nbsp;</b></td><tr>");
                }
                string body = await RenderQuotationEmail(sb.ToString(), request);
                bool sendMailSuccess = await Helper.SendMail(emailFrom, emailFrom, emailTo, emailTo, "Request A Quote", body);
                if (quotationViewModel.IsSendCopy) {
                    await Helper.SendMail(emailFrom, emailFrom, quotationViewModel.Email, quotationViewModel.Email, "Request A Quote", body);
                }
                return sendMailSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> RenderQuotationEmail(string content, HttpContext request)
        {
            try
            {
                string body = string.Empty;
                string header = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/assets/Template/EmailTemplate.html")))
                {
                    body = await reader.ReadToEndAsync();
                }
                //using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/assets/images/e-header.gif")))
                //{
                //    header = await reader.ReadToEndAsync();
                //}
                string sirVEmailHeaderImg = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/Common/e-header.gif";
                bool checkImgExists = await Helper.CheckFileExistsAsync(sirVEmailHeaderImg);
                if (checkImgExists)
                {
                    header = sirVEmailHeaderImg;
                }
                body = body.Replace("[hplMain]", ConfigurationManager.AppSettings["WebURL"]);
                body = body.Replace("[WebURL]", ConfigurationManager.AppSettings["WebURL"]);
                body = body.Replace("[imgHeader]", header);
                body = body.Replace("[ltlMessage]", content);
                return body;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
