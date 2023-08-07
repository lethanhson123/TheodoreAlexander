using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class StyleController: BaseController
{
private readonly IStyleRepository _styleRepository;
public StyleController(IStyleRepository styleRepository) : base()
{
_styleRepository = styleRepository;
}
[HttpPost]
public int Add(Style style)
{
var result = _styleRepository.Add(style);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Style style)
{
var result = await _styleRepository.AsyncAdd(style);
 return result;
}
[HttpPost]
public int AddRange(List<Style> list)
{
var result = _styleRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Style> list)
{
var result = await _styleRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Style style)
{
var result = _styleRepository.Update(style);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Style style)
{
var result = await _styleRepository.AsyncUpdate(style);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Style> list)
{
var result = _styleRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Style> list)
{
var result = await _styleRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Style> GetAllToList()
{
var result = _styleRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Style>> AsyncGetAllToList()
{
var result = await _styleRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Style> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _styleRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Style>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _styleRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

