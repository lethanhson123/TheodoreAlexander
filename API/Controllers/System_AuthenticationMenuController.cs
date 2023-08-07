using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class System_AuthenticationMenuController : BaseController
    {
        private readonly ISystem_AuthenticationMenuRepository _system_AuthenticationMenuRepository;
        public System_AuthenticationMenuController(ISystem_AuthenticationMenuRepository system_AuthenticationMenuRepository) : base()
        {
            _system_AuthenticationMenuRepository = system_AuthenticationMenuRepository;
        }
        [HttpPost]
        public int Add(System_AuthenticationMenu system_AuthenticationMenu)
        {
            var result = _system_AuthenticationMenuRepository.Add(system_AuthenticationMenu);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(System_AuthenticationMenu system_AuthenticationMenu)
        {
            var result = await _system_AuthenticationMenuRepository.AsyncAdd(system_AuthenticationMenu);
            return result;
        }
        [HttpPost]
        public int AddRange(List<System_AuthenticationMenu> list)
        {
            var result = _system_AuthenticationMenuRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<System_AuthenticationMenu> list)
        {
            var result = await _system_AuthenticationMenuRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(System_AuthenticationMenu system_AuthenticationMenu)
        {
            var result = _system_AuthenticationMenuRepository.Update(system_AuthenticationMenu);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(System_AuthenticationMenu system_AuthenticationMenu)
        {
            var result = await _system_AuthenticationMenuRepository.AsyncUpdate(system_AuthenticationMenu);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<System_AuthenticationMenu> list)
        {
            var result = _system_AuthenticationMenuRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<System_AuthenticationMenu> list)
        {
            var result = await _system_AuthenticationMenuRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<System_AuthenticationMenu> GetAllToList()
        {
            var result = _system_AuthenticationMenuRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<System_AuthenticationMenu>> AsyncGetAllToList()
        {
            var result = await _system_AuthenticationMenuRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<System_AuthenticationMenu> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _system_AuthenticationMenuRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<System_AuthenticationMenu>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _system_AuthenticationMenuRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
    }
}

