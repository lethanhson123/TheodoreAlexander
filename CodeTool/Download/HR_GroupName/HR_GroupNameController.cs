using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_GroupNameController: BaseController
{
private readonly IHR_GroupNameRepository _hR_GroupNameRepository;
public HR_GroupNameController(IHR_GroupNameRepository hR_GroupNameRepository) : base()
{
_hR_GroupNameRepository = hR_GroupNameRepository;
}
[HttpPost]
public int Add(HR_GroupName hR_GroupName)
{
var result = _hR_GroupNameRepository.Add(hR_GroupName);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_GroupName hR_GroupName)
{
var result = await _hR_GroupNameRepository.AsyncAdd(hR_GroupName);
 return result;
}
[HttpPost]
public int AddRange(List<HR_GroupName> list)
{
var result = _hR_GroupNameRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_GroupName> list)
{
var result = await _hR_GroupNameRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_GroupName hR_GroupName)
{
var result = _hR_GroupNameRepository.Update(hR_GroupName);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_GroupName hR_GroupName)
{
var result = await _hR_GroupNameRepository.AsyncUpdate(hR_GroupName);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_GroupName> list)
{
var result = _hR_GroupNameRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_GroupName> list)
{
var result = await _hR_GroupNameRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_GroupName> GetAllToList()
{
var result = _hR_GroupNameRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_GroupName>> AsyncGetAllToList()
{
var result = await _hR_GroupNameRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_GroupName> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_GroupNameRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_GroupName>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_GroupNameRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

