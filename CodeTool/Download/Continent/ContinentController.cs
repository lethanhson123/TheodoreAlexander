using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class ContinentController: BaseController
{
private readonly IContinentRepository _continentRepository;
public ContinentController(IContinentRepository continentRepository) : base()
{
_continentRepository = continentRepository;
}
[HttpPost]
public int Add(Continent continent)
{
var result = _continentRepository.Add(continent);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Continent continent)
{
var result = await _continentRepository.AsyncAdd(continent);
 return result;
}
[HttpPost]
public int AddRange(List<Continent> list)
{
var result = _continentRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Continent> list)
{
var result = await _continentRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Continent continent)
{
var result = _continentRepository.Update(continent);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Continent continent)
{
var result = await _continentRepository.AsyncUpdate(continent);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Continent> list)
{
var result = _continentRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Continent> list)
{
var result = await _continentRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Continent> GetAllToList()
{
var result = _continentRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Continent>> AsyncGetAllToList()
{
var result = await _continentRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Continent> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _continentRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Continent>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _continentRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

