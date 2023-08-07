using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class HR_ProvinceController : BaseController
    {
        private readonly IHR_ProvinceRepository _hR_ProvinceRepository;
        public HR_ProvinceController(IHR_ProvinceRepository hR_ProvinceRepository) : base()
        {
            _hR_ProvinceRepository = hR_ProvinceRepository;
        }
        [HttpPost]
        public int Add(HR_Province hR_Province)
        {
            var result = _hR_ProvinceRepository.Add(hR_Province);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(HR_Province hR_Province)
        {
            var result = await _hR_ProvinceRepository.AsyncAdd(hR_Province);
            return result;
        }
        [HttpPost]
        public int AddRange(List<HR_Province> list)
        {
            var result = _hR_ProvinceRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<HR_Province> list)
        {
            var result = await _hR_ProvinceRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(HR_Province hR_Province)
        {
            var result = _hR_ProvinceRepository.Update(hR_Province);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(HR_Province hR_Province)
        {
            var result = await _hR_ProvinceRepository.AsyncUpdate(hR_Province);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<HR_Province> list)
        {
            var result = _hR_ProvinceRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<HR_Province> list)
        {
            var result = await _hR_ProvinceRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<HR_Province> GetAllToList()
        {
            var result = _hR_ProvinceRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Province>> AsyncGetAllToList()
        {
            var result = await _hR_ProvinceRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<HR_Province> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _hR_ProvinceRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Province>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _hR_ProvinceRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<HR_Province> GetBySearchStringToList(string searchString)
        {
            var result = _hR_ProvinceRepository.GetBySearchStringToList(searchString);
            return result;
        }
    }
}

