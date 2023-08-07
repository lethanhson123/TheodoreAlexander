using BL.CustomExceptions;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL.BusinessService
{
    public class ContactBusinessService
    {
        public ListContactSubject GetContactSubjects(bool isDealer)
        {
            ListContactSubject listContactSubject = new ListContactSubject();
            listContactSubject.Subjects.Add(new ContactSubjectViewModel { Name = "General Inquiries" });
            listContactSubject.Subjects.Add(new ContactSubjectViewModel { Name = "Product Inquiries" });
            listContactSubject.Subjects.Add(new ContactSubjectViewModel { Name = "Questions About Product I Own" });
            listContactSubject.Subjects.Add(new ContactSubjectViewModel { Name = "Trade Inquiries" });
            listContactSubject.Subjects.Add(new ContactSubjectViewModel { Name = "Public Relations" });
            if (isDealer)
            {
                listContactSubject.Subjects.Add(new ContactSubjectViewModel { Name = "Shopping Cart Questions" });
                listContactSubject.Subjects.Add(new ContactSubjectViewModel { Name = "Order Status" });
                listContactSubject.Subjects.Add(new ContactSubjectViewModel { Name = "Marketing" });
            }
            return listContactSubject;
        }

        public async Task<string> RenderContactEmail(string content)
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

        public async Task<string> RenderTradeEmail(string content)
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

        public async Task<bool> SendContactEmail(ContactRequestObj contactRequestObj)
        {
            try
            {
                string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                string emailTo = ConfigurationManager.AppSettings["ContactUsEmailTo"];

                StringBuilder sb = new StringBuilder("A customer has asked a question through TA web site:<br/><br/><table width='100%'>");
                sb.Append("<tr><td width='35%'>Subject: </td><td>").Append(contactRequestObj.Subject).Append("</td></tr>");
                sb.Append("<tr><td>Email address: </td><td>").Append(contactRequestObj.Email).Append("</td></tr>");
                sb.Append("<tr><td>Daytime phone number: </td><td>").Append(contactRequestObj.Phone).Append("</td></tr>");
                if (!String.IsNullOrEmpty(contactRequestObj.SKU))
                {
                    string productLink = String.Format("{0}/product-detail/{1}", ConfigurationManager.AppSettings["WebURL"],contactRequestObj.SKU);
                    sb.Append("<tr><td>SKU: </td><td><a target='_blank' href='"+productLink+"'>").Append(contactRequestObj.SKU).Append("</a></td></tr>");
                }
                sb.Append("<tr><td>Message: </td><td>").Append(contactRequestObj.Message).Append("</td></tr>");
                sb.Append("</table>");
                string body = await RenderContactEmail(sb.ToString());
                bool sendMailSuccess = await Helper.SendMail(emailFrom, emailFrom, emailTo, emailTo, "Please contact this customer", body);
                return sendMailSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SendRalphLaurenInquiriesEmail(RalphLaurenInquiriesModel model)
        {
            try
            {
                string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                string emailTo = ConfigurationManager.AppSettings["TradeEnquiryEmailTo"];

                string body = string.Empty;
                string header = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/assets/Template/RalphLaurenInquiriesToSale.html")))
                {
                    body = await reader.ReadToEndAsync();
                }

                string sirVEmailHeaderImg = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/Common/e-header.gif";
                bool checkImgExists = await Helper.CheckFileExistsAsync(sirVEmailHeaderImg);
                if (checkImgExists)
                {
                    header = sirVEmailHeaderImg;
                }
                body = body.Replace("[hplMain]", ConfigurationManager.AppSettings["WebURL"]);
                body = body.Replace("[WebURL]", ConfigurationManager.AppSettings["WebURL"]);
                body = body.Replace("[imgHeader]", header);
                body = body.Replace("[Name]", model.Name);
                body = body.Replace("[Email]", model.Email);
                body = body.Replace("[BusinessName]", model.BusinessName);
                body = body.Replace("[DaytimePhone]", model.DaytimePhone);
                body = body.Replace("[StateProvince]", model.StateProvince);
                body = body.Replace("[ZipPostalCode]", model.ZipPostalCode);
                body = body.Replace("[Country]", model.Country);
                body = body.Replace("[Address]", model.Address);
                body = body.Replace("[Message]", model.Message);
                //await Helper.SendMail(emailFrom, emailFrom, "wjohan@theodorealexander.com", "wjohan@theodorealexander.com", "Ralph Lauren Home Design Trade Inquiry", body);
                //await Helper.SendMail(emailFrom, emailFrom, "swells@theodorealexander.com", "swells@theodorealexander.com", "Ralph Lauren Home Design Trade Inquiry", body);
                return await Helper.SendMail(emailFrom, emailFrom, emailTo, emailTo, "Ralph Lauren Home Design Trade Inquiry", body);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SendApplyVNCandidateEmail(ApplyJobVNCandidatetObj model)
        {
            try
            {
                string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                string emailTo = ConfigurationManager.AppSettings["SendEmailApplyVNJobTo"];

                string body = string.Empty;
                string header = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/assets/Template/ApplyJobVNCandidate.html")))
                {
                    body = await reader.ReadToEndAsync();
                }

                string sirVEmailHeaderImg = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/Common/e-header.gif";
                bool checkImgExists = await Helper.CheckFileExistsAsync(sirVEmailHeaderImg);
                if (checkImgExists)
                {
                    header = sirVEmailHeaderImg;
                }
                body = body.Replace("[hplMain]", ConfigurationManager.AppSettings["WebURL"]);
                body = body.Replace("[WebURL]", ConfigurationManager.AppSettings["WebURL"]);
                body = body.Replace("[imgHeader]", header);
                body = body.Replace("[NAME]", model.Name);
                body = body.Replace("[EMAIL]", model.Email);
                body = body.Replace("[PHONE]", model.Phone);
                body = body.Replace("[EXPERIENCE]", model.Experience);
                body = body.Replace("[DESIREDJOB]", model.DesiredJob);
                body = body.Replace("[MEDIASOURCES]", model.MediaSources);
                //await Helper.SendMail(emailFrom, emailFrom, "wjohan@theodorealexander.com", "wjohan@theodorealexander.com", "Ralph Lauren Home Design Trade Inquiry", body);
                //await Helper.SendMail(emailFrom, emailFrom, "swells@theodorealexander.com", "swells@theodorealexander.com", "Ralph Lauren Home Design Trade Inquiry", body);
                return await Helper.SendMail(emailFrom, emailFrom, emailTo, emailTo, "An Application Form Has Been Submitted", body);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> SendTradeEmail(TradeEnquiriesViewModel tradeEnquiriesViewModel)
        {
            try
            {
                string emailFrom = ConfigurationManager.AppSettings["EmailFromTrade"];
                string emailTo = ConfigurationManager.AppSettings["TradeEnquiryEmailTo"];
                StringBuilder sb = new StringBuilder("A Trade Enquiry has been received through the TA web site:<br/><br/><table width='100%'>");
                sb.Append("<tr><td width='35%'>Name: </td><td>").Append(tradeEnquiriesViewModel.Name).Append("</td></tr>");
                sb.Append("<tr><td>Daytime Phone Number: </td><td>").Append(tradeEnquiriesViewModel.Phone).Append("</td></tr>");
                sb.Append("<tr><td>Email address: </td><td>").Append(tradeEnquiriesViewModel.Email).Append("</td></tr>");
                sb.Append("<tr><td>Store Name: </td><td>").Append(tradeEnquiriesViewModel.StoreName).Append("</td></tr>");
                sb.Append("<tr><td>Address Line 1: </td><td>").Append(tradeEnquiriesViewModel.Address1).Append("</td></tr>");
                sb.Append("<tr><td>Address Line 2: </td><td>").Append(tradeEnquiriesViewModel.Address2).Append("</td></tr>");
                sb.Append("<tr><td>City: </td><td>").Append(tradeEnquiriesViewModel.City).Append("</td></tr>");
                sb.Append("<tr><td>State/Province: </td><td>").Append(tradeEnquiriesViewModel.State).Append("</td></tr>");
                sb.Append("<tr><td>Country: </td><td>").Append(tradeEnquiriesViewModel.Country).Append("</td></tr>");
                sb.Append("<tr><td>Zip / Postal Code: </td><td>").Append(tradeEnquiriesViewModel.ZipCode).Append("</td></tr>");
                sb.Append("<tr><td>Your end consumer: </td><td>").Append(tradeEnquiriesViewModel.EndConsumer).Append("</td></tr>");
                sb.Append("<tr><td>Number of Stores: </td><td>").Append(tradeEnquiriesViewModel.NumberOfStores).Append("</td></tr>");
                sb.Append("<tr><td>Your position at primary store: </td><td>").Append(tradeEnquiriesViewModel.PositionAtPrimaryStore).Append("</td></tr>");
                sb.Append("<tr><td>Store Website Url: </td><td>").Append(tradeEnquiriesViewModel.StoreWebAddress).Append("</td></tr>");
                sb.Append("<tr><td>Any Additional Information or Questions?: </td><td>").Append(tradeEnquiriesViewModel.Questions).Append("<br/>");
                sb.Append("</table>");
                string body = await RenderTradeEmail(sb.ToString());
                bool sendMailSuccess = await Helper.SendMail(emailFrom, emailFrom, emailTo, emailTo, "Please contact this customer", body);
                return sendMailSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
