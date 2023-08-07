using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class CountryController: BaseController
{
private readonly ICountryRepository _countryRepository;
public CountryController(ICountryRepository countryRepository) : base()
{
_countryRepository = countryRepository;
}
[HttpPost]
public int Add(Country country)
{
var result = _countryRepository.Add(country);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Country country)
{
var result = await _countryRepository.AsyncAdd(country);
 return result;
}
[HttpPost]
public int AddRange(List<Country> list)
{
var result = _countryRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Country> list)
{
var result = await _countryRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Country country)
{
var result = _countryRepository.Update(country);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Country country)
{
var result = await _countryRepository.AsyncUpdate(country);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Country> list)
{
var result = _countryRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Country> list)
{
var result = await _countryRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Country> GetAllToList()
{
var result = _countryRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Country>> AsyncGetAllToList()
{
var result = await _countryRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Country> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _countryRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Country>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _countryRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

