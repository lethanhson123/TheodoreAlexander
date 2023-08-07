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
    public class SEOBlogTemplateController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISEOBlogTemplateRepository _sEOBlogTemplateRepository;
        public SEOBlogTemplateController(ISEOBlogTemplateRepository sEOBlogTemplateRepository, IWebHostEnvironment webHostEnvironment) : base()
        {
            _sEOBlogTemplateRepository = sEOBlogTemplateRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public int Add(SEOBlogTemplate sEOBlogTemplate)
        {
            var result = AppGlobal.InitializationNumber;
            if (sEOBlogTemplate.ID > 0)
            {
                result = _sEOBlogTemplateRepository.Update(sEOBlogTemplate);
            }
            else
            {
                result = _sEOBlogTemplateRepository.Add(sEOBlogTemplate);
            }
            return result;
        }
        [HttpPost]
        public SEOBlogTemplate SaveAndUploadFiles()
        {
            int result = AppGlobal.InitializationNumber;
            SEOBlogTemplate sEOBlogTemplate = JsonConvert.DeserializeObject<SEOBlogTemplate>(Request.Form["data"]);
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
                                fileName = AppGlobal.SetName(sEOBlogTemplate.Title) + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            sEOBlogTemplate.Image = fileName;
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

            if (sEOBlogTemplate.ID > 0)
            {
                result = _sEOBlogTemplateRepository.Update(sEOBlogTemplate);
            }
            else
            {
                result = _sEOBlogTemplateRepository.Add(sEOBlogTemplate);
            }
            return sEOBlogTemplate;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(SEOBlogTemplate sEOBlogTemplate)
        {
            var result = await _sEOBlogTemplateRepository.AsyncAdd(sEOBlogTemplate);
            return result;
        }
        [HttpPost]
        public int AddRange(List<SEOBlogTemplate> list)
        {
            var result = _sEOBlogTemplateRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<SEOBlogTemplate> list)
        {
            var result = await _sEOBlogTemplateRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(SEOBlogTemplate sEOBlogTemplate)
        {
            var result = _sEOBlogTemplateRepository.Update(sEOBlogTemplate);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(SEOBlogTemplate sEOBlogTemplate)
        {
            var result = await _sEOBlogTemplateRepository.AsyncUpdate(sEOBlogTemplate);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<SEOBlogTemplate> list)
        {
            var result = _sEOBlogTemplateRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<SEOBlogTemplate> list)
        {
            var result = await _sEOBlogTemplateRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<SEOBlogTemplate> GetAllToList()
        {
            var result = _sEOBlogTemplateRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<SEOBlogTemplate>> AsyncGetAllToList()
        {
            var result = await _sEOBlogTemplateRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<SEOBlogTemplate> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _sEOBlogTemplateRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<SEOBlogTemplate>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _sEOBlogTemplateRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public SEOBlogTemplate GetByID(int ID)
        {
            SEOBlogTemplate result = _sEOBlogTemplateRepository.GetByID(ID);
            if (result == null)
            {
                result = new SEOBlogTemplate();
                result.Active = true;
            }
            return result;
        }
        [HttpGet]
        public SEOBlogTemplate GetByIDString(string ID)
        {
            SEOBlogTemplate result = new SEOBlogTemplate();
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = _sEOBlogTemplateRepository.GetByID(int.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            if (result == null)
            {
                result = new SEOBlogTemplate();
                result.Active = true;
            }
            return result;
        }
    }
}

