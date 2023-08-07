using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class HR_BlockController : BaseController
    {
        private readonly IHR_BlockRepository _HR_BlockRepository;
        public HR_BlockController(IHR_BlockRepository HR_BlockRepository) : base()
        {
            _HR_BlockRepository = HR_BlockRepository;
        }
        [HttpPost]
        public int Add(HR_Block HR_Block)
        {
            var result = _HR_BlockRepository.Add(HR_Block);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(HR_Block HR_Block)
        {
            var result = await _HR_BlockRepository.AsyncAdd(HR_Block);
            return result;
        }
        [HttpPost]
        public int AddRange(List<HR_Block> list)
        {
            var result = _HR_BlockRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<HR_Block> list)
        {
            var result = await _HR_BlockRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(HR_Block HR_Block)
        {
            var result = _HR_BlockRepository.Update(HR_Block);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(HR_Block HR_Block)
        {
            var result = await _HR_BlockRepository.AsyncUpdate(HR_Block);
            return result;
        }        
        [HttpDelete]
        public int RemoveRange(List<HR_Block> list)
        {
            var result = _HR_BlockRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<HR_Block> list)
        {
            var result = await _HR_BlockRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<HR_Block> GetAllToList()
        {
            var result = _HR_BlockRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Block>> AsyncGetAllToList()
        {
            var result = await _HR_BlockRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<HR_Block> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _HR_BlockRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Block>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _HR_BlockRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
    }
}

