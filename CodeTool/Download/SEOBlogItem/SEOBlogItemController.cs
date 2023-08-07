using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class SEOBlogItemController: BaseController
{
private readonly ISEOBlogItemRepository _sEOBlogItemRepository;
public SEOBlogItemController(ISEOBlogItemRepository sEOBlogItemRepository) : base()
{
_sEOBlogItemRepository = sEOBlogItemRepository;
}
[HttpPost]
public int Add(SEOBlogItem sEOBlogItem)
{
var result = _sEOBlogItemRepository.Add(sEOBlogItem);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(SEOBlogItem sEOBlogItem)
{
var result = await _sEOBlogItemRepository.AsyncAdd(sEOBlogItem);
 return result;
}
[HttpPost]
public int AddRange(List<SEOBlogItem> list)
{
var result = _sEOBlogItemRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<SEOBlogItem> list)
{
var result = await _sEOBlogItemRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(SEOBlogItem sEOBlogItem)
{
var result = _sEOBlogItemRepository.Update(sEOBlogItem);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(SEOBlogItem sEOBlogItem)
{
var result = await _sEOBlogItemRepository.AsyncUpdate(sEOBlogItem);
 return result;
}
[HttpDelete]
public int RemoveRange(List<SEOBlogItem> list)
{
var result = _sEOBlogItemRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<SEOBlogItem> list)
{
var result = await _sEOBlogItemRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<SEOBlogItem> GetAllToList()
{
var result = _sEOBlogItemRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<SEOBlogItem>> AsyncGetAllToList()
{
var result = await _sEOBlogItemRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<SEOBlogItem> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _sEOBlogItemRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<SEOBlogItem>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _sEOBlogItemRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

