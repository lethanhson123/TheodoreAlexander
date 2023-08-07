using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class RegionController: BaseController
{
private readonly IRegionRepository _regionRepository;
public RegionController(IRegionRepository regionRepository) : base()
{
_regionRepository = regionRepository;
}
[HttpPost]
public int Add(Region region)
{
var result = _regionRepository.Add(region);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Region region)
{
var result = await _regionRepository.AsyncAdd(region);
 return result;
}
[HttpPost]
public int AddRange(List<Region> list)
{
var result = _regionRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Region> list)
{
var result = await _regionRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Region region)
{
var result = _regionRepository.Update(region);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Region region)
{
var result = await _regionRepository.AsyncUpdate(region);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Region> list)
{
var result = _regionRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Region> list)
{
var result = await _regionRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Region> GetAllToList()
{
var result = _regionRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Region>> AsyncGetAllToList()
{
var result = await _regionRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Region> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _regionRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Region>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _regionRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

