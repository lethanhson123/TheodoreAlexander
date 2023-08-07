using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class BrandController: BaseController
{
private readonly IBrandRepository _brandRepository;
public BrandController(IBrandRepository brandRepository) : base()
{
_brandRepository = brandRepository;
}
[HttpPost]
public int Add(Brand brand)
{
var result = _brandRepository.Add(brand);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Brand brand)
{
var result = await _brandRepository.AsyncAdd(brand);
 return result;
}
[HttpPost]
public int AddRange(List<Brand> list)
{
var result = _brandRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Brand> list)
{
var result = await _brandRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Brand brand)
{
var result = _brandRepository.Update(brand);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Brand brand)
{
var result = await _brandRepository.AsyncUpdate(brand);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Brand> list)
{
var result = _brandRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Brand> list)
{
var result = await _brandRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Brand> GetAllToList()
{
var result = _brandRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Brand>> AsyncGetAllToList()
{
var result = await _brandRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Brand> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _brandRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Brand>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _brandRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

