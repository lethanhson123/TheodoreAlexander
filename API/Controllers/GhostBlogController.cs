using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class GhostBlogController : BaseController
    {
        private readonly IGhostBlogRepository _ghostBlogRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICollectionRepository _collectionRepository;
        private readonly ILifeStyleRepository _lifeStyleRepository;
        private readonly IStyleRepository _styleRepository;
        private readonly IShapeRepository _shapeRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IRoomAndUsageRepository _roomAndUsageRepository;
        private readonly IDesignerRepository _designerRepository;
        public GhostBlogController(IGhostBlogRepository ghostBlogRepository
            , IWebHostEnvironment webHostEnvironment
            , ICollectionRepository collectionRepository
            , ILifeStyleRepository lifeStyleRepository
            , IStyleRepository styleRepository
            , IShapeRepository shapeRepository
            , ITypeRepository typeRepository
            , IBrandRepository brandRepository
            , IRoomAndUsageRepository roomAndUsageRepository
            , IDesignerRepository designerRepository) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _ghostBlogRepository = ghostBlogRepository;
            _collectionRepository = collectionRepository;
            _lifeStyleRepository = lifeStyleRepository;
            _styleRepository = styleRepository;
            _shapeRepository = shapeRepository;
            _typeRepository = typeRepository;
            _roomAndUsageRepository = roomAndUsageRepository;
            _designerRepository = designerRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public List<GhostBlog> GetBySearchStringToList(string searchString)
        {
            var result = _ghostBlogRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public string InitializationGhostToGhostBlog()
        {
            List<GhostBlog> listGhostBlog = new List<GhostBlog>();
            WebClient webClient = new WebClient();
            System.Json.JsonValue listJsonValue = JsonValue.Parse(webClient.DownloadString(AppGlobal.BlogAPIURL));
            var listBlogJSON = listJsonValue["posts"];
            if (listBlogJSON.Count > 0)
            {
                _ghostBlogRepository.DeleteAllItems();
            }
            for (int j = 0; j < listBlogJSON.Count; j++)
            {
                GhostBlog ghostBlog = new GhostBlog();
                ghostBlog.Code = listBlogJSON[j]["id"];
                ghostBlog.CodeManage = listBlogJSON[j]["uuid"];
                ghostBlog.Title = listBlogJSON[j]["title"];
                ghostBlog.Description = listBlogJSON[j]["meta_description"];
                ghostBlog.Image = listBlogJSON[j]["feature_image"];
                ghostBlog.Note = listBlogJSON[j]["url"];
                ghostBlog.HTMLContent = listBlogJSON[j]["html"];
                string blogPublished = listBlogJSON[j]["published_at"];
                if (!string.IsNullOrEmpty(blogPublished))
                {
                    try
                    {
                        string year = blogPublished.Split('-')[0];
                        string month = blogPublished.Split('-')[1];
                        string day = blogPublished.Split('-')[2];
                        day = day.Split('T')[0];
                        ghostBlog.DatePost = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
                    }
                    catch (Exception e)
                    {
                        string blogMes = e.Message;
                    }
                }
                _ghostBlogRepository.Add(ghostBlog);
            }
            listGhostBlog = _ghostBlogRepository.GetAllToList();
            if (listGhostBlog.Count > 0)
            {
                InitializationGhostBlogToHTMLPage(listGhostBlog);
                InitializationSiteMapBlogToXML(listGhostBlog);
            }
            return AppGlobal.InitializationDateTimeCode;
        }
        private void InitializationGhostBlogToHTMLPage(List<GhostBlog> listGhostBlog)
        {
            try
            {
                string ftpUrl = AppGlobal.InitializationString;
                FtpWebRequest requestLIVEFTP;
                byte[] fileContents;
                string subPath = AppGlobal.Download + "/" + AppGlobal.HTML;
                string contentHTML = AppGlobal.InitializationString;
                var physicalPathRead = Path.Combine(_webHostEnvironment.WebRootPath, subPath, AppGlobal.BlogTemplateLIVE);
                using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
                {
                    using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                    {
                        contentHTML = r.ReadToEnd();
                    }
                }
                contentHTML = contentHTML.Replace(@"[DomainName]", AppGlobal.DomainURLTEST);
                contentHTML = contentHTML.Replace(@"[URLInstagram]", AppGlobal.URLInstagram);
                contentHTML = contentHTML.Replace(@"[URLFacebook]", AppGlobal.URLFacebook);
                contentHTML = contentHTML.Replace(@"[URLYoutube]", AppGlobal.URLYoutube);
                contentHTML = contentHTML.Replace(@"[URLTwitter]", AppGlobal.URLTwitter);
                contentHTML = contentHTML.Replace(@"[URLPinterest]", AppGlobal.URLPinterest);
                contentHTML = contentHTML.Replace(@"[URLLinkedin]", AppGlobal.URLLinkedin);
                contentHTML = contentHTML.Replace(@"[PageTitleTemplate]", AppGlobal.PageTitleTemplate);
                contentHTML = contentHTML.Replace(@"[PageDescriptionTemplate]", AppGlobal.PageDescriptionTemplate);
                contentHTML = contentHTML.Replace(@"[PageKeywordsTemplate]", AppGlobal.PageKeywordsTemplate);
                contentHTML = contentHTML.Replace(@"[PageKeywordsNewsTemplate]", AppGlobal.PageKeywordsNewsTemplate);

                List<Collection> listCollection = _collectionRepository.GetByIsActiveToList(true);
                List<Collection> listCollectionTheodoreAlexanderBrandID = _collectionRepository.GetByBrand_IDAndIsActiveToList(AppGlobal.TheodoreAlexanderBrandID, true);
                List<Collection> listCollectionSaloneBrandID = _collectionRepository.GetByBrand_IDAndIsActiveToList(AppGlobal.SaloneBrandID, true);
                List<Collection> listCollectionTAStudioBrandID = _collectionRepository.GetByBrand_IDAndIsActiveToList(AppGlobal.TAStudioBrandID, true);
                List<Collection> listCollectionUS = _collectionRepository.GetByIsActiveAndIsActiveTAUSToList(true, true);
                List<Collection> listCollectionInternational = _collectionRepository.GetByIsActiveAndIsActiveTAUSToList(true, false);
                List<Style> listStyle = _styleRepository.GetByIsActiveToList(true);
                List<Style> listStyleUS = _styleRepository.GetByIsActiveAndIsActiveTAUSToList(true, true);
                List<Style> listStyleInternational = _styleRepository.GetByIsActiveAndIsActiveTAUSToList(true, false);
                List<RoomAndUsage> listRoomAndUsage = _roomAndUsageRepository.GetByIsActiveToList(true);
                List<RoomAndUsage> listRoomAndUsageUS = _roomAndUsageRepository.GetByIsActiveAndIsActiveTAUSToList(true, true);
                List<RoomAndUsage> listRoomAndUsageInternational = _roomAndUsageRepository.GetByIsActiveAndIsActiveTAUSToList(true, false);
                List<Shape> listShape = _shapeRepository.GetByIsActiveToList(true);
                List<Shape> listShapeUS = _shapeRepository.GetByIsActiveAndIsActiveTAUSToList(true, true);
                List<Shape> listShapeInternational = _shapeRepository.GetByIsActiveAndIsActiveTAUSToList(true, false);
                List<LifeStyle> listLifeStyle = _lifeStyleRepository.GetByIsActiveToList(true);
                List<LifeStyle> listLifeStyleUS = _lifeStyleRepository.GetByIsActiveAndIsActiveTAUSToList(true, true);
                List<LifeStyle> listLifeStyleInternational = _lifeStyleRepository.GetByIsActiveAndIsActiveTAUSToList(true, false);
                List<TA.Data.Models.Type> listType = _typeRepository.GetByIsActiveToList(true);
                List<TA.Data.Models.Type> listTypeUS = _typeRepository.GetByIsActiveAndIsActiveTAUSToList(true, true);
                List<TA.Data.Models.Type> listTypeInternational = _typeRepository.GetByIsActiveAndIsActiveTAUSToList(true, false);
                List<Brand> listBrand = _brandRepository.GetByIsActiveToList(true);
                List<TA.Data.Models.Designer> listDesigner = _designerRepository.GetByIsActiveToList(true);


                StringBuilder menuTopBrandTheodoreAlexander = new StringBuilder();
                StringBuilder menuTopBrandSalone = new StringBuilder();
                StringBuilder menuTopBrandTAStudio = new StringBuilder();
                StringBuilder menuTopProduct = new StringBuilder();
                StringBuilder menuTopDesigner = new StringBuilder();
                StringBuilder menuLeftUS = new StringBuilder();
                StringBuilder menuLeftInternational = new StringBuilder();
                StringBuilder menuBrandMobileTheodoreAlexander = new StringBuilder();
                StringBuilder menuBrandMobileSalone = new StringBuilder();
                StringBuilder menuBrandMobileTAStudio = new StringBuilder();
                StringBuilder menuProductMobile = new StringBuilder();
                StringBuilder menuDesignerMobile = new StringBuilder();
                StringBuilder productListProductsUSHTML = new StringBuilder();
                StringBuilder productListProductsInternationalHTML = new StringBuilder();

                int i = 1;
                foreach (Collection item in listCollectionTheodoreAlexanderBrandID)
                {
                    string liHTML = @"<li> <a href='" + AppGlobal.DomainURLTEST + AppGlobal.Collection + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a></li>";
                    menuBrandMobileTheodoreAlexander.AppendLine(liHTML);
                    if ((i == 1) || (i % 9 == 1))
                    {
                        menuTopBrandTheodoreAlexander.AppendLine("<ul>");
                    }
                    menuTopBrandTheodoreAlexander.AppendLine(liHTML);
                    if (i > 1)
                    {
                        if ((i == listCollectionTheodoreAlexanderBrandID.Count) || (i % 9 == 0))
                        {
                            menuTopBrandTheodoreAlexander.AppendLine("</ul>");
                        }
                    }
                    i = i + 1;
                }

                StringBuilder menuTopBrandTAStudioInternational = new StringBuilder();
                StringBuilder menuTopBrandTAStudioUS = new StringBuilder();
                menuTopBrandTAStudioInternational.AppendLine(@"<div id='MenuTopBrandTAStudioInternational' style='display: flex;'>");
                menuTopBrandTAStudioUS.AppendLine(@"<div id='MenuTopBrandTAStudioUS' style='display: flex;'>");
                i = 1;
                foreach (Collection item in listCollectionTAStudioBrandID)
                {
                    string liHTML = @"<li><a href='" + AppGlobal.DomainURLTEST + AppGlobal.Collection + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a></li>";
                    string liMobileHTML = @"<li class='item_left_branch'> <a class='item_left_branch' href='" + AppGlobal.DomainURLTEST + AppGlobal.Collection + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a></li>";
                    if (item.ID.ToString().ToUpper() == "461DA43B-0409-4EBD-8EF2-0FB911718678")
                    {
                        liMobileHTML = @"<li id='TAStudioFrenzy" + AppGlobal.US + AppGlobal.Mobile + "'><a class='item_left_branch' href='" + AppGlobal.DomainURLTEST + AppGlobal.Collection + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a></li>";
                    }
                    if (item.ID.ToString().ToUpper() == "85CFC3ED-8876-436E-8159-B1E1025644C8")
                    {
                        liMobileHTML = @"<li id='TAStudioHolli" + AppGlobal.US + AppGlobal.Mobile + "'><a class='item_left_branch' href='" + AppGlobal.DomainURLTEST + AppGlobal.Collection + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a></li>";
                    }
                    menuBrandMobileTAStudio.AppendLine(liMobileHTML);
                    if ((i == 1) || (i % 5 == 1))
                    {
                        menuTopBrandTAStudioInternational.AppendLine("<ul style='min-width: 150px;'>");
                        menuTopBrandTAStudioUS.AppendLine("<ul style='min-width: 150px;'>");
                    }
                    menuTopBrandTAStudioInternational.AppendLine(liHTML);
                    if ((item.ID.ToString().ToUpper() != "461DA43B-0409-4EBD-8EF2-0FB911718678") && (item.ID.ToString().ToUpper() != "85CFC3ED-8876-436E-8159-B1E1025644C8"))
                    {
                        menuTopBrandTAStudioUS.AppendLine(liHTML);
                    }
                    if (i > 1)
                    {
                        if ((i == listCollectionTAStudioBrandID.Count) || (i % 5 == 0))
                        {
                            menuTopBrandTAStudioInternational.AppendLine("</ul>");
                            menuTopBrandTAStudioUS.AppendLine("</ul>");
                        }
                    }
                    i = i + 1;
                }
                menuTopBrandTAStudioInternational.AppendLine(@"</div>");
                menuTopBrandTAStudioUS.AppendLine(@"</div>");
                menuTopBrandTAStudio.AppendLine(menuTopBrandTAStudioInternational.ToString());
                menuTopBrandTAStudio.AppendLine(menuTopBrandTAStudioUS.ToString());

                foreach (Collection item in listCollectionSaloneBrandID)
                {
                    string liHTML = @"<li><a href='" + AppGlobal.DomainURLTEST + AppGlobal.Collection + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a></li>";
                    string liMobileHTML = @"<li class='item_left_branch'> <a class='item_left_branch' href='" + AppGlobal.DomainURLTEST + AppGlobal.Collection + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a></li>";
                    menuBrandMobileSalone.AppendLine(liMobileHTML);
                    menuTopBrandSalone.AppendLine(liHTML);
                }


                foreach (RoomAndUsage item in listRoomAndUsage)
                {
                    string liMobileHTML = @"<li class='item_left_branch'><a class='item_left_branch' href='" + AppGlobal.DomainURLTEST + AppGlobal.Collection + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a></li>";
                    menuTopProduct.AppendLine(@"<ul>");
                    menuTopProduct.AppendLine(@"<li>");
                    menuTopProduct.AppendLine(@"<h1><a title='" + item.DisplayName.ToUpper() + "' href='" + AppGlobal.DomainURLTEST + AppGlobal.RoomAndUsage + @"/" + item.URLCode + AppGlobal.HTMLExtension + "'>" + item.DisplayName.ToUpper() + "</a></h1>"); ;
                    menuTopProduct.AppendLine(@"</li>");

                    menuProductMobile.AppendLine(@"<li class='sub-item-mobile'>");
                    menuProductMobile.AppendLine(@"<a onclick='on" + AppGlobal.Menu + item.DisplayName.Replace(@" ", @"").Replace(@"é", @"e").ToUpper() + AppGlobal.Mobile + AppGlobal.Open + "()' title='" + item.DisplayName.ToUpper() + "'><i id='" + AppGlobal.Menu + item.DisplayName.Replace(@" ", @"").Replace(@"é", @"e").ToUpper() + AppGlobal.Mobile + AppGlobal.Icon + "' class='icon-plus'></i>" + item.DisplayName.ToUpper() + "</a>");
                    menuProductMobile.AppendLine(@"<ul id='" + AppGlobal.Menu + item.DisplayName.Replace(@" ", @"").Replace(@"é", @"e").ToUpper() + "Mobile' hidden>");


                    foreach (TA.Data.Models.Type itemType in listType)
                    {
                        string liHTML = @"<li><a title='" + itemType.DisplayName + "' href='" + AppGlobal.DomainURLTEST + AppGlobal.Type + @"/" + itemType.URLCode + AppGlobal.HTMLExtension + "'>" + itemType.DisplayName + "</a></li>";
                        if (itemType.RoomAndUsage_ID == item.ID)
                        {
                            menuTopProduct.AppendLine(liHTML);
                            menuProductMobile.AppendLine(liHTML);
                        }
                    }

                    menuTopProduct.AppendLine(@"</ul>");

                    menuProductMobile.AppendLine(@"</ul>");
                    menuProductMobile.AppendLine(@"<li>");
                }

                foreach (Designer item in listDesigner)
                {
                    if (!string.IsNullOrEmpty(item.ImageIcon))
                    {
                        item.URLImageIcon = AppGlobal.DomainURLTEST + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + item.ImageIcon;
                    }
                    if (!string.IsNullOrEmpty(item.ImageMain))
                    {
                        item.URLImageMain = AppGlobal.DomainURLTEST + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + item.ImageMain;
                    }
                    if (!string.IsNullOrEmpty(item.ImageBackground))
                    {
                        item.URLImageBackground = AppGlobal.DomainURLTEST + AppGlobal.Images + "/" + AppGlobal.Designer + "/" + item.ImageBackground;
                    }
                    StringBuilder liHTML = new StringBuilder();
                    liHTML.AppendLine(@"<ul>");
                    liHTML.AppendLine(@"<li class='icon_designer_optimize'>");
                    liHTML.AppendLine(@"<div class='image'>");
                    liHTML.AppendLine(@"<a href='" + AppGlobal.DomainURLTEST + AppGlobal.Designer + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>");
                    liHTML.AppendLine(@"<img src='" + item.URLImageIcon + "' title='" + item.DisplayName + "' alt='" + item.DisplayName + "' />");
                    liHTML.AppendLine(@"</a>");
                    liHTML.AppendLine(@"</div>");
                    liHTML.AppendLine(@"<div class='title_menu_designer'>");
                    liHTML.AppendLine(@"<a href='" + AppGlobal.DomainURLTEST + AppGlobal.Designer + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a>");
                    liHTML.AppendLine(@"</div>");
                    liHTML.AppendLine(@"</li>");
                    liHTML.AppendLine(@"</ul>");
                    string liMobileHTML = @"<li> <a href='" + AppGlobal.DomainURLTEST + AppGlobal.Designer + @"/" + item.URLCode + AppGlobal.HTMLExtension + @"' title='" + item.DisplayName + "'>" + item.DisplayName + "</a></li>";
                    menuDesignerMobile.AppendLine(liMobileHTML);
                    menuTopDesigner.AppendLine(liHTML.ToString());
                }

                contentHTML = contentHTML.Replace(@"[MenuTopDesigner]", menuTopDesigner.ToString());
                contentHTML = contentHTML.Replace(@"[MenuDesignerMobile]", menuDesignerMobile.ToString());
                contentHTML = contentHTML.Replace(@"[MenuTopBrandTheodoreAlexander]", menuTopBrandTheodoreAlexander.ToString());
                contentHTML = contentHTML.Replace(@"[MenuTopBrandSalone]", menuTopBrandSalone.ToString());
                contentHTML = contentHTML.Replace(@"[MenuTopBrandTAStudio]", menuTopBrandTAStudio.ToString());
                contentHTML = contentHTML.Replace(@"[MenuTopProduct]", menuTopProduct.ToString());
                contentHTML = contentHTML.Replace(@"[MenuBrandMobileTheodoreAlexander]", menuBrandMobileTheodoreAlexander.ToString());
                contentHTML = contentHTML.Replace(@"[MenuBrandMobileSalone]", menuBrandMobileSalone.ToString());
                contentHTML = contentHTML.Replace(@"[MenuBrandMobileTAStudio]", menuBrandMobileTAStudio.ToString());
                contentHTML = contentHTML.Replace(@"[MenuProductMobile]", menuProductMobile.ToString());
                contentHTML = contentHTML.Replace(@"[DateTimeCode]", AppGlobal.InitializationDateTimeCode);

                i = AppGlobal.InitializationNumber;
                string fileName = AppGlobal.InitializationString;
                string physicalPathCreate = AppGlobal.InitializationString;
                string pageTitle = AppGlobal.InitializationString;
                string pageDescription = AppGlobal.InitializationString;
                string pageKeywords = AppGlobal.InitializationString;
                string pageURL = AppGlobal.InitializationString;
                string uRLCheck = AppGlobal.InitializationString;
                string contentHTMLSub = AppGlobal.InitializationString;
                List<GhostBlog> listGhostBlogPopular = _ghostBlogRepository.GetByNumberToList(5);
                StringBuilder popularNews = new StringBuilder();
                foreach (GhostBlog itemPopular in listGhostBlogPopular)
                {
                    string url = AppGlobal.DomainURLTEST + AppGlobal.Blog + "/" + itemPopular.URLCode + ".html";
                    popularNews.AppendLine(@"<div class='sidebar-item-blog'>");
                    popularNews.AppendLine(@"<a style='display: flex' title='" + itemPopular.Title + "' href='" + url + "'>");
                    popularNews.AppendLine(@"<div class='col-left''>");
                    popularNews.AppendLine(@"<img alt='" + itemPopular.Title + "' title='" + itemPopular.Title + "' src='" + itemPopular.URLImage + "' width='100%'>");
                    popularNews.AppendLine(@"</div>");
                    popularNews.AppendLine(@"<div class='col-right'>");
                    popularNews.AppendLine(@"<span class='sidebar-title-blog-detail'>" + itemPopular.Title + "</span>");
                    popularNews.AppendLine(@"<div class='date-blog'>");
                    popularNews.AppendLine(@"<i class='icon-timer'></i>");
                    popularNews.AppendLine(@"<span class='sidebar-item-day'>" + itemPopular.DatePostString + "</span>");
                    popularNews.AppendLine(@"</div>");
                    popularNews.AppendLine(@"</div>");
                    popularNews.AppendLine(@"</a>");
                    popularNews.AppendLine(@"</div>");
                }
                foreach (GhostBlog item in listGhostBlog)
                {
                    uRLCheck = AppGlobal.Blog + "_" + item.URLCode;
                    pageURL = AppGlobal.DomainURLTEST + AppGlobal.Blog + "/" + item.URLCode + ".html";
                    pageTitle = item.Title;
                    pageDescription = item.Description;
                    pageKeywords = item.METAKeyword;
                    contentHTMLSub = contentHTML;
                    if (string.IsNullOrEmpty(item.URLImage))
                    {
                        contentHTMLSub = contentHTMLSub.Replace(@"[MetaImage]", AppGlobal.MetaImage);
                    }
                    else
                    {
                        contentHTMLSub = contentHTMLSub.Replace(@"[MetaImage]", item.URLImage);
                    }

                    List<GhostBlog> listGhostBlogRelated = _ghostBlogRepository.GetByNumberAndIDToList(10, item.ID);
                    StringBuilder relatedNews = new StringBuilder();
                    foreach (GhostBlog itemRelated in listGhostBlogRelated)
                    {
                        string url = AppGlobal.DomainURLTEST + AppGlobal.Blog + "/" + itemRelated.URLCode + ".html";
                        relatedNews.AppendLine(@"<div class='row post'>");
                        relatedNews.AppendLine(@"<div class='col-xl-5 col-sm-12 pd-related'>");
                        relatedNews.AppendLine(@"<a title='" + itemRelated.Title + "' href='" + url + "'><img style='width: 100%' alt='" + itemRelated.Title + "' title='" + itemRelated.Title + "' src='" + itemRelated.URLImage + "' /></a>");
                        relatedNews.AppendLine(@"</div>");
                        relatedNews.AppendLine(@"<div class='col-xl-7 col-sm-12 pd-related'>");
                        relatedNews.AppendLine(@"<div class='post-item-content'>");
                        relatedNews.AppendLine(@"<a style='color: #000 !important;' title='" + itemRelated.Title + "' href='" + url + "'>");
                        relatedNews.AppendLine(@"<h1 class='blog-title-post'>" + itemRelated.Title + "</h1>");
                        relatedNews.AppendLine(@"<div class='excerpt-post-related'>" + itemRelated.Description + "</div>");
                        relatedNews.AppendLine(@"</a>");
                        relatedNews.AppendLine(@"<div class='row blog-icon-social-line'>");
                        relatedNews.AppendLine(@"<div style='padding:0;'>");
                        relatedNews.AppendLine(@"<div class='date-post'>");
                        relatedNews.AppendLine(@"<i class='icon-timer'></i>");
                        relatedNews.AppendLine(@"<span>" + itemRelated.DatePostString + "</span>");
                        relatedNews.AppendLine(@"</div>");
                        relatedNews.AppendLine(@"</div>");
                        relatedNews.AppendLine(@"<div style='padding:0;'>");
                        relatedNews.AppendLine(@"<div class='share-post'>");
                        relatedNews.AppendLine(@"<span> Share:</span>");
                        relatedNews.AppendLine(@"<a target='_blank' title='" + itemRelated.ShareFacebook + "' href='" + itemRelated.ShareFacebook + "'><i class='icon-facebook'></i></a>");
                        relatedNews.AppendLine(@"<a target='_blank' title='" + itemRelated.ShareTwitter + "' href='" + itemRelated.ShareTwitter + "'><i class='icon-twitter'></i></a>");
                        relatedNews.AppendLine(@"<a target='_blank' title='" + itemRelated.SharePinterest + "' href='" + itemRelated.SharePinterest + "'><i class='icon-pinterest2'></i></a>");
                        relatedNews.AppendLine(@"</div>");
                        relatedNews.AppendLine(@"</div>");
                        relatedNews.AppendLine(@"</div>");
                        relatedNews.AppendLine(@"<div class='btn-more-post'>");
                        relatedNews.AppendLine(@"<a title='" + itemRelated.Title + "' href='" + url + "'>Read more</a>");
                        relatedNews.AppendLine(@"</div>");
                        relatedNews.AppendLine(@"</div>");
                        relatedNews.AppendLine(@"</div>");
                        relatedNews.AppendLine(@"</div>");
                    }
                    contentHTMLSub = contentHTMLSub.Replace(@"[PageURL]", pageURL);
                    contentHTMLSub = contentHTMLSub.Replace(@"[PageTitle]", pageTitle);
                    contentHTMLSub = contentHTMLSub.Replace(@"[PageDescription]", pageDescription);
                    contentHTMLSub = contentHTMLSub.Replace(@"[PageKeywords]", pageKeywords);
                    contentHTMLSub = contentHTMLSub.Replace(@"[URLCheck]", uRLCheck);
                    contentHTMLSub = contentHTMLSub.Replace(@"[Author]", item.Author);
                    contentHTMLSub = contentHTMLSub.Replace(@"[DatePostString]", item.DatePostString);
                    contentHTMLSub = contentHTMLSub.Replace(@"[Image]", item.Image);
                    contentHTMLSub = contentHTMLSub.Replace(@"[ShareFacebook]", item.ShareFacebook);
                    contentHTMLSub = contentHTMLSub.Replace(@"[ShareTwitter]", item.ShareTwitter);
                    contentHTMLSub = contentHTMLSub.Replace(@"[SharePinterest]", item.SharePinterest);
                    contentHTMLSub = contentHTMLSub.Replace(@"[HTMLContent]", item.HTMLContent);
                    contentHTMLSub = contentHTMLSub.Replace(@"[RelatedNews]", relatedNews.ToString());
                    contentHTMLSub = contentHTMLSub.Replace(@"[PopularNews]", popularNews.ToString());
                    fileName = item.URLCode + AppGlobal.HTMLExtension;

                    ftpUrl = AppGlobal.LIVEFTP + AppGlobal.Blog + "/" + fileName;
                    requestLIVEFTP = (FtpWebRequest)WebRequest.Create(ftpUrl);
                    requestLIVEFTP.Method = WebRequestMethods.Ftp.UploadFile;
                    requestLIVEFTP.Credentials = new NetworkCredential(AppGlobal.LIVEFTPUserName, AppGlobal.LIVEFTPPassword);
                    fileContents = Encoding.UTF8.GetBytes(contentHTMLSub);
                    requestLIVEFTP.ContentLength = fileContents.Length;
                    using (Stream requestStream = requestLIVEFTP.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }

                }
            }
            catch (Exception e)
            {
                string result = e.Message;
            }

        }
        private void InitializationSiteMapBlogToXML(List<GhostBlog> listGhostBlog)
        {
            string result = AppGlobal.InitializationString;
            try
            {
                string fileName = @"sitemap_Blog2022.xml";
                string subPath = AppGlobal.Download + "/" + AppGlobal.HTML;
                var physicalPathCreate = Path.Combine(AppGlobal.APITESTWebRootPath, AppGlobal.InitializationString, fileName);
                using (XmlTextWriter writer = new XmlTextWriter(physicalPathCreate, System.Text.Encoding.UTF8))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("urlset");
                    writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
                    writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    writer.WriteAttributeString("xmlns:image", "http://www.google.com/schemas/sitemap-image/1.1");
                    writer.WriteAttributeString("xmlns:video", "http://www.google.com/schemas/sitemap-video/1.1");
                    writer.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");

                    for (int i = 0; i < listGhostBlog.Count; i++)
                    {
                        try
                        {
                            listGhostBlog[i].URLCode = AppGlobal.DomainURLLIVE + AppGlobal.Blog + "/" + listGhostBlog[i].URLCode + ".html";
                            writer.WriteStartElement("url");
                            writer.WriteElementString("loc", listGhostBlog[i].URLCode);
                            writer.WriteEndElement();
                        }
                        catch (Exception e)
                        {
                            result = e.Message;
                        }
                    }

                    writer.WriteEndDocument();
                    writer.Flush();
                }

                string ftpUrl = AppGlobal.LIVEFTP + fileName;
                FtpWebRequest requestLIVEFTP = (FtpWebRequest)WebRequest.Create(ftpUrl);
                requestLIVEFTP.Method = WebRequestMethods.Ftp.UploadFile;
                requestLIVEFTP.Credentials = new NetworkCredential(AppGlobal.LIVEFTPUserName, AppGlobal.LIVEFTPPassword);
                byte[] fileContents = System.IO.File.ReadAllBytes(physicalPathCreate);
                requestLIVEFTP.ContentLength = fileContents.Length;
                using (Stream requestStream = requestLIVEFTP.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
        }
    }
}

