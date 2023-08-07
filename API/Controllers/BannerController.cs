using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IBannerRepository _bannerRepository;
        public BannerController(IBannerRepository bannerRepository) : base()
        {
            _bannerRepository = bannerRepository;
        }
        [HttpPost]
        public Banner Add(Banner banner)
        {
            var result = AppGlobal.InitializationNumber;
            if (banner.ID > 0)
            {
                result = _bannerRepository.Update(banner);
            }
            else
            {
                result = _bannerRepository.Add(banner);
            }
            return banner;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(Banner banner)
        {
            var result = await _bannerRepository.AsyncAdd(banner);
            return result;
        }
        [HttpPost]
        public int AddRange(List<Banner> list)
        {
            var result = _bannerRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<Banner> list)
        {
            var result = await _bannerRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(Banner Banner)
        {
            var result = _bannerRepository.Update(Banner);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(Banner banner)
        {
            var result = await _bannerRepository.AsyncUpdate(banner);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<Banner> list)
        {
            var result = _bannerRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<Banner> list)
        {
            var result = await _bannerRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<Banner> GetAllToList()
        {
            var result = _bannerRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<Banner>> AsyncGetAllToList()
        {
            var result = await _bannerRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<Banner> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _bannerRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<Banner>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _bannerRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<Banner> GetByParentIDToList(int parentID)
        {
            var result = _bannerRepository.GetByParentIDToList(parentID);
            return result;
        }
        [HttpGet]
        public List<Banner> GetByParentIDAndActiveToList(int parentID, bool active)
        {
            var result = _bannerRepository.GetByParentIDAndActiveToList(parentID, active);
            return result;
        }
        [HttpGet]
        public List<Banner> GetByActiveToList(bool active)
        {
            var result = _bannerRepository.GetByActiveToList(active);
            return result;
        }
        [HttpGet]
        public Banner GetByID(int ID)
        {
            Banner result = _bannerRepository.GetByID(ID);
            if (result == null)
            {
                result = new Banner();
                result.Active = true;
                result.IsUSShow = true;
                result.IsInternationalShow = true;
                result.Timer = 8000;
            }
            return result;
        }
        [HttpGet]
        public Banner GetByIDString(string ID)
        {
            Banner result = new Banner();
            result.Active = true;
            result.ParentID = 1;
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = _bannerRepository.GetByID(int.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            if (result == null)
            {
                result = new Banner();
                result.Active = true;
                result.IsUSShow = true;
                result.IsInternationalShow = true;
                result.Timer = 8000;
            }
            return result;
        }
    }
}

