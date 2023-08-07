using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class SEOKeywordController: BaseController
{
private readonly ISEOKeywordRepository _sEOKeywordRepository;
public SEOKeywordController(ISEOKeywordRepository sEOKeywordRepository) : base()
{
_sEOKeywordRepository = sEOKeywordRepository;
}
[HttpPost]
public int Add(SEOKeyword sEOKeyword)
{
var result = _sEOKeywordRepository.Add(sEOKeyword);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(SEOKeyword sEOKeyword)
{
var result = await _sEOKeywordRepository.AsyncAdd(sEOKeyword);
 return result;
}
[HttpPost]
public int AddRange(List<SEOKeyword> list)
{
var result = _sEOKeywordRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<SEOKeyword> list)
{
var result = await _sEOKeywordRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(SEOKeyword sEOKeyword)
{
var result = _sEOKeywordRepository.Update(sEOKeyword);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(SEOKeyword sEOKeyword)
{
var result = await _sEOKeywordRepository.AsyncUpdate(sEOKeyword);
 return result;
}
[HttpDelete]
public int RemoveRange(List<SEOKeyword> list)
{
var result = _sEOKeywordRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<SEOKeyword> list)
{
var result = await _sEOKeywordRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<SEOKeyword> GetAllToList()
{
var result = _sEOKeywordRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<SEOKeyword>> AsyncGetAllToList()
{
var result = await _sEOKeywordRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<SEOKeyword> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _sEOKeywordRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<SEOKeyword>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _sEOKeywordRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

