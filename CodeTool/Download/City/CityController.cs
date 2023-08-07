using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class CityController: BaseController
{
private readonly ICityRepository _cityRepository;
public CityController(ICityRepository cityRepository) : base()
{
_cityRepository = cityRepository;
}
[HttpPost]
public int Add(City city)
{
var result = _cityRepository.Add(city);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(City city)
{
var result = await _cityRepository.AsyncAdd(city);
 return result;
}
[HttpPost]
public int AddRange(List<City> list)
{
var result = _cityRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<City> list)
{
var result = await _cityRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(City city)
{
var result = _cityRepository.Update(city);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(City city)
{
var result = await _cityRepository.AsyncUpdate(city);
 return result;
}
[HttpDelete]
public int RemoveRange(List<City> list)
{
var result = _cityRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<City> list)
{
var result = await _cityRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<City> GetAllToList()
{
var result = _cityRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<City>> AsyncGetAllToList()
{
var result = await _cityRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<City> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _cityRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<City>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _cityRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

