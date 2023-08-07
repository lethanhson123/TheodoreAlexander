using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class SEOBlogItemController : BaseController
    {
        private readonly ISEOBlogItemRepository _sEOBlogItemRepository;
        public SEOBlogItemController(ISEOBlogItemRepository sEOBlogItemRepository) : base()
        {
            _sEOBlogItemRepository = sEOBlogItemRepository;
        }
        [HttpPost]
        public int Add(SEOBlogItem sEOBlogItem)
        {
            var result = AppGlobal.InitializationNumber;
            if (sEOBlogItem.ID > 0)
            {
                result = _sEOBlogItemRepository.Update(sEOBlogItem);
            }
            else
            {
                result = _sEOBlogItemRepository.Add(sEOBlogItem);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(SEOBlogItem sEOBlogItem)
        {
            var result = await _sEOBlogItemRepository.AsyncAdd(sEOBlogItem);
            return result;
        }
        [HttpPost]
        public int AddRange(List<SEOBlogItem> list)
        {
            var result = _sEOBlogItemRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<SEOBlogItem> list)
        {
            var result = await _sEOBlogItemRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(SEOBlogItem sEOBlogItem)
        {
            var result = _sEOBlogItemRepository.Update(sEOBlogItem);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(SEOBlogItem sEOBlogItem)
        {
            var result = await _sEOBlogItemRepository.AsyncUpdate(sEOBlogItem);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<SEOBlogItem> list)
        {
            var result = _sEOBlogItemRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<SEOBlogItem> list)
        {
            var result = await _sEOBlogItemRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<SEOBlogItem> GetAllToList()
        {
            var result = _sEOBlogItemRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<SEOBlogItem>> AsyncGetAllToList()
        {
            var result = await _sEOBlogItemRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<SEOBlogItem> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _sEOBlogItemRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<SEOBlogItem>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _sEOBlogItemRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<SEOBlogItem> GetByParentIDToList(int parentID)
        {
            var result = _sEOBlogItemRepository.GetByParentIDToList(parentID);
            return result;
        }
        [HttpGet]
        public SEOBlogItem GetByID(int ID)
        {
            SEOBlogItem result = _sEOBlogItemRepository.GetByID(ID);
            if (result == null)
            {
                result = new SEOBlogItem();
                result.Active = true;
            }
            return result;
        }
        [HttpGet]
        public SEOBlogItem GetByIDString(string ID)
        {
            SEOBlogItem result = new SEOBlogItem();
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = _sEOBlogItemRepository.GetByID(int.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            if (result == null)
            {
                result = new SEOBlogItem();
                result.Active = true;
            }
            return result;
        }
    }
}

