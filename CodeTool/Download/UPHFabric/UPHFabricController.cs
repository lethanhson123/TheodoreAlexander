using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class UPHFabricController: BaseController
{
private readonly IUPHFabricRepository _uPHFabricRepository;
public UPHFabricController(IUPHFabricRepository uPHFabricRepository) : base()
{
_uPHFabricRepository = uPHFabricRepository;
}
[HttpPost]
public int Add(UPHFabric uPHFabric)
{
var result = _uPHFabricRepository.Add(uPHFabric);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(UPHFabric uPHFabric)
{
var result = await _uPHFabricRepository.AsyncAdd(uPHFabric);
 return result;
}
[HttpPost]
public int AddRange(List<UPHFabric> list)
{
var result = _uPHFabricRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<UPHFabric> list)
{
var result = await _uPHFabricRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(UPHFabric uPHFabric)
{
var result = _uPHFabricRepository.Update(uPHFabric);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(UPHFabric uPHFabric)
{
var result = await _uPHFabricRepository.AsyncUpdate(uPHFabric);
 return result;
}
[HttpDelete]
public int RemoveRange(List<UPHFabric> list)
{
var result = _uPHFabricRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<UPHFabric> list)
{
var result = await _uPHFabricRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<UPHFabric> GetAllToList()
{
var result = _uPHFabricRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<UPHFabric>> AsyncGetAllToList()
{
var result = await _uPHFabricRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<UPHFabric> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _uPHFabricRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<UPHFabric>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _uPHFabricRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

