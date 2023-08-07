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
    public class CollectionController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICollectionRepository _collectionRepository;
        public CollectionController(IWebHostEnvironment webHostEnvironment, ICollectionRepository collectionRepository) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _collectionRepository = collectionRepository;
        }
        [HttpPost]
        public int Add(Collection collection)
        {
            int result = AppGlobal.InitializationNumber;
            if (collection.ID == Guid.Empty)
            {
                collection.ID = new Guid();
                result = _collectionRepository.Add(collection);
            }
            else
            {
                result = _collectionRepository.Update(collection);
            }
            return result;
        }
        [HttpPost]
        public int AddAndUploadImage()
        {
            int result = AppGlobal.InitializationNumber;
            Collection collection = JsonConvert.DeserializeObject<Collection>(Request.Form["data"]);
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
                                fileName = AppGlobal.Collection + "_" + collection.URLCode + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            collection.ImageName = fileName;
                                            break;
                                        case 1:
                                            collection.Image = fileName;
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
            if (collection.ID == Guid.Empty)
            {
                collection.ID = new Guid();
                result = _collectionRepository.Add(collection);
            }
            else
            {
                result = _collectionRepository.Update(collection);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(Collection collection)
        {
            var result = await _collectionRepository.AsyncAdd(collection);
            return result;
        }
        [HttpPost]
        public int AddRange(List<Collection> list)
        {
            var result = _collectionRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<Collection> list)
        {
            var result = await _collectionRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(Collection collection)
        {
            var result = _collectionRepository.Update(collection);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(Collection collection)
        {
            var result = await _collectionRepository.AsyncUpdate(collection);
            return result;
        }
        [HttpPut]
        public int UpdateItemsURLCode()
        {
            var result = _collectionRepository.UpdateItemsURLCode();
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<Collection> list)
        {
            var result = _collectionRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<Collection> list)
        {
            var result = await _collectionRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<Collection> GetAllToList()
        {
            var result = _collectionRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<Collection>> AsyncGetAllToList()
        {
            var result = await _collectionRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<Collection> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _collectionRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<Collection>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _collectionRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public Collection GetByID(string ID)
        {
            Collection result = new Collection();
            Guid guidID = new Guid();
            try
            {
                guidID = new Guid(ID);
                result = _collectionRepository.GetByID(guidID);
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpGet]
        public Collection GetByURLCode(string URLCode)
        {
            Collection result = new Collection();
            try
            {
                URLCode = URLCode.Split('.')[0];
                URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                result = _collectionRepository.GetByURLCode(URLCode);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public List<Collection> GetBySearchStringToList(string searchString)
        {
            var result = _collectionRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<CollectionDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            var result = _collectionRepository.GetDataTransferBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<Collection> GetWithItemCountToList()
        {
            var result = _collectionRepository.GetWithItemCountToList();
            return result;
        }
        [HttpGet]
        public List<Collection> GetByIsActiveToList(bool isActive)
        {
            var result = _collectionRepository.GetByIsActiveToList(isActive);
            return result;
        }
        [HttpGet]
        public List<Collection> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            var result = _collectionRepository.GetByIsActiveAndIsActiveTAUSToList(isActive, isActiveTAUS);
            return result;
        }
        [HttpGet]
        public List<Collection> GetByBrand_IDAndIsActiveToList(string brand_ID, bool isActive)
        {
            var result = _collectionRepository.GetByBrand_IDAndIsActiveToList(brand_ID, isActive);
            return result;
        }
    }
}

