using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TA.Helpers
{
    public class AppGlobal
    {

        #region AppSettings
        public static int ItemCount
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("ItemCount").Value);
            }
        }
        public static int SEOBlogRow
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("SEOBlogRow").Value);
            }
        }
        public static decimal CMToINCH
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return decimal.Parse(builder.Build().GetSection("AppSettings").GetSection("CMToINCH").Value);
            }
        }
        public static int ImageWidth
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("ImageWidth").Value);
            }
        }
        public static int ImageHeight
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("ImageHeight").Value);
            }
        }
        public static string LIVEFTP
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("LIVEFTP").Value;
            }
        }
        public static string LIVEFTPUserName
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("LIVEFTPUserName").Value;
            }
        }
        public static string LIVEFTPPassword
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("LIVEFTPPassword").Value;
            }
        }
        public static string CountryIDUS
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("CountryIDUS").Value;
            }
        }
        public static string PublicKey
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PublicKey").Value;
            }
        }
        public static string PrivateKey
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PrivateKey").Value;
            }
        }
        public static string AccountID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AccountID").Value;
            }
        }
        public static string SignupID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("SignupID").Value;
            }
        }
        public static string WebsiteRequestQuoteInternational
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("WebsiteRequestQuoteInternational").Value;
            }
        }
        public static string WebsiteSubscriberInternational
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("WebsiteSubscriberInternational").Value;
            }
        }
        public static string WebsiteUserInternational
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("WebsiteUserInternational").Value;
            }
        }
        public static string WebsiteRequestQuoteUS
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("WebsiteRequestQuoteUS").Value;
            }
        }
        public static string WebsiteSubscriberUS
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("WebsiteSubscriberUS").Value;
            }
        }
        public static string WebsiteUserUS
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("WebsiteUserUS").Value;
            }
        }
        public static string URLInstagram
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("URLInstagram").Value;
            }
        }
        public static string URLFacebook
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("URLFacebook").Value;
            }
        }
        public static string URLYoutube
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("URLYoutube").Value;
            }
        }
        public static string URLTwitter
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("URLTwitter").Value;
            }
        }
        public static string URLPinterest
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("URLPinterest").Value;
            }
        }
         public static string URLLinkedin
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("URLLinkedin").Value;
            }
        }
        public static string USISO
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("USISO").Value;
            }
        }
        public static string US
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("US").Value;
            }
        }
        public static string TAUS
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TAUS").Value;
            }
        }
        public static string International
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("International").Value;
            }
        }
        public static string MenuLeft
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MenuLeft").Value;
            }
        }
        public static string Hidden
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Hidden").Value;
            }
        }
        public static string Menu
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Menu").Value;
            }
        }
        public static string Mobile
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Mobile").Value;
            }
        }
        public static string Open
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Open").Value;
            }
        }
        public static string Icon
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Icon").Value;
            }
        }
        public static string Filter
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Filter").Value;
            }
        }
        public static string Count
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Count").Value;
            }
        }
        public static string List
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("List").Value;
            }
        }
        public static string Plus
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Plus").Value;
            }
        }
        public static string Minus
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Minus").Value;
            }
        }
        public static string Change
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Change").Value;
            }
        }
        public static string Li
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Li").Value;
            }
        }
        public static string Sub
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Sub").Value;
            }
        }
        public static string Item
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Item").Value;
            }
        }
        public static string Select
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Select").Value;
            }
        }
        public static string HTMLExtension
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("HTMLExtension").Value;
            }
        }
        public static string TheodoreAlexanderBrandID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TheodoreAlexanderBrandID").Value;
            }
        }
        public static string TAStudioBrandID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TAStudioBrandID").Value;
            }
        }
        public static string SaloneBrandID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("SaloneBrandID").Value;
            }
        }
        public static string ProductListing
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListing").Value;
            }
        }
        public static string ProductDetail
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductDetail").Value;
            }
        }
        public static string PageTitleTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PageTitleTemplate").Value;
            }
        }
        public static string PageDescriptionTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PageDescriptionTemplate").Value;
            }
        }
        public static string PageKeywordsTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PageKeywordsTemplate").Value;
            }
        }
        public static string PageKeywordsNewsTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PageKeywordsNewsTemplate").Value;
            }
        }        
        public static string AboutHTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AboutHTML").Value;
            }
        }
        public static string About001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("About001").Value;
            }
        }
        public static string ContactHTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ContactHTML").Value;
            }
        }
        public static string Contact001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Contact001").Value;
            }
        }
        public static string IndexHTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("IndexHTML").Value;
            }
        }
        public static string IndexLIVEHTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("IndexLIVEHTML").Value;
            }
        }
        public static string Index
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Index").Value;
            }
        }
        public static string InStock
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("InStock").Value;
            }
        }
        public static string InStock001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("InStock001").Value;
            }
        }
        public static string CasualLiving
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("CasualLiving").Value;
            }
        }
        public static string CasualLiving001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("CasualLiving001").Value;
            }
        }
        public static string NewProducts
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("NewProducts").Value;
            }
        }
        public static string NewProducts001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("NewProducts001").Value;
            }
        }
        public static string CustomPalette
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("CustomPalette").Value;
            }
        }
        public static string CustomPalette001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("CustomPalette001").Value;
            }
        }
        public static string TailorFitProgram
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TailorFitProgram").Value;
            }
        }
        public static string TailorFitProgram001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TailorFitProgram001").Value;
            }
        }
        public static string Extending
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Extending").Value;
            }
        }
        public static string Extending001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Extending001").Value;
            }
        }
        public static string Infomation
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Infomation").Value;
            }
        }
        public static string Infomation001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Infomation001").Value;
            }
        }
        public static string Designer
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Designer").Value;
            }
        }
        public static string Designer001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Designer001").Value;
            }
        }
        public static string Type
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Type").Value;
            }
        }
        public static string Type001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Type001").Value;
            }
        }
        public static string Brand
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Brand").Value;
            }
        }
        public static string Brand001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Brand001").Value;
            }
        }
        public static string Collection
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Collection").Value;
            }
        }
        public static string Collection001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Collection001").Value;
            }
        }
        public static string LifeStyle
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("LifeStyle").Value;
            }
        }
        public static string LifeStyle001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("LifeStyle001").Value;
            }
        }
        public static string RoomAndUsage
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("RoomAndUsage").Value;
            }
        }
        public static string RoomAndUsage001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("RoomAndUsage001").Value;
            }
        }
        public static string Shape
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Shape").Value;
            }
        }
        public static string Shape001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Shape001").Value;
            }
        }
        public static string Style
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Style").Value;
            }
        }
        public static string Style001
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Style001").Value;
            }
        }
        public static string Special
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Special").Value;
            }
        }
        public static string Product
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Product").Value;
            }
        }
        public static string Article
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Article").Value;
            }
        }
        public static string Blog
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Blog").Value;
            }
        }
        public static string BlogKey
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("BlogKey").Value;
            }
        }
        public static string BlogVersion
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("BlogVersion").Value;
            }
        }
        public static string BlogURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("BlogURL").Value;
            }
        }
        public static int F0
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("F0").Value);
            }
        }
        public static int F1
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("F1").Value);
            }
        }
        public static int F2
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("F2").Value);
            }
        }
        public static int NotInfected
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("NotInfected").Value);
            }
        }
        public static string OrderHTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("OrderHTML").Value;
            }
        }
        public static string HR_Recruitment_RecommenderHTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("HR_Recruitment_RecommenderHTML").Value;
            }
        }
        public static string HR_Recruitment_RegisterHTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("HR_Recruitment_RegisterHTML").Value;
            }
        }
        public static string HeaderHTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("HeaderHTML").Value;
            }
        }
        public static string BlogTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("BlogTemplate").Value;
            }
        }
        public static string KeywordTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("KeywordTemplate").Value;
            }
        }
        public static string AboutTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AboutTemplate").Value;
            }
        }
        public static string ContactTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ContactTemplate").Value;
            }
        }
        public static string ProductTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductTemplate").Value;
            }
        }
        public static string ProductTemplateLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductTemplateLIVE").Value;
            }
        }
        public static string ProductListTemplateDesigner
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateDesigner").Value;
            }
        }
        public static string ProductListTemplateDesignerInfomation
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateDesignerInfomation").Value;
            }
        }
        public static string ProductListTemplateCustomPalette
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateCustomPalette").Value;
            }
        }
        public static string ProductListTemplateInStocked
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateInStocked").Value;
            }
        }
        public static string ProductListTemplateNewProducts
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateNewProducts").Value;
            }
        }
        public static string ProductListTemplateCasualLiving
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateCasualLiving").Value;
            }
        }
        public static string ProductListTemplate
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplate").Value;
            }
        }
        public static string BlogTemplateLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("BlogTemplateLIVE").Value;
            }
        }
        public static string KeywordTemplateLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("KeywordTemplateLIVE").Value;
            }
        }
        public static string AboutTemplateLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AboutTemplateLIVE").Value;
            }
        }
        public static string ContactTemplateLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ContactTemplateLIVE").Value;
            }
        }
        public static string ProductListTemplateDesignerLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateDesignerLIVE").Value;
            }
        }
        public static string ProductListTemplateDesignerInfomationLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateDesignerInfomationLIVE").Value;
            }
        }
        public static string ProductListTemplateCustomPaletteLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateCustomPaletteLIVE").Value;
            }
        }
        public static string ProductListTemplateTailorFitProgramLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateTailorFitProgramLIVE").Value;
            }
        }
        public static string ProductListTemplateInStockedLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateInStockedLIVE").Value;
            }
        }
        public static string ProductListTemplateNewProductsLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateNewProductsLIVE").Value;
            }
        }
        public static string ProductListTemplateCasualLivingLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateCasualLivingLIVE").Value;
            }
        }
        public static string ProductListTemplateLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ProductListTemplateLIVE").Value;
            }
        }
        public static string AlexaHamptonTemplateLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AlexaHamptonTemplateLIVE").Value;
            }
        }
        public static string Download
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Download").Value;
            }
        }
        public static string Upload
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Upload").Value;
            }
        }
        public static string Images
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Images").Value;
            }
        }
        public static string HTML
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("HTML").Value;
            }
        }
        public static string SMTPServer
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("SMTPServer").Value;
            }
        }
        public static int SMTPPort
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("SMTPPort").Value);
            }
        }
        public static int IsMailUsingSSL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("IsMailUsingSSL").Value);
            }
        }
        public static int IsMailBodyHtml
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("IsMailBodyHtml").Value);
            }
        }
        public static string ToEmail
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ToEmail").Value;
            }
        }
        public static string MasterEmail
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MasterEmail").Value;
            }
        }
        public static string MasterEmailUser
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MasterEmailUser").Value;
            }
        }
        public static string MasterEmailPassword
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MasterEmailPassword").Value;
            }
        }
        public static string MasterEmailDisplay
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MasterEmailDisplay").Value;
            }
        }
        public static string MasterEmailSubject
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MasterEmailSubject").Value;
            }
        }
        public static string APIDevURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("APIDevURL").Value;
            }
        }
        public static string API2URL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("API2URL").Value;
            }
        }
        public static string APIURLHTTPS
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("APIURLHTTPS").Value;
            }
        }
        public static string DomainURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainURL").Value;
            }
        }
        public static string DomainURLLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainURLLIVE").Value;
            }
        }
        public static string DomainURLTEST
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainURLTEST").Value;
            }
        }
        public static string DomainURLPRELIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainURLPRELIVE").Value;
            }
        }
        public static string ImageURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ImageURL").Value;
            }
        }
        public static string APIDomainURL
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("APIDomainURL").Value;
            }
        }
        public static string APITESTWebRootPath
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("APITESTWebRootPath").Value;
            }
        }
        public static string APIPREWebRootPath
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("APIPREWebRootPath").Value;
            }
        }
        public static string APILIVEWebRootPath
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("APILIVEWebRootPath").Value;
            }
        }
        public static string APILIVEWebRootPathHTTPS
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("APILIVEWebRootPathHTTPS").Value;
            }
        }
        public static string ImageTheodoreAlexander404
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ImageTheodoreAlexander404").Value;
            }
        }
        public static string MetaImage
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MetaImage").Value;
            }
        }
        public static string TheodoreAlexander_NewSQLServerConectionString
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TheodoreAlexander_NewSQLServerConectionString").Value;
            }
        }
        public static string TheodoreAlexander_PreSQLServerConectionString
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TheodoreAlexander_PreSQLServerConectionString").Value;
            }
        }
        public static string TheodoreAlexander_ERPSQLServerConectionString
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TheodoreAlexander_ERPSQLServerConectionString").Value;
            }
        }
        public static string TheodoreAlexander_NewSQLServerConectionStringLIVE
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("TheodoreAlexander_NewSQLServerConectionStringLIVE").Value;
            }
        }
        public static string SirvFolder
        {
            get
            {
                return "https://theodorealexander.sirv.com/ProductPhotos/";
            }
        }
        #endregion
        #region Functions  
        public static string GetProductURLCode(Guid ID, string SKU, string productName)
        {
            string uRLCode = AppGlobal.InitializationString;
            SKU = SKU.Replace(@".", @"-");
            SKU = SKU.Replace(@"(", @"");
            SKU = SKU.Replace(@")", @"");
            productName = productName.Replace(@" ", @"-");
            productName = productName.Replace(@"(", @"");
            productName = productName.Replace(@")", @"");
            productName = productName.Replace(@"‘", @"");
            productName = productName.Replace(@"’", @"");
            productName = productName.Replace(@",", @"");
            uRLCode = ID + "_" + productName + "-" + SKU + ".html";
            return uRLCode;
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
        public static List<string> SetProvinceAndDistrictAndWard(string address)
        {
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(address))
            {
                address = address.Replace(@",", ";");
                int length = address.Split(';').Length;
                int count = 0;
                for (int i = length; i > 0; i--)
                {
                    string district001 = AppGlobal.InitializationString;
                    string ward001 = AppGlobal.InitializationString;
                    count = count + 1;
                    switch (count)
                    {
                        case 1:
                            try
                            {
                                string province = address.Split(';')[i - 1];
                                if (province.Contains("HCM") || province.Contains("Hồ Chí Minh"))
                                {
                                    province = "Thành phố Hồ Chí Minh";
                                }
                                province = province.Replace(@"TP ", "");
                                province = province.Replace(@"TP.", "");
                                province = province.Replace(@"T ", "");
                                province = province.Replace(@"T.", "");
                                if ((province.Contains(@"Thủ đức"))
                                    || (province.Contains(@"Hóc Môn"))
                                    || (province.Contains(@"Củ chi"))
                                    || (province.Contains(@"Bình Chánh"))
                                    || (province.Contains(@"Bình Thạnh"))
                                    || (province.Contains(@"Bình Tân"))
                                    || (province.Contains(@"Tân Bình"))
                                    || (province.Contains(@"Tân Phú"))
                                    || (province.Contains(@"Gò Vấp"))
                                    || (province.Contains(@"Cần Giờ"))
                                    || (province.Contains(@"1"))
                                    || (province.Contains(@"2"))
                                    || (province.Contains(@"3"))
                                    || (province.Contains(@"4"))
                                    || (province.Contains(@"5"))
                                    || (province.Contains(@"6"))
                                    || (province.Contains(@"7"))
                                    || (province.Contains(@"8"))
                                    || (province.Contains(@"9"))
                                    || (province.Contains(@"10"))
                                    || (province.Contains(@"11"))
                                    || (province.Contains(@"12")))
                                {
                                    province = "Thành phố Hồ Chí Minh";
                                    district001 = province;
                                }
                                province = province.Trim();
                                list.Add(province);
                            }
                            catch (Exception e)
                            {
                                string mes = e.Message;
                            }
                            break;
                        case 2:
                            try
                            {
                                string district = address.Split(';')[i - 1];
                                district = district.Replace(@"TP ", "");
                                district = district.Replace(@"TP.", "");
                                district = district.Replace(@"H ", "");
                                district = district.Replace(@"H.", "");
                                district = district.Replace(@"TX ", "");
                                district = district.Replace(@"TX.", "");
                                district = district.Replace(@"Q ", "");
                                district = district.Replace(@"Q.", "");
                                if (!string.IsNullOrEmpty(district001))
                                {
                                    district = district001;
                                    ward001 = district;
                                }
                                district = district.Trim();
                                list.Add(district);
                            }
                            catch (Exception e)
                            {
                                string mes = e.Message;
                            }
                            break;
                        case 3:
                            try
                            {
                                string ward = address.Split(';')[i - 1];
                                ward = ward.Replace(@"P ", "");
                                ward = ward.Replace(@"P.", "");
                                ward = ward.Replace(@"X ", "");
                                ward = ward.Replace(@"X.", "");
                                ward = ward.Replace(@"TT ", "");
                                ward = ward.Replace(@"TT.", "");
                                if (!string.IsNullOrEmpty(ward001))
                                {
                                    ward = ward001;
                                }
                                ward = ward.Trim();
                                list.Add(ward);
                            }
                            catch (Exception e)
                            {
                                string mes = e.Message;
                            }
                            break;
                    }
                }
            }
            return list;
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
        public static string BlogAPIURL
        {
            get
            {
                return BlogURL + "ghost/api/" + BlogVersion + "/content/posts/?limit=all&key=" + BlogKey;
            }
        }
        public static string CrossUnder
        {
            get
            {
                return "_";
            }
        }
        public static string CrossRight
        {
            get
            {
                return @"/";
            }
        }
        public static string CrossLeft
        {
            get
            {
                return @"\";
            }
        }
        public static string CrossDots
        {
            get
            {
                return @".";
            }
        }
        public static string PNG
        {
            get
            {
                return @"png";
            }
        }
        public static string JPG
        {
            get
            {
                return @"jpg";
            }
        }
        #endregion
    }
}
