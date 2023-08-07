using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_WorkingStatusNameController: BaseController
{
private readonly IHR_WorkingStatusNameRepository _hR_WorkingStatusNameRepository;
public HR_WorkingStatusNameController(IHR_WorkingStatusNameRepository hR_WorkingStatusNameRepository) : base()
{
_hR_WorkingStatusNameRepository = hR_WorkingStatusNameRepository;
}
[HttpPost]
public int Add(HR_WorkingStatusName hR_WorkingStatusName)
{
var result = _hR_WorkingStatusNameRepository.Add(hR_WorkingStatusName);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_WorkingStatusName hR_WorkingStatusName)
{
var result = await _hR_WorkingStatusNameRepository.AsyncAdd(hR_WorkingStatusName);
 return result;
}
[HttpPost]
public int AddRange(List<HR_WorkingStatusName> list)
{
var result = _hR_WorkingStatusNameRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_WorkingStatusName> list)
{
var result = await _hR_WorkingStatusNameRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_WorkingStatusName hR_WorkingStatusName)
{
var result = _hR_WorkingStatusNameRepository.Update(hR_WorkingStatusName);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_WorkingStatusName hR_WorkingStatusName)
{
var result = await _hR_WorkingStatusNameRepository.AsyncUpdate(hR_WorkingStatusName);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_WorkingStatusName> list)
{
var result = _hR_WorkingStatusNameRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_WorkingStatusName> list)
{
var result = await _hR_WorkingStatusNameRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_WorkingStatusName> GetAllToList()
{
var result = _hR_WorkingStatusNameRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_WorkingStatusName>> AsyncGetAllToList()
{
var result = await _hR_WorkingStatusNameRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_WorkingStatusName> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_WorkingStatusNameRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_WorkingStatusName>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_WorkingStatusNameRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

