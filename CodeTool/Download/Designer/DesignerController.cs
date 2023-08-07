using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class DesignerController: BaseController
{
private readonly IDesignerRepository _designerRepository;
public DesignerController(IDesignerRepository designerRepository) : base()
{
_designerRepository = designerRepository;
}
[HttpPost]
public int Add(Designer designer)
{
var result = _designerRepository.Add(designer);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Designer designer)
{
var result = await _designerRepository.AsyncAdd(designer);
 return result;
}
[HttpPost]
public int AddRange(List<Designer> list)
{
var result = _designerRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Designer> list)
{
var result = await _designerRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Designer designer)
{
var result = _designerRepository.Update(designer);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Designer designer)
{
var result = await _designerRepository.AsyncUpdate(designer);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Designer> list)
{
var result = _designerRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Designer> list)
{
var result = await _designerRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Designer> GetAllToList()
{
var result = _designerRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Designer>> AsyncGetAllToList()
{
var result = await _designerRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Designer> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _designerRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Designer>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _designerRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

