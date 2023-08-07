using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class System_AuthenticationTokenController: BaseController
{
private readonly ISystem_AuthenticationTokenRepository _system_AuthenticationTokenRepository;
public System_AuthenticationTokenController(ISystem_AuthenticationTokenRepository system_AuthenticationTokenRepository) : base()
{
_system_AuthenticationTokenRepository = system_AuthenticationTokenRepository;
}
[HttpPost]
public int Add(System_AuthenticationToken system_AuthenticationToken)
{
var result = _system_AuthenticationTokenRepository.Add(system_AuthenticationToken);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(System_AuthenticationToken system_AuthenticationToken)
{
var result = await _system_AuthenticationTokenRepository.AsyncAdd(system_AuthenticationToken);
 return result;
}
[HttpPost]
public int AddRange(List<System_AuthenticationToken> list)
{
var result = _system_AuthenticationTokenRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<System_AuthenticationToken> list)
{
var result = await _system_AuthenticationTokenRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(System_AuthenticationToken system_AuthenticationToken)
{
var result = _system_AuthenticationTokenRepository.Update(system_AuthenticationToken);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(System_AuthenticationToken system_AuthenticationToken)
{
var result = await _system_AuthenticationTokenRepository.AsyncUpdate(system_AuthenticationToken);
 return result;
}
[HttpDelete]
public int RemoveRange(List<System_AuthenticationToken> list)
{
var result = _system_AuthenticationTokenRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<System_AuthenticationToken> list)
{
var result = await _system_AuthenticationTokenRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<System_AuthenticationToken> GetAllToList()
{
var result = _system_AuthenticationTokenRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<System_AuthenticationToken>> AsyncGetAllToList()
{
var result = await _system_AuthenticationTokenRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<System_AuthenticationToken> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _system_AuthenticationTokenRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<System_AuthenticationToken>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _system_AuthenticationTokenRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

