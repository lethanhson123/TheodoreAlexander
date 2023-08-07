using BL.BusinessService;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TA_Web_2020_API._3.TAService.AdminTAService
{
    public class AdminCheckMissingImageService : IDisposable
    {
        private bool disposed = false;
        private readonly ItemBusinessService _itemBUService;
        private readonly FabricBusinessService _fabricBUService;
        public AdminCheckMissingImageService(ItemBusinessService itemBUService, FabricBusinessService fabricBUService) {
            _itemBUService = itemBUService;
            _fabricBUService = fabricBUService;
        }
        public void Dispose(bool disposing)
        {
            if (!this.disposed){return;}
            if (disposing){
                _itemBUService.Dispose();
                _fabricBUService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true); GC.SuppressFinalize(this);
        }
        public async Task<CheckMissingImageResult> CheckMissingImageProduct(string sendEmailTo)//sendEmailTo separated by ;
        {
            try
            {
                //var sendMail = BL.Helper.SendMail("Theodore Alexander", "no-reply@theodorealexander.com", "Theodore Alexander Staff", sendEmailTo, "Items are missing image", "Processing... ETA 3 mins");

                CheckMissingImageResult imagesResult = new CheckMissingImageResult();

                var client = new RestClient("https://api.sirv.com/v2/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", "{\"clientId\":\"UDQIsNCqLg8GItq5WTH0XLCXIUz\",\"clientSecret\":\"7od48N/x8nSPVEtiQubxW3buB0qTNsXe99ajqOUFC6mFGvnfhAQricUAbAteT00qtacA7pOSwK/T8n2K1fIjQA==\"}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                SirvResponseToken tokenObj = JsonConvert.DeserializeObject<SirvResponseToken>(response.Content);

                client = new RestClient("https://api.sirv.com/v2/files/search");
                request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("authorization", "Bearer " + tokenObj.token);
                request.AddParameter("application/json", "{\"query\":\"extension:.jpg AND ((dirname:ProductPhotos AND basename:*main*) NOT dirname:trash)\",\"size\":100,\"scroll\":true}", ParameterType.RequestBody);

                SirvResponseSearchResult result = null;
                List<SirvResponseSearchResultHitFile> hitFiles = new List<SirvResponseSearchResultHitFile>();
                do
                {
                    response = client.Execute(request);
                    result = JsonConvert.DeserializeObject<SirvResponseSearchResult>(response.Content);
                    hitFiles.AddRange(result.hits.Select(h => new SirvResponseSearchResultHitFile
                    {
                        basename = h._source.basename.ToUpper(),
                        filename = h._source.filename.ToUpper(),
                        code = System.Text.RegularExpressions.Regex.Split(h._source.basename.ToUpper(), "_MAIN_")[0].ToUpper(),
                        size = h._source.size,

                    }));

                    //prepare new request
                    client = new RestClient("https://api.sirv.com/v2/files/search/scroll");
                    request = new RestRequest(Method.POST);
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("authorization", "Bearer " + tokenObj.token);
                    request.AddParameter("application/json", "{\"scrollId\":\"" + result.scrollId + "\"}", ParameterType.RequestBody);
                } while (hitFiles.Count < result.total);

                List<string> hitSkus = hitFiles.Select(f => f.code.ToUpper()).ToList();
                List<CheckMissingImageResultItem> activeSkus = _itemBUService.GetActiveItems().Select(i => new CheckMissingImageResultItem {
                    Code = i.SKU.ToUpper(), IsActive = i.IsActive, IsActiveINTL = i.IsActiveINTL, IsActiveTAUS = i.IsActiveTAUS
                }).ToList();
                imagesResult.ItemsWithoutImage = activeSkus.Where(i => !hitSkus.Contains(i.Code)).ToList();
                imagesResult.ImagesWithoutItem = hitSkus.Where(i => activeSkus.Any( a => a.Code == i)).ToList();

                //set item without image to inactive
                foreach (CheckMissingImageResultItem item in imagesResult.ItemsWithoutImage)
                {
                    _itemBUService.SetItemActiveStatus(item.Code, false, false);
                }

                //send email
                if (!String.IsNullOrEmpty(sendEmailTo))
                {
                    var emails = sendEmailTo.Split(';');
                    foreach (var email in emails)
                    {
                        await this.SendEmailItemMissingImage(imagesResult, email, "Items");
                    }
                }

                return imagesResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CheckMissingImageResult> CheckMissingImageFabric(string sendEmailTo)//sendEmailTo separated by ;
        {
            try
            {
                //var sendMail = BL.Helper.SendMail("Theodore Alexander", "no-reply@theodorealexander.com", "Theodore Alexander Staff", sendEmailTo, "Fabrics are missing image", "Processing... ETA 1 mins");

                CheckMissingImageResult imagesResult = new CheckMissingImageResult();

                var client = new RestClient("https://api.sirv.com/v2/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", "{\"clientId\":\"UDQIsNCqLg8GItq5WTH0XLCXIUz\",\"clientSecret\":\"7od48N/x8nSPVEtiQubxW3buB0qTNsXe99ajqOUFC6mFGvnfhAQricUAbAteT00qtacA7pOSwK/T8n2K1fIjQA==\"}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                SirvResponseToken tokenObj = JsonConvert.DeserializeObject<SirvResponseToken>(response.Content);

                client = new RestClient("https://api.sirv.com/v2/files/search");
                request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("authorization", "Bearer " + tokenObj.token);
                request.AddParameter("application/json", "{\"query\":\"extension:.jpg dirname:website\\/Frontend\\/Live\\/assests\\/fabric  -dirname:trash\",\"size\":100,\"scroll\":true}", ParameterType.RequestBody);

                SirvResponseSearchResult result = null;
                List<SirvResponseSearchResultHitFile> hitFiles = new List<SirvResponseSearchResultHitFile>();
                do
                {
                    response = client.Execute(request);
                    result = JsonConvert.DeserializeObject<SirvResponseSearchResult>(response.Content);
                    hitFiles.AddRange(result.hits.Select(h => new SirvResponseSearchResultHitFile
                    {
                        basename = h._source.basename.ToUpper(),
                        filename = h._source.filename.ToUpper(),
                        code = System.Text.RegularExpressions.Regex.Split(h._source.basename.ToUpper(), ".JPG")[0].ToUpper(),
                        size = h._source.size,

                    }));

                    //prepare new request
                    client = new RestClient("https://api.sirv.com/v2/files/search/scroll");
                    request = new RestRequest(Method.POST);
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("authorization", "Bearer " + tokenObj.token);
                    request.AddParameter("application/json", "{\"scrollId\":\"" + result.scrollId + "\"}", ParameterType.RequestBody);
                } while (hitFiles.Count < result.total);

                List<string> hitCodes = hitFiles.Select(f => f.code.ToUpper()).ToList();
                List<CheckMissingImageResultItem> activeFabricCodes = _fabricBUService.GetActiveFabrics().Where(i => i.IsEnabledOnWeb == true).Select(i => new CheckMissingImageResultItem {
                    Code = i.Fabric.ToUpper(),//.Split('*')[0].ToUpper(),
                    IsActive = i.IsEnabledOnWeb
                }).ToList().Select(i => new CheckMissingImageResultItem
                {
                    Code = i.Code.Split('*')[0].ToUpper(),
                    IsActive = i.IsActive
                }).ToList();
                imagesResult.ItemsWithoutImage = activeFabricCodes.Where(i => !hitCodes.Contains(i.Code)).ToList();
                imagesResult.ImagesWithoutItem = hitCodes.Where(i => activeFabricCodes.Any(a => a.Code == i)).ToList();

                if (!String.IsNullOrEmpty(sendEmailTo))
                {
                    var emails = sendEmailTo.Split(';');
                    foreach (var email in emails)
                    {
                        await this.SendEmailItemMissingImage(imagesResult, email, "Fabrics");
                    }
                }

                return imagesResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> SendEmailItemMissingImage(CheckMissingImageResult result, string emailTo, string type)
        {
            try
            {
                string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                string webURL = ConfigurationManager.AppSettings["WebURL"];
                string body = string.Empty;

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/assets/Template/EmailItemMissingImage.html")))
                {
                    body = await reader.ReadToEndAsync();
                }

                body = body.Replace("[Type]", type);
                body = body.Replace("[UnsuedImagesCount]", result.ImagesWithoutItem.Count.ToString());
                body = body.Replace("[ItemsAreMissingImageCount]", result.ItemsWithoutImage.Count.ToString());

                List<string> ItemsAreMissingImage = new List<string>();
                
                    string li = String.Empty;
                    switch (type)
                    {
                        case "Items":
                        ItemsAreMissingImage.Add("<p>All missing image item were set to INACTIVE.<br/>" +
                            "After uploading image, click [set back to original status]"+
                            "</p>");
                        foreach (CheckMissingImageResultItem item in result.ItemsWithoutImage)
                            {
                                li = String.Format("<li><a>{0}/product-detail/{1}</a> | Original Status: [TAUS:{2};INTL:{3}] | " +
                                    "<a href='https://tadminfunction.azurewebsites.net/api/SetItemActiveStatus?code=grc2pknUOxLSv1OHkrf5C/eYsbHLisrT1fadboCTvKysTBvqLpabNQ==&sku={4}&isActiveTAUS={5}&isActiveINTL={6}'>Set back to original status</a>" +
                                    "</li>", webURL, item.Code, item.IsActiveTAUS, item.IsActiveINTL, item.Code, item.IsActiveTAUS, item.IsActiveINTL);
                                ItemsAreMissingImage.Add(li);
                            }
                            break;
                        case "Fabrics":
                            foreach (CheckMissingImageResultItem item in result.ItemsWithoutImage)
                            {
                                li = String.Format("<li>{0}</li>", item.Code);
                                ItemsAreMissingImage.Add(li);
                            }
                            break;
                        default:
                            break;
                    }
                    
                
                body = body.Replace("[ItemsAreMissingImage]", String.Join("", ItemsAreMissingImage));
                return await TAUtility.TAUtility.SendMail(emailFrom, emailFrom, emailTo, emailTo, String.Format("{0} are missing image", type), body);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public class SirvResponseToken
    {
        public string token { get; set; }
        //public int expiresIn { get; set; }
        //public List<string> scope { get; set; }
    }
    public class SirvResponseSearchResult
    {
        public List<SirvResponseSearchResultHit> hits { get; set; }
        public int total { get; set; }
        public string scrollId { get; set; }
    }
    public class SirvResponseSearchResultHit
    {
        public SirvResponseSearchResultHitFile _source { get; set; }
    }

    public class SirvResponseSearchResultHitFile
    {
        //public string accountId { get; set; }
        public string filename { get; set; }
        public string code { get; set; }
        //public string dirname { get; set; }
        public string basename { get; set; }
        //public string extension { get; set; }
        //public string id { get; set; }
        //public string ctime { get; set; }
        //public string mtime { get; set; }
        public string size { get; set; }
        //public string contentType { get; set; }
    }

    public class SirvResponseSearchResultHitFileMeta
    {
        public int width { get; set; }
        public int height { get; set; }
        public string format { get; set; }
        public int duration { get; set; }
    }
    public class CheckMissingImageResult
    {
        public List<CheckMissingImageResultItem> ItemsWithoutImage { get; set; }
        public List<string> ImagesWithoutItem { get; set; }
    }

    public class CheckMissingImageResultItem
    {
        public string Code { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsActiveTAUS { get; set; }
        public bool? IsActiveINTL { get; set; }
    }
}