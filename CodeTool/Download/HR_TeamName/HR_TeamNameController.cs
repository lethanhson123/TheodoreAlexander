using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_TeamNameController: BaseController
{
private readonly IHR_TeamNameRepository _hR_TeamNameRepository;
public HR_TeamNameController(IHR_TeamNameRepository hR_TeamNameRepository) : base()
{
_hR_TeamNameRepository = hR_TeamNameRepository;
}
[HttpPost]
public int Add(HR_TeamName hR_TeamName)
{
var result = _hR_TeamNameRepository.Add(hR_TeamName);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_TeamName hR_TeamName)
{
var result = await _hR_TeamNameRepository.AsyncAdd(hR_TeamName);
 return result;
}
[HttpPost]
public int AddRange(List<HR_TeamName> list)
{
var result = _hR_TeamNameRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_TeamName> list)
{
var result = await _hR_TeamNameRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_TeamName hR_TeamName)
{
var result = _hR_TeamNameRepository.Update(hR_TeamName);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_TeamName hR_TeamName)
{
var result = await _hR_TeamNameRepository.AsyncUpdate(hR_TeamName);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_TeamName> list)
{
var result = _hR_TeamNameRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_TeamName> list)
{
var result = await _hR_TeamNameRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_TeamName> GetAllToList()
{
var result = _hR_TeamNameRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_TeamName>> AsyncGetAllToList()
{
var result = await _hR_TeamNameRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_TeamName> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_TeamNameRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_TeamName>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_TeamNameRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

