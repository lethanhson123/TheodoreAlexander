using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class BannerDetailController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBannerDetailRepository _bannerDetailRepository;
        public BannerDetailController(IBannerDetailRepository bannerDetailRepository, IWebHostEnvironment webHostEnvironment) : base()
        {
            _bannerDetailRepository = bannerDetailRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public BannerDetail Add(BannerDetail bannerDetail)
        {
            var result = AppGlobal.InitializationNumber;
            if (bannerDetail.ID > 0)
            {
                result = _bannerDetailRepository.Update(bannerDetail);
            }
            else
            {
                result = _bannerDetailRepository.Add(bannerDetail);
            }
            return bannerDetail;
        }
        [HttpPost]
        public BannerDetail SaveAndUploadFiles()
        {
            int result = AppGlobal.InitializationNumber;
            BannerDetail bannerDetail = JsonConvert.DeserializeObject<BannerDetail>(Request.Form["data"]);
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Form.Files.Count; i++)
                    {
                        var file = Request.Form.Files[i];
                        if (file == null || file.Length == 0)
                        {
                        }
                        if (file != null)
                        {
                            string fileExtension = Path.GetExtension(file.FileName);
                            if (fileExtension.Contains("txt") == false)
                            {
                                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                                fileName = AppGlobal.SetName(bannerDetail.Name) + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            bannerDetail.ImageDesktop = fileName;
                                            break;
                                        case 1:
                                            bannerDetail.ImageMobile = fileName;
                                            break;
                                        case 2:
                                            bannerDetail.ImageName = fileName;
                                            break;
                                    }
                                }
                                physicalPath = Path.Combine(AppGlobal.APILIVEWebRootPathHTTPS, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }

            if (bannerDetail.ID > 0)
            {
                result = _bannerDetailRepository.Update(bannerDetail);
            }
            else
            {
                result = _bannerDetailRepository.Add(bannerDetail);
            }
            return bannerDetail;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(BannerDetail bannerDetail)
        {
            var result = await _bannerDetailRepository.AsyncAdd(bannerDetail);
            return result;
        }
        [HttpPost]
        public int AddRange(List<BannerDetail> list)
        {
            var result = _bannerDetailRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<BannerDetail> list)
        {
            var result = await _bannerDetailRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(BannerDetail bannerDetail)
        {
            var result = _bannerDetailRepository.Update(bannerDetail);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(BannerDetail bannerDetail)
        {
            var result = await _bannerDetailRepository.AsyncUpdate(bannerDetail);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<BannerDetail> list)
        {
            var result = _bannerDetailRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<BannerDetail> list)
        {
            var result = await _bannerDetailRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<BannerDetail> GetAllToList()
        {
            var result = _bannerDetailRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<BannerDetail>> AsyncGetAllToList()
        {
            var result = await _bannerDetailRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<BannerDetail> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _bannerDetailRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<BannerDetail>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _bannerDetailRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<BannerDetail> GetByParentIDToList(int parentID)
        {
            var result = _bannerDetailRepository.GetByParentIDToList(parentID);
            return result;
        }
        [HttpGet]
        public List<BannerDetail> GetByParentIDAndActiveToList(int parentID, bool active)
        {
            var result = _bannerDetailRepository.GetByParentIDAndActiveToList(parentID, active);
            return result;
        }
        [HttpGet]
        public List<BannerDetail> GetByActiveToList(bool active)
        {
            var result = _bannerDetailRepository.GetByActiveToList(active);
            return result;
        }
        [HttpGet]
        public BannerDetail GetByID(int ID)
        {
            BannerDetail result = _bannerDetailRepository.GetByID(ID);
            if (result == null)
            {
                result = new BannerDetail();
                result.Active = true;
                result.IsUSShow = true;
                result.IsInternationalShow = true;
                result.ParentID = 1;
            }
            return result;
        }
        [HttpGet]
        public BannerDetail GetByIDString(string ID)
        {
            BannerDetail result = new BannerDetail();
            result.Active = true;
            result.ParentID = 1;
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = _bannerDetailRepository.GetByID(int.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            if (result == null)
            {
                result = new BannerDetail();
                result.Active = true;
                result.IsUSShow = true;
                result.IsInternationalShow = true;
                result.ParentID = 1;
            }
            return result;
        }
    }
}

