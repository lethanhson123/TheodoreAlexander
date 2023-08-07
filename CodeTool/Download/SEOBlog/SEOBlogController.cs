using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class SEOBlogController: BaseController
{
private readonly ISEOBlogRepository _sEOBlogRepository;
public SEOBlogController(ISEOBlogRepository sEOBlogRepository) : base()
{
_sEOBlogRepository = sEOBlogRepository;
}
[HttpPost]
public int Add(SEOBlog sEOBlog)
{
var result = _sEOBlogRepository.Add(sEOBlog);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(SEOBlog sEOBlog)
{
var result = await _sEOBlogRepository.AsyncAdd(sEOBlog);
 return result;
}
[HttpPost]
public int AddRange(List<SEOBlog> list)
{
var result = _sEOBlogRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<SEOBlog> list)
{
var result = await _sEOBlogRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(SEOBlog sEOBlog)
{
var result = _sEOBlogRepository.Update(sEOBlog);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(SEOBlog sEOBlog)
{
var result = await _sEOBlogRepository.AsyncUpdate(sEOBlog);
 return result;
}
[HttpDelete]
public int RemoveRange(List<SEOBlog> list)
{
var result = _sEOBlogRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<SEOBlog> list)
{
var result = await _sEOBlogRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<SEOBlog> GetAllToList()
{
var result = _sEOBlogRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<SEOBlog>> AsyncGetAllToList()
{
var result = await _sEOBlogRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<SEOBlog> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _sEOBlogRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<SEOBlog>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _sEOBlogRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

