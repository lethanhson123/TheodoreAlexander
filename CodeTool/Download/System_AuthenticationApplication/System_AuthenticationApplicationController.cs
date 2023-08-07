using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class System_AuthenticationApplicationController: BaseController
{
private readonly ISystem_AuthenticationApplicationRepository _system_AuthenticationApplicationRepository;
public System_AuthenticationApplicationController(ISystem_AuthenticationApplicationRepository system_AuthenticationApplicationRepository) : base()
{
_system_AuthenticationApplicationRepository = system_AuthenticationApplicationRepository;
}
[HttpPost]
public int Add(System_AuthenticationApplication system_AuthenticationApplication)
{
var result = _system_AuthenticationApplicationRepository.Add(system_AuthenticationApplication);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(System_AuthenticationApplication system_AuthenticationApplication)
{
var result = await _system_AuthenticationApplicationRepository.AsyncAdd(system_AuthenticationApplication);
 return result;
}
[HttpPost]
public int AddRange(List<System_AuthenticationApplication> list)
{
var result = _system_AuthenticationApplicationRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<System_AuthenticationApplication> list)
{
var result = await _system_AuthenticationApplicationRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(System_AuthenticationApplication system_AuthenticationApplication)
{
var result = _system_AuthenticationApplicationRepository.Update(system_AuthenticationApplication);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(System_AuthenticationApplication system_AuthenticationApplication)
{
var result = await _system_AuthenticationApplicationRepository.AsyncUpdate(system_AuthenticationApplication);
 return result;
}
[HttpDelete]
public int RemoveRange(List<System_AuthenticationApplication> list)
{
var result = _system_AuthenticationApplicationRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<System_AuthenticationApplication> list)
{
var result = await _system_AuthenticationApplicationRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<System_AuthenticationApplication> GetAllToList()
{
var result = _system_AuthenticationApplicationRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<System_AuthenticationApplication>> AsyncGetAllToList()
{
var result = await _system_AuthenticationApplicationRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<System_AuthenticationApplication> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _system_AuthenticationApplicationRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<System_AuthenticationApplication>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _system_AuthenticationApplicationRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

