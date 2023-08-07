using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_DepartmentController: BaseController
{
private readonly IHR_DepartmentRepository _hR_DepartmentRepository;
public HR_DepartmentController(IHR_DepartmentRepository hR_DepartmentRepository) : base()
{
_hR_DepartmentRepository = hR_DepartmentRepository;
}
[HttpPost]
public int Add(HR_Department hR_Department)
{
var result = _hR_DepartmentRepository.Add(hR_Department);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Department hR_Department)
{
var result = await _hR_DepartmentRepository.AsyncAdd(hR_Department);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Department> list)
{
var result = _hR_DepartmentRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Department> list)
{
var result = await _hR_DepartmentRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Department hR_Department)
{
var result = _hR_DepartmentRepository.Update(hR_Department);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Department hR_Department)
{
var result = await _hR_DepartmentRepository.AsyncUpdate(hR_Department);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Department> list)
{
var result = _hR_DepartmentRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Department> list)
{
var result = await _hR_DepartmentRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Department> GetAllToList()
{
var result = _hR_DepartmentRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Department>> AsyncGetAllToList()
{
var result = await _hR_DepartmentRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Department> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_DepartmentRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Department>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_DepartmentRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

