using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class System_MembershipController: BaseController
{
private readonly ISystem_MembershipRepository _system_MembershipRepository;
public System_MembershipController(ISystem_MembershipRepository system_MembershipRepository) : base()
{
_system_MembershipRepository = system_MembershipRepository;
}
[HttpPost]
public int Add(System_Membership system_Membership)
{
var result = _system_MembershipRepository.Add(system_Membership);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(System_Membership system_Membership)
{
var result = await _system_MembershipRepository.AsyncAdd(system_Membership);
 return result;
}
[HttpPost]
public int AddRange(List<System_Membership> list)
{
var result = _system_MembershipRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<System_Membership> list)
{
var result = await _system_MembershipRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(System_Membership system_Membership)
{
var result = _system_MembershipRepository.Update(system_Membership);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(System_Membership system_Membership)
{
var result = await _system_MembershipRepository.AsyncUpdate(system_Membership);
 return result;
}
[HttpDelete]
public int RemoveRange(List<System_Membership> list)
{
var result = _system_MembershipRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<System_Membership> list)
{
var result = await _system_MembershipRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<System_Membership> GetAllToList()
{
var result = _system_MembershipRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<System_Membership>> AsyncGetAllToList()
{
var result = await _system_MembershipRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<System_Membership> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _system_MembershipRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<System_Membership>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _system_MembershipRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

