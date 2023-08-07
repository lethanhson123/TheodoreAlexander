using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_DutyController: BaseController
{
private readonly IHR_DutyRepository _hR_DutyRepository;
public HR_DutyController(IHR_DutyRepository hR_DutyRepository) : base()
{
_hR_DutyRepository = hR_DutyRepository;
}
[HttpPost]
public int Add(HR_Duty hR_Duty)
{
var result = _hR_DutyRepository.Add(hR_Duty);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Duty hR_Duty)
{
var result = await _hR_DutyRepository.AsyncAdd(hR_Duty);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Duty> list)
{
var result = _hR_DutyRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Duty> list)
{
var result = await _hR_DutyRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Duty hR_Duty)
{
var result = _hR_DutyRepository.Update(hR_Duty);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Duty hR_Duty)
{
var result = await _hR_DutyRepository.AsyncUpdate(hR_Duty);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Duty> list)
{
var result = _hR_DutyRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Duty> list)
{
var result = await _hR_DutyRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Duty> GetAllToList()
{
var result = _hR_DutyRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Duty>> AsyncGetAllToList()
{
var result = await _hR_DutyRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Duty> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_DutyRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Duty>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_DutyRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

