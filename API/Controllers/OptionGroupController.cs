using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class OptionGroupController : BaseController
    {
        private readonly IOptionGroupRepository _optionGroupRepository;
        public OptionGroupController(IOptionGroupRepository optionGroupRepository) : base()
        {
            _optionGroupRepository = optionGroupRepository;
        }
        [HttpPost]
        public int Add(OptionGroup optionGroup)
        {
            var result = _optionGroupRepository.Add(optionGroup);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(OptionGroup optionGroup)
        {
            var result = await _optionGroupRepository.AsyncAdd(optionGroup);
            return result;
        }
        [HttpPost]
        public int AddRange(List<OptionGroup> list)
        {
            var result = _optionGroupRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<OptionGroup> list)
        {
            var result = await _optionGroupRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(OptionGroup optionGroup)
        {
            var result = _optionGroupRepository.Update(optionGroup);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(OptionGroup optionGroup)
        {
            var result = await _optionGroupRepository.AsyncUpdate(optionGroup);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<OptionGroup> list)
        {
            var result = _optionGroupRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<OptionGroup> list)
        {
            var result = await _optionGroupRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<OptionGroup> GetAllToList()
        {
            var result = _optionGroupRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<OptionGroup>> AsyncGetAllToList()
        {
            var result = await _optionGroupRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<OptionGroup> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _optionGroupRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<OptionGroup>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _optionGroupRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
    }
}

