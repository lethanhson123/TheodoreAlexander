using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class HR_DistrictController : BaseController
    {
        private readonly IHR_DistrictRepository _hR_DistrictRepository;
        public HR_DistrictController(IHR_DistrictRepository hR_DistrictRepository) : base()
        {
            _hR_DistrictRepository = hR_DistrictRepository;
        }
        [HttpPost]
        public int Add(HR_District hR_District)
        {
            var result = _hR_DistrictRepository.Add(hR_District);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(HR_District hR_District)
        {
            var result = await _hR_DistrictRepository.AsyncAdd(hR_District);
            return result;
        }
        [HttpPost]
        public int AddRange(List<HR_District> list)
        {
            var result = _hR_DistrictRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<HR_District> list)
        {
            var result = await _hR_DistrictRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(HR_District hR_District)
        {
            var result = _hR_DistrictRepository.Update(hR_District);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(HR_District hR_District)
        {
            var result = await _hR_DistrictRepository.AsyncUpdate(hR_District);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<HR_District> list)
        {
            var result = _hR_DistrictRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<HR_District> list)
        {
            var result = await _hR_DistrictRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<HR_District> GetAllToList()
        {
            var result = _hR_DistrictRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<HR_District>> AsyncGetAllToList()
        {
            var result = await _hR_DistrictRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<HR_District> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _hR_DistrictRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<HR_District>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _hR_DistrictRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<HR_District> GetBySearchStringToList(string searchString)
        {
            var result = _hR_DistrictRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<HR_District> GetByParentIDToList(int parentID)
        {
            var result = _hR_DistrictRepository.GetByParentIDToList(parentID);
            return result;
        }
    }
}

