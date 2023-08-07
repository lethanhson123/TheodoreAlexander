using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class MarketingResourceController : BaseController
    {
        private readonly IMarketingResourceRepository _marketingResourceRepository;
        public MarketingResourceController(IMarketingResourceRepository marketingResourceRepository) : base()
        {
            _marketingResourceRepository = marketingResourceRepository;
        }
        [HttpPost]
        public MarketingResource Add(MarketingResource marketingResource)
        {
            var result = AppGlobal.InitializationNumber;
            if (marketingResource.ID > 0)
            {
                result = _marketingResourceRepository.Update(marketingResource);
            }
            else
            {
                result = _marketingResourceRepository.Add(marketingResource);
            }
            return marketingResource;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(MarketingResource marketingResource)
        {
            var result = await _marketingResourceRepository.AsyncAdd(marketingResource);
            return result;
        }
        [HttpPost]
        public int AddRange(List<MarketingResource> list)
        {
            var result = _marketingResourceRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<MarketingResource> list)
        {
            var result = await _marketingResourceRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(MarketingResource marketingResource)
        {
            var result = _marketingResourceRepository.Update(marketingResource);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(MarketingResource marketingResource)
        {
            var result = await _marketingResourceRepository.AsyncUpdate(marketingResource);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<MarketingResource> list)
        {
            var result = _marketingResourceRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<MarketingResource> list)
        {
            var result = await _marketingResourceRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<MarketingResource> GetAllToList()
        {
            var result = _marketingResourceRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<MarketingResource>> AsyncGetAllToList()
        {
            var result = await _marketingResourceRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<MarketingResource> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _marketingResourceRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<MarketingResource>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _marketingResourceRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<MarketingResource> GetByParentIDToList(int parentID)
        {
            var result = _marketingResourceRepository.GetByParentIDToList(parentID);
            return result;
        }
        [HttpGet]
        public List<MarketingResource> GetByParentIDAndActiveToList(int parentID, bool active)
        {
            var result = _marketingResourceRepository.GetByParentIDAndActiveToList(parentID, active);
            return result;
        }
        [HttpGet]
        public List<MarketingResource> GetByActiveToList(bool active)
        {
            var result = _marketingResourceRepository.GetByActiveToList(active);
            return result;
        }
        [HttpGet]
        public MarketingResource GetByID(int ID)
        {
            MarketingResource result = _marketingResourceRepository.GetByID(ID);
            if (result == null)
            {
                result = new MarketingResource();
                result.Active = true;
                result.IsUSShow = true;
                result.IsInternationalShow = true;
                result.IsDealerShow = true;
                result.IsDesignerShow = true;
                result.ParentID = 1;
            }
            return result;
        }
        [HttpGet]
        public MarketingResource GetByIDString(string ID)
        {
            MarketingResource result = new MarketingResource();
            result.Active = true;
            result.ParentID = 1;
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = _marketingResourceRepository.GetByID(int.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            if (result == null)
            {
                result = new MarketingResource();
                result.Active = true;
                result.IsUSShow = true;
                result.IsInternationalShow = true;
                result.IsDealerShow = true;
                result.IsDesignerShow = true;
                result.ParentID = 1;
            }
            return result;
        }
    }
}

