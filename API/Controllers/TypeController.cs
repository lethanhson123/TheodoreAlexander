using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class TypeController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITypeRepository _typeRepository;
        public TypeController(IWebHostEnvironment webHostEnvironment, ITypeRepository typeRepository) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _typeRepository = typeRepository;
        }
        [HttpPost]
        public int Add(TA.Data.Models.Type type)
        {
            int result = AppGlobal.InitializationNumber;
            if (type.ID == Guid.Empty)
            {
                type.ID = new Guid();
                result = _typeRepository.Add(type);
            }
            else
            {
                result = _typeRepository.Update(type);
            }
            return result;
        }
        [HttpPost]
        public int AddAndUploadImage()
        {
            int result = AppGlobal.InitializationNumber;
            TA.Data.Models.Type type = JsonConvert.DeserializeObject<TA.Data.Models.Type>(Request.Form["data"]);
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
                                fileName = AppGlobal.Type + "_" + type.URLCode + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            type.ImageName = fileName;
                                            break;
                                        case 1:
                                            type.Image = fileName;
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
            if (type.ID == Guid.Empty)
            {
                type.ID = new Guid();
                result = _typeRepository.Add(type);
            }
            else
            {
                result = _typeRepository.Update(type);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(TA.Data.Models.Type type)
        {
            var result = await _typeRepository.AsyncAdd(type);
            return result;
        }
        [HttpPost]
        public int AddRange(List<TA.Data.Models.Type> list)
        {
            var result = _typeRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<TA.Data.Models.Type> list)
        {
            var result = await _typeRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(TA.Data.Models.Type type)
        {
            var result = _typeRepository.Update(type);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(TA.Data.Models.Type type)
        {
            var result = await _typeRepository.AsyncUpdate(type);
            return result;
        }
        [HttpPut]
        public int UpdateItemsURLCode()
        {
            var result = _typeRepository.UpdateItemsURLCode();
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<TA.Data.Models.Type> list)
        {
            var result = _typeRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<TA.Data.Models.Type> list)
        {
            var result = await _typeRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Type> GetAllToList()
        {
            var result = _typeRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<TA.Data.Models.Type>> AsyncGetAllToList()
        {
            var result = await _typeRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Type> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _typeRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<TA.Data.Models.Type>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _typeRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public TA.Data.Models.Type GetByID(string ID)
        {
            TA.Data.Models.Type result = new TA.Data.Models.Type();
            Guid guidID = new Guid();
            try
            {
                guidID = new Guid(ID);
                result = _typeRepository.GetByID(guidID);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public TA.Data.Models.Type GetByURLCode(string URLCode)
        {
            TA.Data.Models.Type result = new TA.Data.Models.Type();
            try
            {
                URLCode = URLCode.Split('.')[0];
                URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                result = _typeRepository.GetByURLCode(URLCode);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Type> GetBySearchStringToList(string searchString)
        {
            var result = _typeRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<TypeDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            var result = _typeRepository.GetDataTransferBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Type> GetByIsEnabledOnWebToList(bool isEnabledOnWeb)
        {
            var result = _typeRepository.GetByIsEnabledOnWebToList(isEnabledOnWeb);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Type> GetByIsActiveToList(bool isActive)
        {
            var result = _typeRepository.GetByIsActiveToList(isActive);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Type> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            var result = _typeRepository.GetByIsActiveAndIsActiveTAUSToList(isActive, isActiveTAUS);
            return result;
        }
    }
}

