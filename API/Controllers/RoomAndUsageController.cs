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
    public class RoomAndUsageController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRoomAndUsageRepository _roomAndUsageRepository;
        public RoomAndUsageController(IWebHostEnvironment webHostEnvironment, IRoomAndUsageRepository roomAndUsageRepository) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _roomAndUsageRepository = roomAndUsageRepository;
        }
        [HttpPost]
        public int Add(RoomAndUsage roomAndUsage)
        {
            int result = AppGlobal.InitializationNumber;
            if (roomAndUsage.ID == Guid.Empty)
            {
                roomAndUsage.ID = new Guid();
                result = _roomAndUsageRepository.Add(roomAndUsage);
            }
            else
            {
                result = _roomAndUsageRepository.Update(roomAndUsage);
            }
            return result;
        }
        [HttpPost]
        public int AddAndUploadImage()
        {
            int result = AppGlobal.InitializationNumber;
            RoomAndUsage roomAndUsage = JsonConvert.DeserializeObject<RoomAndUsage>(Request.Form["data"]);
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
                                fileName = AppGlobal.RoomAndUsage + "_" + roomAndUsage.URLCode + "_" + AppGlobal.InitializationDateTimeCode + fileExtension;
                                string pathSub = AppGlobal.Images;
                                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, pathSub, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            roomAndUsage.ImageName = fileName;
                                            break;
                                        case 1:
                                            roomAndUsage.Image = fileName;
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
            if (roomAndUsage.ID == Guid.Empty)
            {
                roomAndUsage.ID = new Guid();
                result = _roomAndUsageRepository.Add(roomAndUsage);
            }
            else
            {
                result = _roomAndUsageRepository.Update(roomAndUsage);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(RoomAndUsage roomAndUsage)
        {
            var result = await _roomAndUsageRepository.AsyncAdd(roomAndUsage);
            return result;
        }
        [HttpPost]
        public int AddRange(List<RoomAndUsage> list)
        {
            var result = _roomAndUsageRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<RoomAndUsage> list)
        {
            var result = await _roomAndUsageRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(RoomAndUsage roomAndUsage)
        {
            var result = _roomAndUsageRepository.Update(roomAndUsage);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(RoomAndUsage roomAndUsage)
        {
            var result = await _roomAndUsageRepository.AsyncUpdate(roomAndUsage);
            return result;
        }
        [HttpPut]
        public int UpdateItemsURLCode()
        {
            var result = _roomAndUsageRepository.UpdateItemsURLCode();
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<RoomAndUsage> list)
        {
            var result = _roomAndUsageRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<RoomAndUsage> list)
        {
            var result = await _roomAndUsageRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<RoomAndUsage> GetAllToList()
        {
            var result = _roomAndUsageRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<RoomAndUsage>> AsyncGetAllToList()
        {
            var result = await _roomAndUsageRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<RoomAndUsage> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _roomAndUsageRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<RoomAndUsage>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _roomAndUsageRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public RoomAndUsage GetByID(string ID)
        {
            RoomAndUsage result = new RoomAndUsage();
            Guid guidID = new Guid();
            try
            {
                guidID = new Guid(ID);
                result = _roomAndUsageRepository.GetByID(guidID);
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return result;
        }
        [HttpGet]
        public RoomAndUsage GetByURLCode(string URLCode)
        {
            RoomAndUsage result = new RoomAndUsage();
            try
            {
                URLCode = URLCode.Split('.')[0];
                URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                result = _roomAndUsageRepository.GetByURLCode(URLCode);
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public List<RoomAndUsage> GetBySearchStringToList(string searchString)
        {
            var result = _roomAndUsageRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<RoomAndUsage> GetByIsActiveToList(bool isActive)
        {
            var result = _roomAndUsageRepository.GetByIsActiveToList(isActive);
            return result;
        }
        [HttpGet]
        public List<RoomAndUsage> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS)
        {
            var result = _roomAndUsageRepository.GetByIsActiveAndIsActiveTAUSToList(isActive, isActiveTAUS);
            return result;
        }
    }
}

