using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TA.Helpers2021
{
    public class AppGlobal
    {

        #region AppSettings
        public static int ItemCount
        {
            get
            {
                return 8;
            }
        }
        public static int ImageWidth
        {
            get
            {
                return 400;
            }
        }
        public static int ImageHeight
        {
            get
            {
                return 400;
            }
        }
        public static string TheodoreAlexanderBrandID
        {
            get
            {
                return "D1483451-48E9-4FB4-BA11-FA8552084DFF";
            }
        }
        public static string TAStudioBrandID
        {
            get
            {
                return "87614FBC-9801-4312-A2D4-BC2F67C345AA";
            }
        }
        public static string SaloneBrandID
        {
            get
            {
                return "76CAF86D-B8A8-4416-9DA8-DB2A031F7D67";
            }
        }
        public static string RightCross
        {
            get
            {
                return @"\";
            }
        }
        public static string JSONExtension
        {
            get
            {
                return ".json";
            }
        }
        public static string Images
        {
            get
            {
                return "Images";
            }
        }
        public static string Designer
        {
            get
            {
                return "Designer";
            }
        }
        public static string Extending
        {
            get
            {
                return "Extending";
            }
        }
        public static string ItemDataTransferActive
        {
            get
            {
                return "ItemDataTransferActive";
            }
        }
        public static string ItemActive
        {
            get
            {
                return "ItemActive";
            }
        }
        public static string ShapeActive
        {
            get
            {
                return "ShapeActive";
            }
        }
        public static string RoomAndUsageActive
        {
            get
            {
                return "RoomAndUsageActive";
            }
        }
        public static string LifeStyleActive
        {
            get
            {
                return "LifeStyleActive";
            }
        }
        public static string StyleActive
        {
            get
            {
                return "StyleActive";
            }
        }
        public static string BrandActive
        {
            get
            {
                return "BrandActive";
            }
        }
        public static string DesignerActive
        {
            get
            {
                return "DesignerActive";
            }
        }
        public static string TypeActive
        {
            get
            {
                return "TypeActive";
            }
        }
        public static string CollectionActive
        {
            get
            {
                return "CollectionActive";
            }
        }
        public static string International
        {
            get
            {
                return "International";
            }
        }
        public static string TAUS
        {
            get
            {
                return "TAUS";
            }
        }
        public static string Menu
        {
            get
            {
                return @"Menu";
            }
        }
        public static string Download
        {
            get
            {
                return @"Download";
            }
        }
        public static string DomainURLLIVE
        {
            get
            {
                return @"https://theodorealexander.com/";
            }
        }
        public static string DomainURLTEST
        {
            get
            {
                return @"http://web-test.theodorealexander.com/";
            }
        }
        public static string URLImageItem
        {
            get
            {
                return @"https://api.theodorealexander.com/images/Item/";
            }
        }
        public static string API2
        {
            get
            {
                return @"http://api2.theodorealexander.com/";
            }
        }
        public static string APIDEV
        {
            get
            {
                return @"http://api-dev.theodorealexander.com/";
            }
        }

        public static string ImageTheodoreAlexander404
        {
            get
            {
                return "theodore-alexander-404.jpg";
            }
        }
        public static string SirvFolder
        {
            get
            {
                return "https://theodorealexander.sirv.com/ProductPhotos/";
            }
        }
        public static string LIVEFTP
        {
            get
            {
                return "ftp://waws-prod-dm1-069.ftp.azurewebsites.windows.net/site/wwwroot/browser/";
            }
        }
        public static string LIVEFTPUserName
        {
            get
            {
                return @"tanew\\$tanew";
            }
        }
        public static string LIVEFTPPassword
        {
            get
            {
                return @"fhCtpEoT2vbRz9QnJ7TreCh3QzmA9l8gXXcKxk4fSaggLNvKHnK7z3FqXPgA";
            }
        }
        public static string WebRootPath
        {
            get
            {
                //return @"C:\WEBSITE\api.theodorealexander.com\";
                //return @"D:\website\api-pre.theodorealexander.com\";
                return @"D:\website\api-test.theodorealexander.com\";
                //return @"C:\Code\LeThanhSon\TA-Web-2020-API\";
            }
        }
        public static string TheodoreAlexander_NewSQLServerConectionString
        {
            get
            {
                //return @"Persist Security Info=True;User ID=theoalex_sa;Password=Passw0rdTAVM;database=TheodoreAlexander_New;data source=dbweb.theodorealexander.com;";
                //return @"Persist Security Info=True;User ID=theoalex_sa;Password=Passw0rdTAVM;database=TheodoreAlexander_New;data source=localhost;";
                //return @"Data Source=172.18.0.25;Initial Catalog=TheodoreAlexander_Pre;uid=sa;pwd=Passw0rd4WEB;Connect Timeout=200000;";
                //return @"Data Source=localhost;Initial Catalog=TheodoreAlexander_Pre;uid=sa;pwd=Passw0rd4WEB;Connect Timeout=200000;";
                //return @"Data Source=172.18.0.25;Initial Catalog=TheodoreAlexander_New;uid=sa;pwd=Passw0rd4WEB;Connect Timeout=200000;";
                return @"Data Source=localhost;Initial Catalog=TheodoreAlexander_New;uid=sa;pwd=Passw0rd4WEB;Connect Timeout=200000;";
            }
        }
        #endregion
        #region Functions        
        public static bool InitializationIsActiveTAUS(string region)
        {
            bool isActiveTAUS = false;
            if (!string.IsNullOrEmpty(region))
            {
                if (region == AppGlobal.InitializationRegion)
                {
                    isActiveTAUS = true;
                }
                if (region.Contains("US") == true)
                {
                    isActiveTAUS = true;
                }
                if (region.Contains("us") == true)
                {
                    isActiveTAUS = true;
                }
            }
            return isActiveTAUS;
        }
        public static string InitializationURLCode(string URLCode)
        {
            URLCode = URLCode.Split('.')[0];
            URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
            return URLCode;
        }
        public static string GenerateImageMoreURL(string SKU, int i)
        {
            string uRL = "";
            if (!string.IsNullOrEmpty(SKU))
            {
                if (SKU.Length > 2)
                {
                    uRL = AppGlobal.SirvFolder + SKU.Substring(0, 3) + "/" + SKU + "_more_" + i + ".jpg";
                }
            }
            return uRL;
        }
        public static string GenerateImageMainURL(string SKU)
        {
            string uRL = "";
            if (!string.IsNullOrEmpty(SKU))
            {
                if (SKU.Length > 2)
                {
                    uRL = AppGlobal.SirvFolder + SKU.Substring(0, 3) + "/" + SKU + "_main_1.jpg";
                }
            }
            return uRL;
        }
        public static string GenerateSketchImageURL(string SKU)
        {
            string uRL = "https://theodorealexander.sirv.com/sketch/" + SKU + "_sketch.jpg";
            return uRL;
        }
        public static string GenerateSeatingPlanImageURL(string SKU)
        {
            string uRL = "https://theodorealexander.sirv.com/seatingplans/" + SKU + "_seatingplan.jpg";
            return uRL;
        }
        public static string GenerateSeatingPlanPDFURL(string SKU)
        {
            string uRL = "https://theodorealexander.sirv.com/PDFs/" + SKU + ".pdf";
            return uRL;
        }
        public static string SetName(string name)
        {
            string result = name;
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Trim();
                result = result.ToLower();
                result = result.Replace(@" ", "-");
                result = result.Replace(@"  ", "-");
                result = result.Replace(@"    ", "-");
                result = result.Replace("‘", "-");
                result = result.Replace("’", "-");
                result = result.Replace("“", "-");
                result = result.Replace("--", "-");
                result = result.Replace("+", "-");
                result = result.Replace("/", "-");
                result = result.Replace(@"\", "-");
                result = result.Replace(":", "-");
                result = result.Replace(";", "-");
                result = result.Replace("%", "-");
                result = result.Replace("`", "-");
                result = result.Replace("~", "-");
                result = result.Replace("#", "-");
                result = result.Replace("$", "-");
                result = result.Replace("^", "-");
                result = result.Replace("&", "-");
                result = result.Replace("*", "-");
                result = result.Replace("(", "-");
                result = result.Replace(")", "-");
                result = result.Replace("|", "-");
                result = result.Replace("'", "-");
                result = result.Replace(",", "-");
                result = result.Replace(".", "-");
                result = result.Replace("?", "-");
                result = result.Replace("<", "-");
                result = result.Replace(">", "-");
                result = result.Replace("]", "-");
                result = result.Replace("[", "-");
                result = result.Replace(@"""", "-");
                result = result.Replace("á", "a");
                result = result.Replace("à", "a");
                result = result.Replace("ả", "a");
                result = result.Replace("ã", "a");
                result = result.Replace("ạ", "a");
                result = result.Replace("ă", "a");
                result = result.Replace("ắ", "a");
                result = result.Replace("ằ", "a");
                result = result.Replace("ẳ", "a");
                result = result.Replace("ẵ", "a");
                result = result.Replace("ặ", "a");
                result = result.Replace("â", "a");
                result = result.Replace("ấ", "a");
                result = result.Replace("ầ", "a");
                result = result.Replace("ẩ", "a");
                result = result.Replace("ẫ", "a");
                result = result.Replace("ậ", "a");
                result = result.Replace("í", "i");
                result = result.Replace("ì", "i");
                result = result.Replace("ỉ", "i");
                result = result.Replace("ĩ", "i");
                result = result.Replace("ị", "i");
                result = result.Replace("ý", "y");
                result = result.Replace("ỳ", "y");
                result = result.Replace("ỷ", "y");
                result = result.Replace("ỹ", "y");
                result = result.Replace("ỵ", "y");
                result = result.Replace("ó", "o");
                result = result.Replace("ò", "o");
                result = result.Replace("ỏ", "o");
                result = result.Replace("õ", "o");
                result = result.Replace("ọ", "o");
                result = result.Replace("ô", "o");
                result = result.Replace("ố", "o");
                result = result.Replace("ồ", "o");
                result = result.Replace("ổ", "o");
                result = result.Replace("ỗ", "o");
                result = result.Replace("ộ", "o");
                result = result.Replace("ơ", "o");
                result = result.Replace("ớ", "o");
                result = result.Replace("ờ", "o");
                result = result.Replace("ở", "o");
                result = result.Replace("ỡ", "o");
                result = result.Replace("ợ", "o");
                result = result.Replace("ú", "u");
                result = result.Replace("ù", "u");
                result = result.Replace("ủ", "u");
                result = result.Replace("ũ", "u");
                result = result.Replace("ụ", "u");
                result = result.Replace("ư", "u");
                result = result.Replace("ứ", "u");
                result = result.Replace("ừ", "u");
                result = result.Replace("ử", "u");
                result = result.Replace("ữ", "u");
                result = result.Replace("ự", "u");
                result = result.Replace("é", "e");
                result = result.Replace("è", "e");
                result = result.Replace("ẻ", "e");
                result = result.Replace("ẽ", "e");
                result = result.Replace("ẹ", "e");
                result = result.Replace("ê", "e");
                result = result.Replace("ế", "e");
                result = result.Replace("ề", "e");
                result = result.Replace("ể", "e");
                result = result.Replace("ễ", "e");
                result = result.Replace("ệ", "e");
                result = result.Replace("đ", "d");
                result = result.Replace("--", "-");
            }
            return result;
        }
        #endregion
        #region Initialization
        public static string InitializationRegion
        {
            get
            {
                return "TAUS";
            }
        }
        public static string InitializationGUICodeEmpty
        {
            get
            {
                return "00000000-0000-0000-0000-000000000000";
            }
        }
        public static string InitializationString
        {
            get
            {
                return "";
            }
        }
        public static DateTime InitializationDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        public static string InitializationGUICode
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
        public static string InitializationDateTimeCode
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Ticks.ToString();
            }
        }
        public static int InitializationNumber
        {
            get
            {
                return 0;
            }
        }
        #endregion
    }
}
