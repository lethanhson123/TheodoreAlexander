using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class UserController: BaseController
{
private readonly IUserRepository _userRepository;
public UserController(IUserRepository userRepository) : base()
{
_userRepository = userRepository;
}
[HttpPost]
public int Add(User user)
{
var result = _userRepository.Add(user);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(User user)
{
var result = await _userRepository.AsyncAdd(user);
 return result;
}
[HttpPost]
public int AddRange(List<User> list)
{
var result = _userRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<User> list)
{
var result = await _userRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(User user)
{
var result = _userRepository.Update(user);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(User user)
{
var result = await _userRepository.AsyncUpdate(user);
 return result;
}
[HttpDelete]
public int RemoveRange(List<User> list)
{
var result = _userRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<User> list)
{
var result = await _userRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<User> GetAllToList()
{
var result = _userRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<User>> AsyncGetAllToList()
{
var result = await _userRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<User> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _userRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<User>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _userRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

