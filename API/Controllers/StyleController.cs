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
    public class StyleController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStyleRepository _styleRepository;
        public StyleController(IWebHostEnvironment webHostEnvironment, IStyleRepository styleRepository) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _styleRepository = styleRepository;
        }
        [HttpPost]
        public int Add(Style style)
        {
            int result = AppGlobal.InitializationNumber;
            if (style.ID == Guid.Empty)
            {
                style.ID = new Guid();
                result = _styleRepository.Add(style);
            }
            else
            {
                result = _styleRepository.Update(style);
            }
            return result;
        }
        [HttpPost]
        public int AddAndUploadImage()
        {
            int result = AppGlobal.InitializationNumber;
            Style style = JsonConvert.DeserializeObject<Style>(Request.Form["data"]);
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
                                fileName = AppGlobal.Style + "_" + style.URLCode + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            style.ImageName = fileName;
                                            break;
                                        case 1:
                                            style.Image = fileName;
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
            if (style.ID == Guid.Empty)
            {
                style.ID = new Guid();
                result = _styleRepository.Add(style);
            }
            else
            {
                result = _styleRepository.Update(style);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(Style style)
        {
            var result = await _styleRepository.AsyncAdd(style);
            return result;
        }
        [HttpPost]
        public int AddRange(List<Style> list)
        {
            var result = _styleRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<Style> list)
        {
            var result = await _styleRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(Style style)
        {
            var result = _styleRepository.Update(style);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(Style style)
        {
            var result = await _styleRepository.AsyncUpdate(style);
            return result;
        }
        [HttpPut]
        public int UpdateItemsURLCode()
        {
            var result = _styleRepository.UpdateItemsURLCode();
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<Style> list)
        {
            var result = _styleRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<Style> list)
        {
            var result = await _styleRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<Style> GetAllToList()
        {
            var result = _styleRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<Style>> AsyncGetAllToList()
        {
            var result = await _styleRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<Style> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _styleRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<Style>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _styleRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public Style GetByID(string ID)
        {
            Style result = new Style();
            Guid guidID = new Guid();
            try
            {
                guidID = new Guid(ID);
                result = _styleRepository.GetByID(guidID);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public Style GetByURLCode(string URLCode)
        {
            Style result = new Style();
            try
            {
                URLCode = URLCode.Split('.')[0];
                URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                result = _styleRepository.GetByURLCode(URLCode);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public List<Style> GetBySearchStringToList(string searchString)
        {
            var result = _styleRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<Style> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            var result = _styleRepository.GetByIsActiveAndIsActiveTAUSToList(isActive, isActiveTAUS);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Style> GetByIsActiveToList(bool isActive)
        {
            var result = _styleRepository.GetByIsActiveToList(isActive);
            return result;
        }
    }
}

