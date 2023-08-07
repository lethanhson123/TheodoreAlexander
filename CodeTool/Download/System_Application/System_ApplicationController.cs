using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class System_ApplicationController: BaseController
{
private readonly ISystem_ApplicationRepository _system_ApplicationRepository;
public System_ApplicationController(ISystem_ApplicationRepository system_ApplicationRepository) : base()
{
_system_ApplicationRepository = system_ApplicationRepository;
}
[HttpPost]
public int Add(System_Application system_Application)
{
var result = _system_ApplicationRepository.Add(system_Application);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(System_Application system_Application)
{
var result = await _system_ApplicationRepository.AsyncAdd(system_Application);
 return result;
}
[HttpPost]
public int AddRange(List<System_Application> list)
{
var result = _system_ApplicationRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<System_Application> list)
{
var result = await _system_ApplicationRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(System_Application system_Application)
{
var result = _system_ApplicationRepository.Update(system_Application);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(System_Application system_Application)
{
var result = await _system_ApplicationRepository.AsyncUpdate(system_Application);
 return result;
}
[HttpDelete]
public int RemoveRange(List<System_Application> list)
{
var result = _system_ApplicationRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<System_Application> list)
{
var result = await _system_ApplicationRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<System_Application> GetAllToList()
{
var result = _system_ApplicationRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<System_Application>> AsyncGetAllToList()
{
var result = await _system_ApplicationRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<System_Application> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _system_ApplicationRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<System_Application>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _system_ApplicationRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

