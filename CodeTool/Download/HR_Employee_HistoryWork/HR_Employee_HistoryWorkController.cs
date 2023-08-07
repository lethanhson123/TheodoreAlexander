using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_Employee_HistoryWorkController: BaseController
{
private readonly IHR_Employee_HistoryWorkRepository _hR_Employee_HistoryWorkRepository;
public HR_Employee_HistoryWorkController(IHR_Employee_HistoryWorkRepository hR_Employee_HistoryWorkRepository) : base()
{
_hR_Employee_HistoryWorkRepository = hR_Employee_HistoryWorkRepository;
}
[HttpPost]
public int Add(HR_Employee_HistoryWork hR_Employee_HistoryWork)
{
var result = _hR_Employee_HistoryWorkRepository.Add(hR_Employee_HistoryWork);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Employee_HistoryWork hR_Employee_HistoryWork)
{
var result = await _hR_Employee_HistoryWorkRepository.AsyncAdd(hR_Employee_HistoryWork);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Employee_HistoryWork> list)
{
var result = _hR_Employee_HistoryWorkRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Employee_HistoryWork> list)
{
var result = await _hR_Employee_HistoryWorkRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Employee_HistoryWork hR_Employee_HistoryWork)
{
var result = _hR_Employee_HistoryWorkRepository.Update(hR_Employee_HistoryWork);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Employee_HistoryWork hR_Employee_HistoryWork)
{
var result = await _hR_Employee_HistoryWorkRepository.AsyncUpdate(hR_Employee_HistoryWork);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Employee_HistoryWork> list)
{
var result = _hR_Employee_HistoryWorkRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Employee_HistoryWork> list)
{
var result = await _hR_Employee_HistoryWorkRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Employee_HistoryWork> GetAllToList()
{
var result = _hR_Employee_HistoryWorkRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Employee_HistoryWork>> AsyncGetAllToList()
{
var result = await _hR_Employee_HistoryWorkRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Employee_HistoryWork> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_Employee_HistoryWorkRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Employee_HistoryWork>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_Employee_HistoryWorkRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

