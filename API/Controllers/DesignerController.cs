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
    public class DesignerController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDesignerRepository _designerRepository;
        public DesignerController(IDesignerRepository designerRepository, IWebHostEnvironment webHostEnvironment) : base()
        {
            _designerRepository = designerRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public int Add(Designer designer)
        {
            int result = AppGlobal.InitializationNumber;
            if (designer.ID == Guid.Empty)
            {
                designer.ID = new Guid();
                result = _designerRepository.Add(designer);
            }
            else
            {
                result = _designerRepository.Update(designer);
            }
            return result;
        }
        [HttpPost]
        public int AddAndUploadImage()
        {
            int result = AppGlobal.InitializationNumber;
            Designer designer = JsonConvert.DeserializeObject<Designer>(Request.Form["data"]);
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
                                fileName = AppGlobal.SetName(designer.Name) + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            designer.ImageIcon = fileName;
                                            break;
                                        case 1:
                                            designer.ImageMain = fileName;
                                            break;
                                        case 2:
                                            designer.ImageBackground = fileName;
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
            if (designer.ID == Guid.Empty)
            {
                designer.ID = new Guid();
                result = _designerRepository.Add(designer);
            }
            else
            {
                result = _designerRepository.Update(designer);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(Designer designer)
        {
            var result = await _designerRepository.AsyncAdd(designer);
            return result;
        }
        [HttpPost]
        public int AddRange(List<Designer> list)
        {
            var result = _designerRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<Designer> list)
        {
            var result = await _designerRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(Designer designer)
        {
            var result = _designerRepository.Update(designer);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(Designer designer)
        {
            var result = await _designerRepository.AsyncUpdate(designer);
            return result;
        }
        [HttpPut]
        public int UpdateItemsURLCode()
        {
            var result = _designerRepository.UpdateItemsURLCode();
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<Designer> list)
        {
            var result = _designerRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<Designer> list)
        {
            var result = await _designerRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<Designer> GetAllToList()
        {
            var result = _designerRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<Designer>> AsyncGetAllToList()
        {
            var result = await _designerRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<Designer> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _designerRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<Designer>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _designerRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public Designer GetByID(string ID)
        {
            Designer result = new Designer();
            Guid guidID = new Guid();
            try
            {
                guidID = new Guid(ID);
                result = _designerRepository.GetByID(guidID);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public List<Designer> GetBySearchStringToList(string searchString)
        {
            var result = _designerRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Designer> GetByIsActiveToList(bool isActive)
        {
            var result = _designerRepository.GetByIsActiveToList(isActive);
            return result;
        }
    }
}

