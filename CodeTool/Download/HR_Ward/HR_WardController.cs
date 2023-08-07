using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_WardController: BaseController
{
private readonly IHR_WardRepository _hR_WardRepository;
public HR_WardController(IHR_WardRepository hR_WardRepository) : base()
{
_hR_WardRepository = hR_WardRepository;
}
[HttpPost]
public int Add(HR_Ward hR_Ward)
{
var result = _hR_WardRepository.Add(hR_Ward);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Ward hR_Ward)
{
var result = await _hR_WardRepository.AsyncAdd(hR_Ward);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Ward> list)
{
var result = _hR_WardRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Ward> list)
{
var result = await _hR_WardRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Ward hR_Ward)
{
var result = _hR_WardRepository.Update(hR_Ward);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Ward hR_Ward)
{
var result = await _hR_WardRepository.AsyncUpdate(hR_Ward);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Ward> list)
{
var result = _hR_WardRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Ward> list)
{
var result = await _hR_WardRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Ward> GetAllToList()
{
var result = _hR_WardRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Ward>> AsyncGetAllToList()
{
var result = await _hR_WardRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Ward> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_WardRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Ward>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_WardRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

