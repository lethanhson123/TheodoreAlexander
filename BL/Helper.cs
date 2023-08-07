using BL.CustomExceptions;
using BL.DTO;
using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TA_Web_2020_API.Helper;
using TAUtility;

namespace BL
{
    public  class Helper
    {
        public class FileProperties
        {
            public string FileType { get; set; }
            public string FileSize { get; set; }
        }

        public static void SendErrorEmail(HttpRequestMessage request, Exception ex, string body = "")
        {
            //if (ex.GetBaseException().GetType().ToString() != "System.Web.HttpException")
            {
                var split = request.RequestUri.AbsoluteUri.Split('/');
                string op = split.Last();
                // Build the error report email
                string strErrorMsg = "";
                strErrorMsg += "A " + ex.GetBaseException().GetType() + " error has occoured.  Below are the details.<br/><br/>";
                strErrorMsg += "<b><u>Page Called:</u></b><br/><br/>";
                strErrorMsg += request.RequestUri.AbsoluteUri + "<br/><br/>";
                strErrorMsg += "<b><u>Exception Message:</u></b><br/><br/>";
                strErrorMsg += ex.GetBaseException() + "<br/><br/>";
                strErrorMsg += "<b><u>Server Variables:</u></b><br/><br/>";
                strErrorMsg += body;
                // Email the error report
                _ = BL.Helper.SendMail(ConfigurationManager.AppSettings["SMTPno-reply"], ConfigurationManager.AppSettings["SMTPno-reply"], "Theodore Alexander Staff", ConfigurationManager.AppSettings["EmailError"], "TA Web Error: " + op, strErrorMsg);
                //}
            }
        }

        public static bool IsExistsOnSirv(string fileUrl)
        {
            bool isExists = false;
            try
            {
                WebClient cli = new WebClient();
                cli.Headers[HttpRequestHeader.ContentType] = "application/json";
                ///https://theodorealexander.sirv.com/ProductPhotos/000/000-029_main_1.jpg
                ///-> http://theodorealexander.sirv.com/ProductPhotos/000/000-029_main_1.jpg?w=1&h=1
                string response = cli.DownloadString(String.Format("{0}?w=1&h=1", fileUrl).Replace("https", "http"));
                isExists = !String.IsNullOrEmpty(response);
            }
            catch (Exception ex) {
                return false;
            }
            return isExists;
        }
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public static string EncryptPassword(string password)
        {
            string strEncodePwd;
            HashAlgorithm ahash = new SHA256Managed();// SHA1Managed();
            ahash.Initialize();
            byte[] rawBytes = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hash = ahash.ComputeHash(rawBytes);

            StringBuilder sb = new StringBuilder(hash.Length * 2 + (hash.Length / 8));

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(BitConverter.ToString(hash, i, 1));
            }

            strEncodePwd = sb.ToString().TrimEnd(new char[] { ' ' });
            return strEncodePwd;
        }
        public static string CalculateAddress(string addressLine1, string addressLine2, string city, string region, string country, string postcode, string phone)
        {
            StringBuilder sb = new StringBuilder(addressLine1);
            if (!string.IsNullOrEmpty(addressLine1)) sb.Append(",<br>");
            if (!string.IsNullOrEmpty(addressLine2)) sb.Append(addressLine2 + "<br>");
            sb.Append(city);
            sb.Append(", ");
            sb.Append(region);
            if (country != "United States")
            {
                sb.Append(", ");
                sb.Append(country);
            }
            sb.Append(" ");
            sb.Append(postcode);
            if (!string.IsNullOrEmpty(phone))
            {
                sb.Append("<br>");
                sb.Append("Phone: ");
                sb.Append(phone);
            }
            return sb.ToString();
        }

        public static async Task<bool> SendGridMail(string strFromName, string strFromEmail, string strToName, string strToEmail, string strSubject, string strBody, string apikey = null, string password = null, bool isSSL = true)
        {
            try
            {
                string smtpServer = ConfigurationManager.AppSettings["SMTPserver"];
                string smtpUsername = ConfigurationManager.AppSettings["SMTPserverUsername"];
                string smtpPassword = ConfigurationManager.AppSettings["SMTPserverPassword"];
                smtpServer = "smtp.sendgrid.net";
                smtpUsername = apikey ?? "apikey";
                smtpPassword = password ?? "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";

                MailAddress fromAddress = new MailAddress(strFromEmail, strFromName);
                MailAddress toAddress = new MailAddress(strToEmail, strToName);
                MailMessage mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = strSubject,
                    Body = strBody,
                    IsBodyHtml = true
                };

                using (var smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = isSSL;

                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.SendCompleted += (s, e) => { smtpClient.Dispose(); };
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
            return true;
        }


        public static async Task<bool> SendMail(string strFromName, string strFromEmail, string strToName, string strToEmail, string strSubject, string strBody)
        {
            if (true ||
                strToEmail.EndsWith("@theodorealexander.com", StringComparison.OrdinalIgnoreCase)
                || strToEmail.EndsWith("@outlook.com", StringComparison.OrdinalIgnoreCase)
                || strToEmail.EndsWith("@msn.com", StringComparison.OrdinalIgnoreCase)
                || strToEmail.EndsWith("@me.com", StringComparison.OrdinalIgnoreCase)
                || strToEmail.EndsWith("@yahoo.com", StringComparison.OrdinalIgnoreCase)
                )
            {
                try
                {
                    string smtpServer = ConfigurationManager.AppSettings["SMTPserver"];

                    MailAddress fromAddress = new MailAddress(strFromEmail, strFromName);
                    MailAddress toAddress = new MailAddress(strToEmail, strToName);
                    MailMessage mailMessage = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = strSubject,
                        Body = strBody,
                        IsBodyHtml = true
                    };

                    //SmtpClient smtpClient = new SmtpClient(smtpServer);
                    //smtpClient.UseDefaultCredentials = false;
                    //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    //Test for local
                    using (var smtpClient = new SmtpClient(smtpServer))
                    {
                        //smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        //smtpClient.Credentials = new NetworkCredential("duyhau.206@gmail.com", "08110039");
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.EnableSsl = false;
                        smtpClient.SendCompleted += (s, e) => { smtpClient.Dispose(); };
                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }
                catch (Exception e)
                { //Logging error to file
                  //return false;
                    throw new BadRequestException(e.Message);
                }
                return true;
            }
            else {
                return await Helper.SendGridMail(strFromName, strFromEmail, strToName, strToEmail, strSubject, strBody);
            }
        }
        public static async Task<string> RenderGenericEmail(string content)
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
                body = body.Replace("[imgHeader]", header);
                body = body.Replace("[ltlMessage]", content);
                body = body.Replace("[WebURL]", ConfigurationManager.AppSettings["WebURL"]);
                return body;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<string> RenderEmailProduct(string fromName, string fromEmail, string toName, string msg, ItemDto item)
        {
            try
            {
                string webUrl = ConfigurationManager.AppSettings["WebURL"];
                string productLink = webUrl + "/product-detail/" + item.ID;
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/assets/Template/EmailProductTemplate.html")))
                {
                    body = await reader.ReadToEndAsync();
                }
                if (!String.IsNullOrEmpty(body))
                {
                    body = body.Replace("[ProductLink]", productLink);
                    body = body.Replace("[ProductImg]", TAUtility.TAUtility.GenerateSirvProductImageMain(item.SKU));
                    body = body.Replace("[RecieverName]", toName);
                    body = body.Replace("[Message]", msg);
                    body = body.Replace("[SenderName]", fromName);
                    body = body.Replace("[SenderEmail]", fromEmail);
                    body = body.Replace("[ProductName]", item.ProductName);
                    body = body.Replace("[ProductSKU]", item.SKU);
                    body = body.Replace("[ProductDescription]", item.ExtendedDescription);
                    body = body.Replace("[ProductDimensionIN]", item.Dimensions);
                    body = body.Replace("[ProductDimensionCM]", item.DimensionsCM);
                    body = body.Replace("[ProductMaterials]", item.Materials != null ? String.Join(", ", item.Materials.Select(m => m.Name)) : String.Empty);
                    body = body.Replace("[ProductCollection]", item.Collection != null ? item.Collection.Name : String.Empty);
                    body = body.Replace("[ProductStyle]", item.Style != null ? item.Style.Name : String.Empty);
                    body = body.Replace("[ProductType]", item.Type != null ? item.Type.Name : String.Empty);
                    body = body.Replace("[ProductShape]", item.Shapes != null ? String.Join(", ", item.Shapes.Select(m => m.Name)): String.Empty);
                    body = body.Replace("[ProductFeatures]", item.AdditionalFeatures != null ? String.Join("</span></p>", item.AdditionalFeatures.Split(';').Select(t => String.Format("{0}{1}", "<p style='display: flex; align-items: center'><i class='icon-arrow' style='margin-top:7px'></i><span style='text-indent: 15px; display: block;'>", t))) + "</span></p>" : String.Empty);
                }
                return body;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> RenderEmailSharedWishlist(ICollection<Lookbook_Item> items, string recipientName, string senderName, string senderEmail, string message, string sharedWishlistLink)
        {
            try
            {
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/assets/Template/EmailWishlistTemplate.html")))
                {
                    body = await reader.ReadToEndAsync();
                }

                string productItems = String.Empty;
                foreach (var item in items)
                {
                    productItems += await RenderEmailSharedWishlistItem(item.Item.ID.ToString(), item.Item.ProductName, item.Item.SKU);
                }
                
                if (!String.IsNullOrEmpty(body))
                {
                    body = body.Replace("[RecipientName]", recipientName);
                    body = body.Replace("[SenderName]", senderName);
                    body = body.Replace("[SenderEmail]", senderEmail);
                    body = body.Replace("[Message]", message);
                    body = body.Replace("[SharedWishlistLink]", sharedWishlistLink);
                    body = body.Replace("[ProductItems]", productItems);
                }
                return body;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> RenderEmailSharedWishlistItem(string productId, string productName, string productSku)
        {
            try
            {
                string webUrl = ConfigurationManager.AppSettings["WebURL"];
                string sirvProductPhotos = ConfigurationManager.AppSettings["SirvProductPhoto"];
                string productLink = webUrl + "/product-detail/" + productId;
                string productImage = sirvProductPhotos + "/" + productSku.Substring(0, 3) + "/" + productSku + "_main_1.jpg?w=200&profile=new_PlaceHolderImageNotFound";
                string itemRow = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/assets/Template/EmailWishlistItemTemplate.html")))
                {
                    itemRow = await reader.ReadToEndAsync();
                }
                if (!String.IsNullOrEmpty(itemRow))
                {
                    itemRow = itemRow.Replace("[ProductName]", productName);
                    itemRow = itemRow.Replace("[ProductSKU]", productSku);
                    itemRow = itemRow.Replace("[ProductWebLink]", productLink);
                    itemRow = itemRow.Replace("[ProductImageLink]", productImage);
                }
                return itemRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AppendAttr(StringBuilder sb, string name, string value)
        {
            sb.Append("<tr><td><b>").Append(name).Append("</b></td><td>").Append(value.Trim()).Append("</td></tr>");
        }
        public static bool CheckItemInSpecialCase(double price)
        {
            return price == -999;
        }
        public static double GetPriceByBrand(string Brand, double price)
        {
            double TAMultiplier = 3.0; // change to 3.0 all brands
            double KeMultiplier = 3.0;
            double AlMultiplier = 3.0;
            // Keno
            if (Brand == "6D19B18B-BE99-403D-9BFC-5377E7130EBA")
            {
                return Math.Round(KeMultiplier * price, MidpointRounding.AwayFromZero);
            }
            //Al
            else if (Brand == "D9D7C23D-82B6-4470-B9AE-AF51AFBD7F4D")
            {
                return Math.Round(AlMultiplier * price, MidpointRounding.AwayFromZero);
            }
            // TA
            else if (Brand == "D1483451-48E9-4FB4-BA11-FA8552084DFF")
            {
                return Math.Round(TAMultiplier * price, MidpointRounding.AwayFromZero);
            }
            else
                return Math.Round(TAMultiplier * price, MidpointRounding.AwayFromZero);

        }
        public static double GetDesignerPrice(double? rate, double Price)
        {
            return rate * Price ?? Price * 3;
        }
        public static string GetRetailPriceString(double OEMPrice, double MultiplePrice)
        {
            return Math.Round(MultiplePrice * OEMPrice, MidpointRounding.AwayFromZero).ToString();
        }
        public static string CmToInch(double cm)
        {
            double dblInch = cm / 2.54;
            return FormatInches(dblInch.ToString());
        }
        public static string CmToInch(decimal? cm)
        {
            double dblInch = Convert.ToDouble(cm) / 2.54;
            return FormatInches2(dblInch);
        }

        public static string FormatInches2(double value)
        {
            string strReturn = String.Empty;
            if (value > 0)
            {
                string valueStr = value.ToString();
                if (valueStr.IndexOf('.') > 0)
                {
                    strReturn = valueStr.Substring(0, valueStr.IndexOf('.'));
                    double dblCheck = double.Parse(valueStr.Substring(valueStr.IndexOf('.'), valueStr.Length - valueStr.IndexOf('.')));
                    if (dblCheck >= 0.125 && dblCheck < 0.375)
                        strReturn += "&frac14;";
                    else if (dblCheck >= 0.375 && dblCheck < 0.625)
                        strReturn += "&frac12;";
                    else if (dblCheck >= 0.625 && dblCheck < 0.875)
                        strReturn += "&frac34;";
                    else if (dblCheck >= 0.875)
                        strReturn = (int.Parse(strReturn) + 1).ToString();
                }
                else
                {
                    strReturn = valueStr;
                }
            }
            return strReturn;
        }
        public static string FormatInches(string strIn)
        {
            string strReturn;
            if (strIn.IndexOf('.') > 0)
            {
                strReturn = strIn.Substring(0, strIn.IndexOf('.'));
                double dblCheck = double.Parse(strIn.Substring(strIn.IndexOf('.'), strIn.Length - strIn.IndexOf('.')));
                if (dblCheck >= 0.125 && dblCheck < 0.375)
                    strReturn += "&frac14;";
                else if (dblCheck >= 0.375 && dblCheck < 0.625)
                    strReturn += "&frac12;";
                else if (dblCheck >= 0.625 && dblCheck < 0.875)
                    strReturn += "&frac34;";
                else if (dblCheck >= 0.875)
                    strReturn = (int.Parse(strReturn) + 1).ToString();
            }
            else
                strReturn = strIn;

            return strReturn;
        }
        public static string FormatInteger(decimal? val)
        {
            if (val.HasValue)
            {
                return val.Value.ToString("N0");
            }
            return "";
        }
        public static Guid? TryParseStringToGuid(string strGuid)
        {
            try
            {
                return Guid.Parse(strGuid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<string> ConvertStringToList(string strList)
        {
            List<string> rtn = new List<string>();
            try
            {
                if (!String.IsNullOrEmpty(strList))
                {
                    var splirStr = strList.Split(',').ToList();
                    foreach (var item in splirStr)
                    {
                        var cleanStr = CleanString(item.Trim());
                        rtn.Add(cleanStr);
                    }
                    var removedList = rtn.GroupBy(g => g)
                            .Select(g => g.FirstOrDefault()).ToList();
                    return removedList;
                }
                return rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Guid?> ConvertListStringToListGuid(List<string> lstStr)
        {
            List<Guid?> lstGuid = new List<Guid?>();
            foreach(var item in lstStr)
            {
                var guid = TryParseStringToGuid(item);
                if (guid != Guid.Empty)
                {
                    lstGuid.Add(guid);
                }
            }
            return lstGuid;
        }
        public static List<int?> ConvertListStringToListInt(List<string> lstStr)
        {
            List<int?> rtn = new List<int?>();
            foreach(var item in lstStr)
            {
                var number = TryParseStringToInt(item);
                if (number != null)
                {
                    rtn.Add(number);
                }
            }
            return rtn;
        }
        public static int? TryParseStringToInt(string strNumber)
        {
            try
            {
                return Int16.Parse(strNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string CleanString(string str)
        {
            return str.Replace(".", "").Replace("%20", "_").Replace("&", "and").Replace("'", "").Replace(" ", "_").Replace(",", "").Replace("é", "e").ToLower();
        }
        public static string GetProductImage(string folderName = "", string SKU = "", string defaultCode = "")
        {
            string productImgServerUrl = ConfigurationManager.AppSettings["SirvProductPhoto"];
            //if exists SKU image
            string imageUrl = string.Format("{0}/{1}/{2}_main_1.jpg", productImgServerUrl, folderName, SKU);
            if (!CheckFilesExists(imageUrl))
            {
                //if exists DefaultCode image
                imageUrl = String.Format("{0}/{1}/{2}_main_1.jpg", productImgServerUrl, folderName, defaultCode);
                if (CheckFilesExists(imageUrl))
                {
                    imageUrl = String.Format("{0}/notAvailable/ImageNotAvailable.jpg", productImgServerUrl);
                }
            }
            return imageUrl;
        }
        public static bool CheckFilesExists(string file)
        {
            bool rtn = true;
            using (var client = new MyClient())
            {
                client.HeadOnly = true;
                try
                {
                    // fine, no content downloaded
                    string s = client.DownloadString(file);
                }
                catch
                {
                    rtn = false;
                }
            }
            return rtn;
        }
        public static async Task<bool> CheckFilesExistsAsync(string url)
        {
            bool rtn = false;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 5000; //set the timeout to 1 seconds to keep the user from waiting too long for the page to load
                request.Method = "HEAD"; //Get only the header information -- no need to download any content
                System.Net.HttpWebResponse res = (System.Net.HttpWebResponse) await request.GetResponseAsync();
                rtn = res.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex) {
                rtn = false;
            }
            return rtn;
        }
        public static async Task<bool> CheckFileExistsAsync(string file)
        {
            bool rtn = true;
            using (var client = new MyClient())
            {
                client.HeadOnly = true;
                try
                {
                    Uri uri = new Uri(file);
                    string s = await client.DownloadStringTaskAsync(uri);
                }
                catch
                {
                    rtn = false;
                }
            }
            return rtn;
        }
        public static ItemDownloadInfo CreateDownloadFile(string file, string name)
        {
            ItemDownloadInfo rtn = new ItemDownloadInfo();
            using(var client = new WebClient())
            {
                try
                {
                    //Uri uri = new Uri(file);
                    //await client.OpenReadTaskAsync(uri);
                    //string contentType = client.ResponseHeaders["Content-Type"];
                    rtn.FileName = name;
                    rtn.Url = file;
                    rtn.FileType = file.Substring(file.Length - 3, 3);
                    //rtn.FileType = contentType.Substring(contentType.IndexOf("/") + 1, contentType.Length - 1 - contentType.IndexOf("/"));
                    //double byteTotal = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
                    //double convertToMB = (byteTotal / 1024f) / 1024f;
                    //double roundedNumber = Math.Round(convertToMB, 2);
                    //rtn.FileSize = roundedNumber.ToString() + " MB";
                }
                catch
                {
                    rtn = null;
                }
            }
            return rtn;
        }
        class MyClient : WebClient
        {
            public bool HeadOnly { get; set; }
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest req = base.GetWebRequest(address);
                if (HeadOnly && req.Method == "GET")
                {
                    req.Method = "HEAD";
                }
                return req;
            }
        }

    }
}
