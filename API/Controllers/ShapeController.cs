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
    public class ShapeController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IShapeRepository _shapeRepository;
        public ShapeController(IWebHostEnvironment webHostEnvironment, IShapeRepository shapeRepository) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _shapeRepository = shapeRepository;
        }
        [HttpPost]
        public int Add(Shape shape)
        {
            int result = AppGlobal.InitializationNumber;
            if (shape.ID == Guid.Empty)
            {
                shape.ID = new Guid();
                result = _shapeRepository.Add(shape);
            }
            else
            {
                result = _shapeRepository.Update(shape);
            }
            return result;
        }
        [HttpPost]
        public int AddAndUploadImage()
        {
            int result = AppGlobal.InitializationNumber;
            Shape shape = JsonConvert.DeserializeObject<Shape>(Request.Form["data"]);
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
                                fileName = AppGlobal.Shape + "_" + shape.URLCode + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            shape.ImageName = fileName;
                                            break;
                                        case 1:
                                            shape.Image = fileName;
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
            if (shape.ID == Guid.Empty)
            {
                shape.ID = new Guid();
                result = _shapeRepository.Add(shape);
            }
            else
            {
                result = _shapeRepository.Update(shape);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(Shape shape)
        {
            var result = await _shapeRepository.AsyncAdd(shape);
            return result;
        }
        [HttpPost]
        public int AddRange(List<Shape> list)
        {
            var result = _shapeRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<Shape> list)
        {
            var result = await _shapeRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(Shape shape)
        {
            var result = _shapeRepository.Update(shape);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(Shape shape)
        {
            var result = await _shapeRepository.AsyncUpdate(shape);
            return result;
        }
        [HttpPut]
        public int UpdateItemsURLCode()
        {
            var result = _shapeRepository.UpdateItemsURLCode();
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<Shape> list)
        {
            var result = _shapeRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<Shape> list)
        {
            var result = await _shapeRepository.AsyncRemoveRange(list);
            return result;
        }

        [HttpGet]
        public List<Shape> GetAllToList()
        {
            var result = _shapeRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<Shape>> AsyncGetAllToList()
        {
            var result = await _shapeRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<Shape> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _shapeRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<Shape>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _shapeRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public Shape GetByID(string ID)
        {
            Shape result = new Shape();
            Guid guidID = new Guid();
            try
            {
                guidID = new Guid(ID);
                result = _shapeRepository.GetByID(guidID);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public Shape GetByURLCode(string URLCode)
        {
            Shape result = new Shape();
            try
            {
                URLCode = URLCode.Split('.')[0];
                URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                result = _shapeRepository.GetByURLCode(URLCode);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public List<Shape> GetBySearchStringToList(string searchString)
        {
            var result = _shapeRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<Shape> GetByIsActiveToList(bool isActive)
        {
            var result = _shapeRepository.GetByIsActiveToList(isActive);
            return result;
        }
        [HttpGet]
        public List<Shape> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            var result = _shapeRepository.GetByIsActiveAndIsActiveTAUSToList(isActive, isActiveTAUS);
            return result;
        }
    }
}

