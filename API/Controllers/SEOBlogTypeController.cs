using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class SEOBlogTypeController : BaseController
    {
        private readonly ISEOBlogTypeRepository _sEOBlogTypeRepository;
        public SEOBlogTypeController(ISEOBlogTypeRepository seOBlogTypeRepository) : base()
        {
            _sEOBlogTypeRepository = seOBlogTypeRepository;
        }
        [HttpPost]
        public int Add(SEOBlogType sEOBlogType)
        {
            var result = AppGlobal.InitializationNumber;
            if (sEOBlogType.ID > 0)
            {
                result = _sEOBlogTypeRepository.Update(sEOBlogType);
            }
            else
            {
                result = _sEOBlogTypeRepository.Add(sEOBlogType);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(SEOBlogType sEOBlogType)
        {
            var result = await _sEOBlogTypeRepository.AsyncAdd(sEOBlogType);
            return result;
        }
        [HttpPost]
        public int AddRange(List<SEOBlogType> list)
        {
            var result = _sEOBlogTypeRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<SEOBlogType> list)
        {
            var result = await _sEOBlogTypeRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(SEOBlogType sEOBlogType)
        {
            var result = _sEOBlogTypeRepository.Update(sEOBlogType);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(SEOBlogType sEOBlogType)
        {
            var result = await _sEOBlogTypeRepository.AsyncUpdate(sEOBlogType);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<SEOBlogType> list)
        {
            var result = _sEOBlogTypeRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<SEOBlogType> list)
        {
            var result = await _sEOBlogTypeRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<SEOBlogType> GetAllToList()
        {
            var result = _sEOBlogTypeRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<SEOBlogType>> AsyncGetAllToList()
        {
            var result = await _sEOBlogTypeRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<SEOBlogType> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _sEOBlogTypeRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<SEOBlogType>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _sEOBlogTypeRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<SEOBlogType> GetByParentIDToList(int parentID)
        {
            var result = _sEOBlogTypeRepository.GetByParentIDToList(parentID);
            return result;
        }
        [HttpGet]
        public SEOBlogType GetByID(int ID)
        {
            SEOBlogType result = _sEOBlogTypeRepository.GetByID(ID);
            if (result == null)
            {
                result = new SEOBlogType();
                result.Active = true;
            }
            return result;
        }
        [HttpGet]
        public SEOBlogType GetByIDString(string ID)
        {
            SEOBlogType result = new SEOBlogType();
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = _sEOBlogTypeRepository.GetByID(int.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            if (result == null)
            {
                result = new SEOBlogType();
                result.Active = true;
            }
            return result;
        }
    }
}

