using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_CovidResultController: BaseController
{
private readonly IHR_CovidResultRepository _hR_CovidResultRepository;
public HR_CovidResultController(IHR_CovidResultRepository hR_CovidResultRepository) : base()
{
_hR_CovidResultRepository = hR_CovidResultRepository;
}
[HttpPost]
public int Add(HR_CovidResult hR_CovidResult)
{
var result = _hR_CovidResultRepository.Add(hR_CovidResult);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_CovidResult hR_CovidResult)
{
var result = await _hR_CovidResultRepository.AsyncAdd(hR_CovidResult);
 return result;
}
[HttpPost]
public int AddRange(List<HR_CovidResult> list)
{
var result = _hR_CovidResultRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_CovidResult> list)
{
var result = await _hR_CovidResultRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_CovidResult hR_CovidResult)
{
var result = _hR_CovidResultRepository.Update(hR_CovidResult);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_CovidResult hR_CovidResult)
{
var result = await _hR_CovidResultRepository.AsyncUpdate(hR_CovidResult);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_CovidResult> list)
{
var result = _hR_CovidResultRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_CovidResult> list)
{
var result = await _hR_CovidResultRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_CovidResult> GetAllToList()
{
var result = _hR_CovidResultRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_CovidResult>> AsyncGetAllToList()
{
var result = await _hR_CovidResultRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_CovidResult> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_CovidResultRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_CovidResult>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_CovidResultRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

