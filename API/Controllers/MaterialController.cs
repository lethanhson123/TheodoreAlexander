using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class MaterialController : BaseController
    {
        private readonly IMaterialRepository _materialRepository;
        public MaterialController(IMaterialRepository materialRepository) : base()
        {
            _materialRepository = materialRepository;
        }
        [HttpPost]
        public int Add(Material material)
        {
            var result = _materialRepository.Add(material);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(Material material)
        {
            var result = await _materialRepository.AsyncAdd(material);
            return result;
        }
        [HttpPost]
        public int AddRange(List<Material> list)
        {
            var result = _materialRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<Material> list)
        {
            var result = await _materialRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(Material material)
        {
            var result = _materialRepository.Update(material);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(Material material)
        {
            var result = await _materialRepository.AsyncUpdate(material);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<Material> list)
        {
            var result = _materialRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<Material> list)
        {
            var result = await _materialRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<Material> GetAllToList()
        {
            var result = _materialRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<Material>> AsyncGetAllToList()
        {
            var result = await _materialRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<Material> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _materialRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<Material>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _materialRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
    }
}

