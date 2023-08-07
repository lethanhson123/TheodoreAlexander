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
    public class BrandController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBrandRepository _brandRepository;
        public BrandController(IWebHostEnvironment webHostEnvironment, IBrandRepository brandRepository) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _brandRepository = brandRepository;
        }
        [HttpPost]
        public int Add(Brand brand)
        {
            int result = AppGlobal.InitializationNumber;
            if (brand.ID == Guid.Empty)
            {
                brand.ID = new Guid();
                result = _brandRepository.Add(brand);
            }
            else
            {
                result = _brandRepository.Update(brand);
            }
            return result;
        }
        [HttpPost]
        public int AddAndUploadImage()
        {
            int result = AppGlobal.InitializationNumber;
            Brand brand = JsonConvert.DeserializeObject<Brand>(Request.Form["data"]);
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
                                fileName = AppGlobal.Brand + "_" + brand.URLCode + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            brand.ImageName = fileName;
                                            break;
                                        case 1:
                                            brand.Image = fileName;
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
            if (brand.ID == Guid.Empty)
            {
                brand.ID = new Guid();
                result = _brandRepository.Add(brand);
            }
            else
            {
                result = _brandRepository.Update(brand);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(Brand brand)
        {
            var result = await _brandRepository.AsyncAdd(brand);
            return result;
        }
        [HttpPost]
        public int AddRange(List<Brand> list)
        {
            var result = _brandRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<Brand> list)
        {
            var result = await _brandRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(Brand brand)
        {
            var result = _brandRepository.Update(brand);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(Brand brand)
        {
            var result = await _brandRepository.AsyncUpdate(brand);
            return result;
        }
        [HttpPut]
        public int UpdateItemsURLCode()
        {
            var result = _brandRepository.UpdateItemsURLCode();
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<Brand> list)
        {
            var result = _brandRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<Brand> list)
        {
            var result = await _brandRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<Brand> GetAllToList()
        {
            var result = _brandRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<Brand>> AsyncGetAllToList()
        {
            var result = await _brandRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<Brand> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _brandRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<Brand>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _brandRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public Brand GetByID(string ID)
        {
            Brand result = new Brand();
            Guid guidID = new Guid();
            try
            {
                guidID = new Guid(ID);
                result = _brandRepository.GetByID(guidID);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public Brand GetByURLCode(string URLCode)
        {
            Brand result = new Brand();
            try
            {
                URLCode = URLCode.Split('.')[0];
                URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                result = _brandRepository.GetByURLCode(URLCode);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public List<Brand> GetBySearchStringToList(string searchString)
        {
            var result = _brandRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Brand> GetByIsActiveToList(bool isActive)
        {
            var result = _brandRepository.GetByIsActiveToList(isActive);
            return result;
        }
    }
}

