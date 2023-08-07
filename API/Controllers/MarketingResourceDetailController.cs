using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class MarketingResourceDetailController : BaseController
    {
        private readonly IMarketingResourceDetailRepository _marketingResourceDetailRepository;
        public MarketingResourceDetailController(IMarketingResourceDetailRepository marketingResourceDetailRepository) : base()
        {
            _marketingResourceDetailRepository = marketingResourceDetailRepository;
        }
        [HttpPost]
        public int Add(MarketingResourceDetail marketingResourceDetail)
        {
            var result = AppGlobal.InitializationNumber;
            if (marketingResourceDetail.ID > 0)
            {
                result = _marketingResourceDetailRepository.Update(marketingResourceDetail);
            }
            else
            {
                result = _marketingResourceDetailRepository.Add(marketingResourceDetail);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(MarketingResourceDetail marketingResourceDetail)
        {
            var result = await _marketingResourceDetailRepository.AsyncAdd(marketingResourceDetail);
            return result;
        }
        [HttpPost]
        public int AddRange(List<MarketingResourceDetail> list)
        {
            var result = _marketingResourceDetailRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<MarketingResourceDetail> list)
        {
            var result = await _marketingResourceDetailRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(MarketingResourceDetail marketingResourceDetail)
        {
            var result = _marketingResourceDetailRepository.Update(marketingResourceDetail);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(MarketingResourceDetail marketingResourceDetail)
        {
            var result = await _marketingResourceDetailRepository.AsyncUpdate(marketingResourceDetail);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<MarketingResourceDetail> list)
        {
            var result = _marketingResourceDetailRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<MarketingResourceDetail> list)
        {
            var result = await _marketingResourceDetailRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<MarketingResourceDetail> GetAllToList()
        {
            var result = _marketingResourceDetailRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<MarketingResourceDetail>> AsyncGetAllToList()
        {
            var result = await _marketingResourceDetailRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<MarketingResourceDetail> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _marketingResourceDetailRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<MarketingResourceDetail>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _marketingResourceDetailRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<MarketingResourceDetail> GetByParentIDToList(int parentID)
        {
            var result = _marketingResourceDetailRepository.GetByParentIDToList(parentID);
            return result;
        }
        [HttpGet]
        public List<MarketingResourceDetail> GetByParentIDAndActiveToList(int parentID, bool active)
        {
            var result = _marketingResourceDetailRepository.GetByParentIDAndActiveToList(parentID, active);
            return result;
        }
        [HttpGet]
        public List<MarketingResourceDetail> GetByActiveToList(bool active)
        {
            var result = _marketingResourceDetailRepository.GetByActiveToList(active);
            return result;
        }
        [HttpGet]
        public MarketingResourceDetail GetByID(int ID)
        {
            MarketingResourceDetail result = _marketingResourceDetailRepository.GetByID(ID);
            if (result == null)
            {
                result = new MarketingResourceDetail();
                result.Active = true;
                result.IsUSShow = true;
                result.IsInternationalShow = true;
            }
            return result;
        }
    }
}

