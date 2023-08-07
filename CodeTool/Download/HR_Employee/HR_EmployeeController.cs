using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_EmployeeController: BaseController
{
private readonly IHR_EmployeeRepository _hR_EmployeeRepository;
public HR_EmployeeController(IHR_EmployeeRepository hR_EmployeeRepository) : base()
{
_hR_EmployeeRepository = hR_EmployeeRepository;
}
[HttpPost]
public int Add(HR_Employee hR_Employee)
{
var result = _hR_EmployeeRepository.Add(hR_Employee);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Employee hR_Employee)
{
var result = await _hR_EmployeeRepository.AsyncAdd(hR_Employee);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Employee> list)
{
var result = _hR_EmployeeRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Employee> list)
{
var result = await _hR_EmployeeRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Employee hR_Employee)
{
var result = _hR_EmployeeRepository.Update(hR_Employee);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Employee hR_Employee)
{
var result = await _hR_EmployeeRepository.AsyncUpdate(hR_Employee);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Employee> list)
{
var result = _hR_EmployeeRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Employee> list)
{
var result = await _hR_EmployeeRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Employee> GetAllToList()
{
var result = _hR_EmployeeRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Employee>> AsyncGetAllToList()
{
var result = await _hR_EmployeeRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Employee> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_EmployeeRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Employee>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_EmployeeRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

