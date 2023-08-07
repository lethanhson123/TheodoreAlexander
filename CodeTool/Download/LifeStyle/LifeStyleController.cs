using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class LifeStyleController: BaseController
{
private readonly ILifeStyleRepository _lifeStyleRepository;
public LifeStyleController(ILifeStyleRepository lifeStyleRepository) : base()
{
_lifeStyleRepository = lifeStyleRepository;
}
[HttpPost]
public int Add(LifeStyle lifeStyle)
{
var result = _lifeStyleRepository.Add(lifeStyle);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(LifeStyle lifeStyle)
{
var result = await _lifeStyleRepository.AsyncAdd(lifeStyle);
 return result;
}
[HttpPost]
public int AddRange(List<LifeStyle> list)
{
var result = _lifeStyleRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<LifeStyle> list)
{
var result = await _lifeStyleRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(LifeStyle lifeStyle)
{
var result = _lifeStyleRepository.Update(lifeStyle);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(LifeStyle lifeStyle)
{
var result = await _lifeStyleRepository.AsyncUpdate(lifeStyle);
 return result;
}
[HttpDelete]
public int RemoveRange(List<LifeStyle> list)
{
var result = _lifeStyleRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<LifeStyle> list)
{
var result = await _lifeStyleRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<LifeStyle> GetAllToList()
{
var result = _lifeStyleRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<LifeStyle>> AsyncGetAllToList()
{
var result = await _lifeStyleRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<LifeStyle> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _lifeStyleRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<LifeStyle>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _lifeStyleRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

