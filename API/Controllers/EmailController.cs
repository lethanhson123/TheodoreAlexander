using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Data.ViewModels;
using TA.Helpers;

namespace TA.API.Controllers
{

    public class EmailController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IShoppingCart_ItemRepository _shoppingCart_ItemRepository;
        public EmailController(IShoppingCart_ItemRepository shoppingCart_ItemRepository, IShoppingCartRepository shoppingCartRepository, IWebHostEnvironment webHostEnvironment) : base()
        {
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingCart_ItemRepository = shoppingCart_ItemRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task<int> AsyncSendNotUserNameAndPasswordByHR_Recruitment_Career(HR_Recruitment_Career hR_Recruitment_Career)
        {
            Mail mail = new Mail();
            GetMailBodyHR_Recruitment_Career(hR_Recruitment_Career, mail);
            await Mail.AsyncSendNotUserNameAndPassword(mail);
            return 1;
        }
        [HttpPost]
        public async Task<int> AsyncSendNotUserNameAndPasswordByHR_Recruitment_Introduce(HR_Recruitment_Introduce hR_Recruitment_Introduce)
        {
            Mail mail = new Mail();
            GetMailBodyHR_Recruitment_Introduce(hR_Recruitment_Introduce, mail);
            await Mail.AsyncSendNotUserNameAndPassword(mail);
            return 1;
        }
        [HttpGet]
        public async Task<string> AsyncSendNotUserNameAndPasswordByShoppingCartForward(string ID)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(ID))
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                ShoppingCart shoppingCart = _shoppingCartRepository.GetByID(ID);
                if (!string.IsNullOrEmpty(shoppingCart.Code))
                {
                    if (shoppingCart.IsActive == true)
                    {
                        string aPIDevCall = AppGlobal.APIDevURL + "Email/AsyncSendNotUserNameAndPasswordByShoppingCartObject";
                        var content = new StringContent(JsonConvert.SerializeObject(shoppingCart), Encoding.UTF8, "application/json");
                        HttpClient client = new HttpClient();
                        var task = client.PostAsync(aPIDevCall, content);
                        result = await task.Result.Content.ReadAsStringAsync();
                    }
                }
            }
            return result;
        }
        [HttpPost]
        public async Task<string> AsyncSendNotUserNameAndPasswordByShoppingCartObject(ShoppingCart shoppingCart)
        {
            string result = AppGlobal.InitializationString;
            try
            {
                Mail mail = new Mail();
                if (shoppingCart != null)
                {
                    if (!string.IsNullOrEmpty(shoppingCart.Code))
                    {
                        if (shoppingCart.IsActive == true)
                        {
                            string url = AppGlobal.API2URL + "ShoppingCart_Item/GetByShoppingCart_IDToList?shoppingCart_ID=" + shoppingCart.ID.Value.ToString();
                            HttpClient client = new HttpClient();
                            string response = await client.GetStringAsync(url);
                            List<ShoppingCart_Item> listShoppingCart_Item = JsonConvert.DeserializeObject<List<ShoppingCart_Item>>(response);
                            if (listShoppingCart_Item != null)
                            {
                                if (listShoppingCart_Item.Count > 0)
                                {
                                    result = await SendMailOrderVersion002(shoppingCart, listShoppingCart_Item, mail);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                Mail mail = new Mail();
                mail.Subject = "Result: Order code #" + shoppingCart.Code + " by " + shoppingCart.Email + " at " + shoppingCart.OrderDate;
                mail.ToMail = shoppingCart.Email;
                mail.Body = result;
                await Mail.AsyncSendNotUserNameAndPassword(mail);
            }
            return result;
        }
        [HttpPost]
        public async Task<string> AsyncSendNotUserNameAndPasswordByShoppingCartViewModel(ShoppingCartViewModel shoppingCartViewModel)
        {
            string result = AppGlobal.InitializationString;
            Mail mail = new Mail();
            ShoppingCart shoppingCart = new ShoppingCart();
            List<ShoppingCart_Item> listShoppingCart_Item = new List<ShoppingCart_Item>();
            shoppingCart = shoppingCartViewModel.ShoppingCart;
            listShoppingCart_Item = shoppingCartViewModel.ListShoppingCart_Item;
            if (shoppingCart != null)
            {
                if (!string.IsNullOrEmpty(shoppingCart.Code))
                {
                    result = await SendMailOrder(shoppingCart, listShoppingCart_Item, mail);
                }
            }
            return result;
        }
        [HttpGet]
        public async Task<string> AsyncSendNotUserNameAndPasswordByShoppingCart(string ID)
        {
            string result = AppGlobal.InitializationString;
            if (!string.IsNullOrEmpty(ID))
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                Mail mail = new Mail();
                ShoppingCart shoppingCart = _shoppingCartRepository.GetByID(ID);
                if (!string.IsNullOrEmpty(shoppingCart.Code))
                {
                    List<ShoppingCart_Item> listShoppingCart_Item = _shoppingCart_ItemRepository.GetByShoppingCart_IDToList(ID);
                    result = await SendMailOrder(shoppingCart, listShoppingCart_Item, mail);
                }
            }
            return result;
        }
        [HttpGet]
        public string CheckSendMail()
        {
            string result = AppGlobal.InitializationString;
            try
            {
                Mail mail = new Mail();
                Mail.Send(mail);
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        [HttpGet]
        public async Task<string> AsyncCheckSendMail()
        {
            Mail mail = new Mail();
            return await Mail.AsyncSendNotUserNameAndPassword(mail);
        }
        [HttpGet]
        public async Task<string> AsyncCallAPIDev()
        {
            string result = AppGlobal.InitializationString;
            try
            {
                HR_Recruitment_Career hR_Recruitment_Career = new HR_Recruitment_Career();
                hR_Recruitment_Career.FullName = "SOHU";
                string aPIDevCall = AppGlobal.APIDevURL + "Email/AsyncSendNotUserNameAndPasswordByHR_Recruitment_Career";
                var content = new StringContent(JsonConvert.SerializeObject(hR_Recruitment_Career), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var task = client.PostAsync(aPIDevCall, content);
                result = await task.Result.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        [HttpGet]
        public string CheckReadFile()
        {
            string result = AppGlobal.InitializationString;
            try
            {
                string fileName = AppGlobal.HR_Recruitment_RegisterHTML;
                string subPath = AppGlobal.Download + "/" + AppGlobal.HTML;
                var physicalPathRead = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
                using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
                {
                    using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                    {
                        result = r.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        private void GetMailBodyHR_Recruitment_Career(HR_Recruitment_Career hR_Recruitment_Career, Mail mail)
        {
            string fileName = AppGlobal.HR_Recruitment_RegisterHTML;
            string subPath = AppGlobal.Download + "/" + AppGlobal.HTML;
            var physicalPathRead = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
            using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                {
                    mail.Body = r.ReadToEnd();
                }
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.FullName))
            {
                hR_Recruitment_Career.FullName = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.Phone))
            {
                hR_Recruitment_Career.Phone = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.Address))
            {
                hR_Recruitment_Career.Address = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.Email))
            {
                hR_Recruitment_Career.Email = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.JobFunction))
            {
                hR_Recruitment_Career.JobFunction = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.Experience))
            {
                hR_Recruitment_Career.Experience = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.MediaSource))
            {
                hR_Recruitment_Career.MediaSource = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.RecommendPhone))
            {
                hR_Recruitment_Career.RecommendPhone = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.RecommendFullName))
            {
                hR_Recruitment_Career.RecommendFullName = AppGlobal.InitializationString;
            }

            mail.Subject = mail.Subject + " - " + hR_Recruitment_Career.FullName + " - " + hR_Recruitment_Career.Phone;
            mail.Body = mail.Body.Replace(@"[FullName]", hR_Recruitment_Career.FullName);
            mail.Body = mail.Body.Replace(@"[Phone]", hR_Recruitment_Career.Phone);
            mail.Body = mail.Body.Replace(@"[Address]", hR_Recruitment_Career.Address);
            mail.Body = mail.Body.Replace(@"[Email]", hR_Recruitment_Career.Email);
            mail.Body = mail.Body.Replace(@"[JobFunction]", hR_Recruitment_Career.JobFunction);
            mail.Body = mail.Body.Replace(@"[Experience]", hR_Recruitment_Career.Experience);
            mail.Body = mail.Body.Replace(@"[MediaSource]", hR_Recruitment_Career.MediaSource);
            mail.Body = mail.Body.Replace(@"[RecommendPhone]", hR_Recruitment_Career.RecommendPhone);
            mail.Body = mail.Body.Replace(@"[RecommendFullName]", hR_Recruitment_Career.RecommendFullName);
        }
        private void GetMailBodyHR_Recruitment_Introduce(HR_Recruitment_Introduce hR_Recruitment_Introduce, Mail mail)
        {
            string fileName = AppGlobal.HR_Recruitment_RecommenderHTML;
            string subPath = AppGlobal.Download + "/" + AppGlobal.HTML;
            var physicalPathRead = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
            using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                {
                    mail.Body = r.ReadToEnd();
                }
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Introduce.FullName))
            {
                hR_Recruitment_Introduce.FullName = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Introduce.Phone))
            {
                hR_Recruitment_Introduce.Phone = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Introduce.BankID))
            {
                hR_Recruitment_Introduce.BankID = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Introduce.BankName))
            {
                hR_Recruitment_Introduce.BankName = AppGlobal.InitializationString;
            }
            mail.Subject = "HR - Recruitment recommender - " + hR_Recruitment_Introduce.FullName + " - " + hR_Recruitment_Introduce.Phone;
            mail.Body = mail.Body.Replace(@"[FullName]", hR_Recruitment_Introduce.FullName);
            mail.Body = mail.Body.Replace(@"[Phone]", hR_Recruitment_Introduce.Phone);
            mail.Body = mail.Body.Replace(@"[BankID]", hR_Recruitment_Introduce.BankID);
            mail.Body = mail.Body.Replace(@"[BankName]", hR_Recruitment_Introduce.BankName);
        }
        private async Task<string> SendMailOrder(ShoppingCart shoppingCart, List<ShoppingCart_Item> listShoppingCart_Item, Mail mail)
        {
            StringBuilder resultList = new StringBuilder();
            GetMailBodyOrder(shoppingCart, listShoppingCart_Item, mail);
            mail.ToMail = shoppingCart.Email;
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");

            mail.ToMail = "trade@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");
            mail.ToMail = "kmullen@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");
            mail.ToMail = "lrogers@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");
            mail.ToMail = "mtaylor@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");
            mail.ToMail = "sholt@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");
            mail.ToMail = "shaire@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");
            try
            {
                mail.ToMail = "CSD_TAUS@theodorealexander.local";
                resultList.AppendLine(mail.ToMail);
                resultList.AppendLine(@"<br/>");
                resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
                resultList.AppendLine(@"<br/>");
            }
            catch
            {
            }

            mail.ToMail = "csd@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");
            mail.ToMail = "dparker@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");

            mail.ToMail = "ludan@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");
            mail.ToMail = "ltson@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");

            //mail.ToMail = "ltson@theodorealexander.com";
            //mail.Subject = mail.Subject + " -  Result";
            //mail.Body = resultList.ToString();
            //await Mail.AsyncSendNotUserNameAndPassword(mail);
            return resultList.ToString();
        }
        private async Task<string> SendMailOrderVersion002(ShoppingCart shoppingCart, List<ShoppingCart_Item> listShoppingCart_Item, Mail mail)
        {
            StringBuilder resultList = new StringBuilder();
            GetMailBodyOrder(shoppingCart, listShoppingCart_Item, mail);

            mail.ToMail = shoppingCart.Email;
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");

            //if (userDataTransfer001 != null)
            //{
            //    if (userDataTransfer001.ISO == AppGlobal.USISO)
            //    {
            //        try
            //        {
            //            mail.ToMail = "CSD_TAUS@theodorealexander.local";
            //            resultList.AppendLine(mail.ToMail);
            //            resultList.AppendLine(@"<br/>");
            //            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            //            resultList.AppendLine(@"<br/>");
            //        }
            //        catch
            //        {
            //        }
            //    }
            //    else
            //    {
            //        mail.ToMail = "csd@theodorealexander.com";
            //        resultList.AppendLine(mail.ToMail);
            //        resultList.AppendLine(@"<br/>");
            //        resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            //        resultList.AppendLine(@"<br/>");
            //        mail.ToMail = "dparker@theodorealexander.com";
            //        resultList.AppendLine(mail.ToMail);
            //        resultList.AppendLine(@"<br/>");
            //        resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            //        resultList.AppendLine(@"<br/>");
            //    }
            //}

            mail.ToMail = "CSD_TAUS@theodorealexander.local";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");

            mail.ToMail = "csd@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");

            mail.ToMail = "dparker@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");

            mail.ToMail = "ludan@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");

            mail.ToMail = "ltson@theodorealexander.com";
            resultList.AppendLine(mail.ToMail);
            resultList.AppendLine(@"<br/>");
            resultList.AppendLine(await Mail.AsyncSendNotUserNameAndPassword(mail));
            resultList.AppendLine(@"<br/>");
            return resultList.ToString();
        }
        private void GetMailBodyOrder(ShoppingCart shoppingCart, List<ShoppingCart_Item> listShoppingCart_Item, Mail mail)
        {
            string fileName = AppGlobal.OrderHTML;
            string subPath = AppGlobal.Download + "/" + AppGlobal.HTML;
            var physicalPathRead = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
            using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                {
                    mail.Body = r.ReadToEnd();
                }
            }
            if (string.IsNullOrEmpty(shoppingCart.StoreName))
            {
                shoppingCart.StoreName = AppGlobal.InitializationString;
            }

            mail.Subject = "Order code #" + shoppingCart.Code + " by " + shoppingCart.Email + " at " + shoppingCart.OrderDate;
            mail.Body = mail.Body.Replace(@"[Code]", shoppingCart.Code);
            mail.Body = mail.Body.Replace(@"[ItemCount]", shoppingCart.ItemCount);
            mail.Body = mail.Body.Replace(@"[Total]", shoppingCart.Total);
            mail.Body = mail.Body.Replace(@"[Volume]", shoppingCart.Volume);
            mail.Body = mail.Body.Replace(@"[FirstName]", shoppingCart.FirstName);
            mail.Body = mail.Body.Replace(@"[LastName]", shoppingCart.LastName);
            mail.Body = mail.Body.Replace(@"[StoreName]", shoppingCart.StoreName);
            mail.Body = mail.Body.Replace(@"[TAUSID]", shoppingCart.TausID);
            mail.Body = mail.Body.Replace(@"[UserName]", shoppingCart.UserName);
            mail.Body = mail.Body.Replace(@"[UserTypeName]", shoppingCart.UserTypeName);
            mail.Body = mail.Body.Replace(@"[AccountNumber]", shoppingCart.AccountNumber);
            if (shoppingCart.OrderDate != null)
            {
                try
                {
                    mail.Body = mail.Body.Replace(@"[OrderDate]", shoppingCart.OrderDate.Value.ToString("MM/dd/yyyy HH:mm:ss tt"));
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    mail.Body = mail.Body.Replace(@"[OrderDate]", AppGlobal.InitializationDateTime.ToString("MM/dd/yyyy HH:mm:ss tt"));
                }
            }
            else
            {
                mail.Body = mail.Body.Replace(@"[OrderDate]", AppGlobal.InitializationDateTime.ToString("MM/dd/yyyy HH:mm:ss tt"));
            }
            mail.Body = mail.Body.Replace(@"[ShippingDate]", shoppingCart.ShippingDate);
            mail.Body = mail.Body.Replace(@"[Email]", shoppingCart.Email);
            mail.Body = mail.Body.Replace(@"[BillingAddressString]", shoppingCart.BillingAddressString);
            mail.Body = mail.Body.Replace(@"[ShippingAddressString]", shoppingCart.ShippingAddressString);
            mail.Body = mail.Body.Replace(@"[ContainerReference]", shoppingCart.ContainerReference);
            mail.Body = mail.Body.Replace(@"[SpecialInstruction]", shoppingCart.SpecialInstruction);

            StringBuilder orderDetail = new StringBuilder();
            foreach (ShoppingCart_Item item in listShoppingCart_Item)
            {
                try
                {
                    orderDetail.AppendLine(@"<tr>");
                    orderDetail.AppendLine(@"<td style='border-bottom: 1px solid #e4e4e4;'>");
                    orderDetail.AppendLine(@"<table id='product_ta'>");
                    orderDetail.AppendLine(@"<tr style='border-bottom:1px solid #e4e4e4'>");
                    orderDetail.AppendLine(@"<td style='width:40%'>");
                    orderDetail.AppendLine(@"<a href='" + item.URL + "' target='_blank' title='" + item.ProductName + "'><img title='" + item.ProductName + "' alt='" + item.ProductName + "' src='" + item.ImageURL + "?w=200&h=200' /></a>");
                    orderDetail.AppendLine(@"</td>");
                    orderDetail.AppendLine(@"<td style='text-align:left'>");
                    orderDetail.AppendLine(@"<p style='font-weight: bold; font-size: 20px;'>");
                    orderDetail.AppendLine(@"<a style='text-decoration: none; color:#212121' href='" + item.URL + "' target='_blank' title='" + item.ProductName + "'>" + item.ProductName + "</a>");
                    orderDetail.AppendLine(@"</p>");
                    orderDetail.AppendLine(@"<p><a style='text-decoration: none; color:#212121' href='" + item.URL + "' target='_blank' title='" + item.ProductName + "'>" + item.SKU + "</a></p>");
                    orderDetail.AppendLine(@"<p>" + item.Volume + " CBM</p>");
                    if (item.DealerPrice != null)
                    {
                        orderDetail.AppendLine(@"<p>" + item.Quantity + " x " + item.DealerPrice + " = " + (item.Quantity * item.DealerPrice).Value.ToString("C0") + "</p>");
                    }
                    else
                    {
                        if (item.DesignerPrice != null)
                        {
                            orderDetail.AppendLine(@"<p>" + item.Quantity + " x " + item.DesignerPrice + " = " + (item.Quantity * item.DesignerPrice).Value.ToString("C0") + "</p>");
                        }
                        else
                        {
                            orderDetail.AppendLine(@"<p>" + item.Quantity + " x " + item.Price + " = " + (item.Quantity * item.Price).Value.ToString("C0") + "</p>");
                        }
                    }

                    orderDetail.AppendLine(@"<p>Availability: " + item.Availability + "</p>");
                    orderDetail.AppendLine(@"</td>");
                    orderDetail.AppendLine(@"</tr>");
                    orderDetail.AppendLine(@"</table>");
                    orderDetail.AppendLine(@"</td>");
                    orderDetail.AppendLine(@"</tr>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                }
            }
            mail.Body = mail.Body.Replace(@"[OrderDetail]", orderDetail.ToString());
        }
    }
}
