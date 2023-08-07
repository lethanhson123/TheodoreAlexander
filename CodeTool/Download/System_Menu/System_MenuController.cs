using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class System_MenuController: BaseController
{
private readonly ISystem_MenuRepository _system_MenuRepository;
public System_MenuController(ISystem_MenuRepository system_MenuRepository) : base()
{
_system_MenuRepository = system_MenuRepository;
}
[HttpPost]
public int Add(System_Menu system_Menu)
{
var result = _system_MenuRepository.Add(system_Menu);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(System_Menu system_Menu)
{
var result = await _system_MenuRepository.AsyncAdd(system_Menu);
 return result;
}
[HttpPost]
public int AddRange(List<System_Menu> list)
{
var result = _system_MenuRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<System_Menu> list)
{
var result = await _system_MenuRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(System_Menu system_Menu)
{
var result = _system_MenuRepository.Update(system_Menu);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(System_Menu system_Menu)
{
var result = await _system_MenuRepository.AsyncUpdate(system_Menu);
 return result;
}
[HttpDelete]
public int RemoveRange(List<System_Menu> list)
{
var result = _system_MenuRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<System_Menu> list)
{
var result = await _system_MenuRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<System_Menu> GetAllToList()
{
var result = _system_MenuRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<System_Menu>> AsyncGetAllToList()
{
var result = await _system_MenuRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<System_Menu> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _system_MenuRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<System_Menu>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _system_MenuRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

