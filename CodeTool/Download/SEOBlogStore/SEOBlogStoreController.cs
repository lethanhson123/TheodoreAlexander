using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class SEOBlogStoreController: BaseController
{
private readonly ISEOBlogStoreRepository _sEOBlogStoreRepository;
public SEOBlogStoreController(ISEOBlogStoreRepository sEOBlogStoreRepository) : base()
{
_sEOBlogStoreRepository = sEOBlogStoreRepository;
}
[HttpPost]
public int Add(SEOBlogStore sEOBlogStore)
{
var result = _sEOBlogStoreRepository.Add(sEOBlogStore);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(SEOBlogStore sEOBlogStore)
{
var result = await _sEOBlogStoreRepository.AsyncAdd(sEOBlogStore);
 return result;
}
[HttpPost]
public int AddRange(List<SEOBlogStore> list)
{
var result = _sEOBlogStoreRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<SEOBlogStore> list)
{
var result = await _sEOBlogStoreRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(SEOBlogStore sEOBlogStore)
{
var result = _sEOBlogStoreRepository.Update(sEOBlogStore);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(SEOBlogStore sEOBlogStore)
{
var result = await _sEOBlogStoreRepository.AsyncUpdate(sEOBlogStore);
 return result;
}
[HttpDelete]
public int RemoveRange(List<SEOBlogStore> list)
{
var result = _sEOBlogStoreRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<SEOBlogStore> list)
{
var result = await _sEOBlogStoreRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<SEOBlogStore> GetAllToList()
{
var result = _sEOBlogStoreRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<SEOBlogStore>> AsyncGetAllToList()
{
var result = await _sEOBlogStoreRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<SEOBlogStore> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _sEOBlogStoreRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<SEOBlogStore>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _sEOBlogStoreRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

