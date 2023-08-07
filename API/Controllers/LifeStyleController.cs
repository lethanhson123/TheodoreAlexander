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
    public class LifeStyleController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILifeStyleRepository _lifeStyleRepository;
        public LifeStyleController(IWebHostEnvironment webHostEnvironment, ILifeStyleRepository lifeStyleRepository) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _lifeStyleRepository = lifeStyleRepository;
        }
        [HttpPost]
        public int Add(LifeStyle lifeStyle)
        {
            int result = AppGlobal.InitializationNumber;
            if (lifeStyle.ID == Guid.Empty)
            {
                lifeStyle.ID = new Guid();
                result = _lifeStyleRepository.Add(lifeStyle);
            }
            else
            {
                result = _lifeStyleRepository.Update(lifeStyle);
            }
            return result;
        }
        [HttpPost]
        public int AddAndUploadImage()
        {
            int result = AppGlobal.InitializationNumber;
            LifeStyle lifeStyle = JsonConvert.DeserializeObject<LifeStyle>(Request.Form["data"]);
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
                                fileName = AppGlobal.LifeStyle + "_" + lifeStyle.URLCode + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            lifeStyle.ImageName = fileName;
                                            break;
                                        case 1:
                                            lifeStyle.Image = fileName;
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
            if (lifeStyle.ID == Guid.Empty)
            {
                lifeStyle.ID = new Guid();
                result = _lifeStyleRepository.Add(lifeStyle);
            }
            else
            {
                result = _lifeStyleRepository.Update(lifeStyle);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(LifeStyle lifeStyle)
        {
            var result = await _lifeStyleRepository.AsyncAdd(lifeStyle);
            return result;
        }
        [HttpPost]
        public int AddRange(List<LifeStyle> list)
        {
            var result = _lifeStyleRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<LifeStyle> list)
        {
            var result = await _lifeStyleRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(LifeStyle lifeStyle)
        {
            var result = _lifeStyleRepository.Update(lifeStyle);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(LifeStyle lifeStyle)
        {
            var result = await _lifeStyleRepository.AsyncUpdate(lifeStyle);
            return result;
        }
        [HttpPut]
        public int UpdateItemsURLCode()
        {
            var result = _lifeStyleRepository.UpdateItemsURLCode();
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<LifeStyle> list)
        {
            var result = _lifeStyleRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<LifeStyle> list)
        {
            var result = await _lifeStyleRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<LifeStyle> GetAllToList()
        {
            var result = _lifeStyleRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<LifeStyle>> AsyncGetAllToList()
        {
            var result = await _lifeStyleRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<LifeStyle> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _lifeStyleRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<LifeStyle>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _lifeStyleRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public LifeStyle GetByID(string ID)
        {
            LifeStyle result = new LifeStyle();
            Guid guidID = new Guid();
            try
            {
                guidID = new Guid(ID);
                result = _lifeStyleRepository.GetByID(guidID);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public LifeStyle GetByURLCode(string URLCode)
        {
            LifeStyle result = new LifeStyle();
            try
            {
                URLCode = URLCode.Split('.')[0];
                URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                result = _lifeStyleRepository.GetByURLCode(URLCode);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public List<LifeStyle> GetBySearchStringToList(string searchString)
        {
            var result = _lifeStyleRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<LifeStyle> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            var result = _lifeStyleRepository.GetByIsActiveAndIsActiveTAUSToList(isActive, isActiveTAUS);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.LifeStyle> GetByIsActiveToList(bool isActive)
        {
            var result = _lifeStyleRepository.GetByIsActiveToList(isActive);
            return result;
        }
    }
}

