using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_CovidLocalController: BaseController
{
private readonly IHR_CovidLocalRepository _hR_CovidLocalRepository;
public HR_CovidLocalController(IHR_CovidLocalRepository hR_CovidLocalRepository) : base()
{
_hR_CovidLocalRepository = hR_CovidLocalRepository;
}
[HttpPost]
public int Add(HR_CovidLocal hR_CovidLocal)
{
var result = _hR_CovidLocalRepository.Add(hR_CovidLocal);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_CovidLocal hR_CovidLocal)
{
var result = await _hR_CovidLocalRepository.AsyncAdd(hR_CovidLocal);
 return result;
}
[HttpPost]
public int AddRange(List<HR_CovidLocal> list)
{
var result = _hR_CovidLocalRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_CovidLocal> list)
{
var result = await _hR_CovidLocalRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_CovidLocal hR_CovidLocal)
{
var result = _hR_CovidLocalRepository.Update(hR_CovidLocal);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_CovidLocal hR_CovidLocal)
{
var result = await _hR_CovidLocalRepository.AsyncUpdate(hR_CovidLocal);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_CovidLocal> list)
{
var result = _hR_CovidLocalRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_CovidLocal> list)
{
var result = await _hR_CovidLocalRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_CovidLocal> GetAllToList()
{
var result = _hR_CovidLocalRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_CovidLocal>> AsyncGetAllToList()
{
var result = await _hR_CovidLocalRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_CovidLocal> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_CovidLocalRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_CovidLocal>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_CovidLocalRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

