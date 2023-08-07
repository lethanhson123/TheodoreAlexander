using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_DivisionController: BaseController
{
private readonly IHR_DivisionRepository _hR_DivisionRepository;
public HR_DivisionController(IHR_DivisionRepository hR_DivisionRepository) : base()
{
_hR_DivisionRepository = hR_DivisionRepository;
}
[HttpPost]
public int Add(HR_Division hR_Division)
{
var result = _hR_DivisionRepository.Add(hR_Division);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Division hR_Division)
{
var result = await _hR_DivisionRepository.AsyncAdd(hR_Division);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Division> list)
{
var result = _hR_DivisionRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Division> list)
{
var result = await _hR_DivisionRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Division hR_Division)
{
var result = _hR_DivisionRepository.Update(hR_Division);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Division hR_Division)
{
var result = await _hR_DivisionRepository.AsyncUpdate(hR_Division);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Division> list)
{
var result = _hR_DivisionRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Division> list)
{
var result = await _hR_DivisionRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Division> GetAllToList()
{
var result = _hR_DivisionRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Division>> AsyncGetAllToList()
{
var result = await _hR_DivisionRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Division> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_DivisionRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Division>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_DivisionRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

