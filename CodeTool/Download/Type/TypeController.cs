using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class TypeController: BaseController
{
private readonly ITypeRepository _typeRepository;
public TypeController(ITypeRepository typeRepository) : base()
{
_typeRepository = typeRepository;
}
[HttpPost]
public int Add(Type type)
{
var result = _typeRepository.Add(type);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Type type)
{
var result = await _typeRepository.AsyncAdd(type);
 return result;
}
[HttpPost]
public int AddRange(List<Type> list)
{
var result = _typeRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Type> list)
{
var result = await _typeRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Type type)
{
var result = _typeRepository.Update(type);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Type type)
{
var result = await _typeRepository.AsyncUpdate(type);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Type> list)
{
var result = _typeRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Type> list)
{
var result = await _typeRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Type> GetAllToList()
{
var result = _typeRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Type>> AsyncGetAllToList()
{
var result = await _typeRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Type> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _typeRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Type>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _typeRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

