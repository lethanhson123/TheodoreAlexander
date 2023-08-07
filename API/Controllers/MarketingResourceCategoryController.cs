using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class MarketingResourceCategoryController : BaseController
    {
        private readonly IMarketingResourceCategoryRepository _marketingResourceCategoryRepository;
        public MarketingResourceCategoryController(IMarketingResourceCategoryRepository marketingResourceCategoryRepository) : base()
        {
            _marketingResourceCategoryRepository = marketingResourceCategoryRepository;
        }
        [HttpPost]
        public int Add(MarketingResourceCategory marketingResourceCategory)
        {
            var result = AppGlobal.InitializationNumber;
            if (marketingResourceCategory.ID > 0)
            {
                result = _marketingResourceCategoryRepository.Update(marketingResourceCategory);
            }
            else
            {
                result = _marketingResourceCategoryRepository.Add(marketingResourceCategory);
            }
            return result;            
        }
        [HttpPost]
        public async Task<int> AsyncAdd(MarketingResourceCategory marketingResourceCategory)
        {
            var result = await _marketingResourceCategoryRepository.AsyncAdd(marketingResourceCategory);
            return result;
        }
        [HttpPost]
        public int AddRange(List<MarketingResourceCategory> list)
        {
            var result = _marketingResourceCategoryRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<MarketingResourceCategory> list)
        {
            var result = await _marketingResourceCategoryRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(MarketingResourceCategory marketingResourceCategory)
        {
            var result = _marketingResourceCategoryRepository.Update(marketingResourceCategory);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(MarketingResourceCategory marketingResourceCategory)
        {
            var result = await _marketingResourceCategoryRepository.AsyncUpdate(marketingResourceCategory);
            return result;
        }        
        [HttpDelete]
        public int RemoveRange(List<MarketingResourceCategory> list)
        {
            var result = _marketingResourceCategoryRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<MarketingResourceCategory> list)
        {
            var result = await _marketingResourceCategoryRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<MarketingResourceCategory> GetAllToList()
        {
            var result = _marketingResourceCategoryRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<MarketingResourceCategory>> AsyncGetAllToList()
        {
            var result = await _marketingResourceCategoryRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<MarketingResourceCategory> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _marketingResourceCategoryRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<MarketingResourceCategory>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _marketingResourceCategoryRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<MarketingResourceCategory> GetByParentIDToList(int parentID)
        {
            var result = _marketingResourceCategoryRepository.GetByParentIDToList(parentID);
            return result;
        }
        [HttpGet]
        public List<MarketingResourceCategory> GetByActiveToList(bool active)
        {
            var result = _marketingResourceCategoryRepository.GetByActiveToList(active);
            return result;
        }
        [HttpGet]
        public MarketingResourceCategory GetByID(int ID)
        {
            MarketingResourceCategory result = _marketingResourceCategoryRepository.GetByID(ID);
            if (result == null)
            {
                result = new MarketingResourceCategory();
                result.Active = true;
                result.IsUSShow = true;
                result.IsInternationalShow = true;
            }
            return result;
        }
    }
}

