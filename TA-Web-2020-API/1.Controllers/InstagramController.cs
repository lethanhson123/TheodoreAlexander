using BL.CustomExceptions;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using TA_Web_2020_API.Helper;
using BL.DTO;
using BL.BUServices;
using System.Web.Script.Serialization;
using TA.Data2021.Repositories;
using TA.Helpers2021;
using System.IO;
using Newtonsoft.Json;
using System.Text;


namespace TA_Web_2020_API.Controllers
{
    [RoutePrefix("api/Instagram")]
    public class InstagramController : TABaseAPIController
    {
        public InstagramController() : base()
        {
        }
        [HttpGet]
        public IHttpActionResult GetLastPosts()
        {
            List<TA.Data2021.Models.Instagram> result = new List<TA.Data2021.Models.Instagram>();
            WebClient webClient = new WebClient();
            //string content = webClient.DownloadString("https://www.instagram.com/theodore_alexander_official/?__a=1");
            string content = webClient.DownloadString("https://theodorealexander.com/js/instagram.txt");
            content = content.Trim();
            content = content.Replace(@"__typename", @"~");
            int length = content.Split('~').Length;
            for (int i = length - 1; i > -1; i--)
            {
                string contentSub = content.Split('~')[i];
                if (contentSub.Contains("shortcode") == true)
                {
                    TA.Data2021.Models.Instagram instagram = new TA.Data2021.Models.Instagram();
                    instagram.DatePost = AppGlobal.InitializationDateTime;
                    instagram.Title = "theodore_alexander_official";
                    instagram.URLTitle = "https://www.instagram.com/theodore_alexander_official/";

                    string contentSub001 = contentSub;
                    contentSub001 = contentSub001.Replace(@"shortcode", @"~");
                    instagram.ID = contentSub001.Split('~')[0];
                    instagram.ID = instagram.ID.Replace(@"""id"":""", @"~");
                    instagram.ID = instagram.ID.Split('~')[instagram.ID.Split('~').Length - 1];
                    instagram.ID = instagram.ID.Split('"')[0];

                    contentSub001 = contentSub;
                    contentSub001 = contentSub001.Replace(@"dimensions", @"~");
                    instagram.Code = contentSub001.Split('~')[0];
                    instagram.Code = instagram.Code.Replace(@"""shortcode"":""", @"~");
                    instagram.Code = instagram.Code.Split('~')[instagram.Code.Split('~').Length - 1];
                    instagram.Code = instagram.Code.Split('"')[0];

                    contentSub001 = contentSub;
                    contentSub001 = contentSub001.Replace(@"edge_media_to_comment", @"~");
                    instagram.Description = contentSub001.Split('~')[0];
                    instagram.Description = instagram.Description.Replace(@"""text"":""", @"~");
                    instagram.Description = instagram.Description.Split('~')[instagram.Description.Split('~').Length - 1];
                    instagram.Description = instagram.Description.Split('"')[0];

                    if (!string.IsNullOrEmpty(instagram.Description))
                    {
                        instagram.Name = instagram.Description;
                        instagram.Name = instagram.Name.Replace(@"\u", @"~");
                        instagram.Name = instagram.Name.Split('~')[0];
                        instagram.Name = instagram.Name.Replace(@"\n", @"~");
                        instagram.Name = instagram.Name.Split('~')[0];
                    }

                    contentSub001 = contentSub;
                    contentSub001 = contentSub001.Replace(@"edge_media_to_tagged_user", @"~");
                    instagram.URLImage = contentSub001.Split('~')[0];
                    instagram.URLImage = instagram.URLImage.Replace(@"""display_url"":""", @"~");
                    instagram.URLImage = instagram.URLImage.Split('~')[instagram.URLImage.Split('~').Length - 1];
                    instagram.URLImage = instagram.URLImage.Split('"')[0];

                    //if (!string.IsNullOrEmpty(instagram.URLImage))
                    //{                        
                    //    string ftpUrl = AppGlobal.InitializationString;
                    //    FtpWebRequest requestLIVEFTP;
                    //    byte[] fileContents;
                    //    string fileName = instagram.Code + ".jpg";
                    //    using (WebClient client = new WebClient())
                    //    {
                    //        try
                    //        {
                    //            client.DownloadFile(new Uri(instagram.URLImage), @"C:\Code\LeThanhSon\TA-Web-2020-API\Images");

                    //            ftpUrl = AppGlobal.LIVEFTP + AppGlobal.Images + @"/" + fileName;
                    //            requestLIVEFTP = (FtpWebRequest)WebRequest.Create(ftpUrl);
                    //            requestLIVEFTP.Method = WebRequestMethods.Ftp.UploadFile;
                    //            requestLIVEFTP.Credentials = new NetworkCredential(AppGlobal.LIVEFTPUserName, AppGlobal.LIVEFTPPassword);
                    //            fileContents = System.IO.File.ReadAllBytes(AppGlobal.WebRootPath);
                    //            requestLIVEFTP.ContentLength = fileContents.Length;
                    //            using (Stream requestStream = requestLIVEFTP.GetRequestStream())
                    //            {
                    //                requestStream.Write(fileContents, 0, fileContents.Length);
                    //            }
                    //        }
                    //        catch (Exception e)
                    //        {
                    //            string mes = e.Message;
                    //        }
                    //    }
                    //}

                    contentSub001 = contentSub;
                    contentSub001 = contentSub001.Replace(@"edge_media_to_caption", @"~");
                    instagram.DatePostString = contentSub001.Split('~')[0];
                    instagram.DatePostString = instagram.DatePostString.Replace(@"""accessibility_caption"":""", @"~");
                    instagram.DatePostString = instagram.DatePostString.Split('~')[instagram.DatePostString.Split('~').Length - 1];
                    instagram.DatePostString = instagram.DatePostString.Split('"')[0];
                    instagram.DatePostString = instagram.DatePostString.Split('"')[0];

                    if (!string.IsNullOrEmpty(instagram.DatePostString))
                    {
                        instagram.DatePostSub = instagram.DatePostString;
                        instagram.DatePostSub = instagram.DatePostSub.Replace(@"\udc11 on", @"~");
                        instagram.DatePostSub = instagram.DatePostSub.Split('~')[instagram.DatePostSub.Split('~').Length - 1];
                        instagram.DatePostSub = instagram.DatePostSub.Split('.')[0];
                        instagram.DatePostSub = instagram.DatePostSub.Replace(@"tagging", @"~");
                        instagram.DatePostSub = instagram.DatePostSub.Split('~')[0];
                        instagram.DatePostSub = instagram.DatePostSub.Trim();
                        try
                        {
                            instagram.DatePost = DateTime.Parse(instagram.DatePostSub);
                        }
                        catch
                        {
                        }
                    }

                    contentSub001 = contentSub;
                    contentSub001 = contentSub001.Replace(@"edge_media_preview_like", @"~");
                    instagram.LikeCount = contentSub001.Split('~')[0];
                    instagram.LikeCount = instagram.LikeCount.Replace(@"""edge_liked_by"":{""count"":", @"~");
                    instagram.LikeCount = instagram.LikeCount.Split('~')[instagram.LikeCount.Split('~').Length - 1];
                    instagram.LikeCount = instagram.LikeCount.Split('}')[0];

                    contentSub001 = contentSub;
                    contentSub001 = contentSub001.Replace(@"comments_disabled", @"~");
                    instagram.CommentCount = contentSub001.Split('~')[0];
                    instagram.CommentCount = instagram.CommentCount.Replace(@"""edge_media_to_comment"":{""count"":", @"~");
                    instagram.CommentCount = instagram.CommentCount.Split('~')[instagram.CommentCount.Split('~').Length - 1];
                    instagram.CommentCount = instagram.CommentCount.Split('}')[0];

                    instagram.URL = "https://www.instagram.com/p/" + instagram.Code + "/";
                    instagram.URLImageAPI = "https://theodorealexander.com/images/" + instagram.Code + ".jpg";
                    if (!string.IsNullOrEmpty(instagram.DatePostSub))
                    {
                        result.Add(instagram);
                    }
                }
            }
            result.Sort(
                delegate (TA.Data2021.Models.Instagram p1, TA.Data2021.Models.Instagram p2)
                {
                    return p2.DatePost.Value.CompareTo(p1.DatePost);
                }
            );
            return new GenerateResponeHelper<List<TA.Data2021.Models.Instagram>>(result, true, Request, HttpStatusCode.OK);
        }
    }
}
