using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_StatusController: BaseController
{
private readonly IHR_StatusRepository _hR_StatusRepository;
public HR_StatusController(IHR_StatusRepository hR_StatusRepository) : base()
{
_hR_StatusRepository = hR_StatusRepository;
}
[HttpPost]
public int Add(HR_Status hR_Status)
{
var result = _hR_StatusRepository.Add(hR_Status);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Status hR_Status)
{
var result = await _hR_StatusRepository.AsyncAdd(hR_Status);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Status> list)
{
var result = _hR_StatusRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Status> list)
{
var result = await _hR_StatusRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Status hR_Status)
{
var result = _hR_StatusRepository.Update(hR_Status);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Status hR_Status)
{
var result = await _hR_StatusRepository.AsyncUpdate(hR_Status);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Status> list)
{
var result = _hR_StatusRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Status> list)
{
var result = await _hR_StatusRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Status> GetAllToList()
{
var result = _hR_StatusRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Status>> AsyncGetAllToList()
{
var result = await _hR_StatusRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Status> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_StatusRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Status>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_StatusRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

