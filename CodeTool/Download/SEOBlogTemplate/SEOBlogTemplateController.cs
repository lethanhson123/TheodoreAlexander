using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class SEOBlogTemplateController: BaseController
{
private readonly ISEOBlogTemplateRepository _sEOBlogTemplateRepository;
public SEOBlogTemplateController(ISEOBlogTemplateRepository sEOBlogTemplateRepository) : base()
{
_sEOBlogTemplateRepository = sEOBlogTemplateRepository;
}
[HttpPost]
public int Add(SEOBlogTemplate sEOBlogTemplate)
{
var result = _sEOBlogTemplateRepository.Add(sEOBlogTemplate);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(SEOBlogTemplate sEOBlogTemplate)
{
var result = await _sEOBlogTemplateRepository.AsyncAdd(sEOBlogTemplate);
 return result;
}
[HttpPost]
public int AddRange(List<SEOBlogTemplate> list)
{
var result = _sEOBlogTemplateRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<SEOBlogTemplate> list)
{
var result = await _sEOBlogTemplateRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(SEOBlogTemplate sEOBlogTemplate)
{
var result = _sEOBlogTemplateRepository.Update(sEOBlogTemplate);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(SEOBlogTemplate sEOBlogTemplate)
{
var result = await _sEOBlogTemplateRepository.AsyncUpdate(sEOBlogTemplate);
 return result;
}
[HttpDelete]
public int RemoveRange(List<SEOBlogTemplate> list)
{
var result = _sEOBlogTemplateRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<SEOBlogTemplate> list)
{
var result = await _sEOBlogTemplateRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<SEOBlogTemplate> GetAllToList()
{
var result = _sEOBlogTemplateRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<SEOBlogTemplate>> AsyncGetAllToList()
{
var result = await _sEOBlogTemplateRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<SEOBlogTemplate> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _sEOBlogTemplateRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<SEOBlogTemplate>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _sEOBlogTemplateRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

