using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class StoreController : BaseController
    {
        private readonly IStoreRepository _storeRepository;
        public StoreController(IStoreRepository storeRepository) : base()
        {
            _storeRepository = storeRepository;
        }
        [HttpPost]
        public int Add(Store store)
        {
            var result = _storeRepository.Add(store);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(Store store)
        {
            var result = await _storeRepository.AsyncAdd(store);
            return result;
        }
        [HttpPost]
        public int AddRange(List<Store> list)
        {
            var result = _storeRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<Store> list)
        {
            var result = await _storeRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(Store store)
        {
            var result = _storeRepository.Update(store);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(Store store)
        {
            var result = await _storeRepository.AsyncUpdate(store);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<Store> list)
        {
            var result = _storeRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<Store> list)
        {
            var result = await _storeRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<Store> GetAllToList()
        {
            var result = _storeRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<Store>> AsyncGetAllToList()
        {
            var result = await _storeRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<Store> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _storeRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<Store>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _storeRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<Store> GetBySearchStringToList(string searchString)
        {
            var result = _storeRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<StoreDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            var result = _storeRepository.GetDataTransferBySearchStringToList(searchString);
            return result;
        }
    }
}

