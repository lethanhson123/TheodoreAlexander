using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_CovidController: BaseController
{
private readonly IHR_CovidRepository _hR_CovidRepository;
public HR_CovidController(IHR_CovidRepository hR_CovidRepository) : base()
{
_hR_CovidRepository = hR_CovidRepository;
}
[HttpPost]
public int Add(HR_Covid hR_Covid)
{
var result = _hR_CovidRepository.Add(hR_Covid);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Covid hR_Covid)
{
var result = await _hR_CovidRepository.AsyncAdd(hR_Covid);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Covid> list)
{
var result = _hR_CovidRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Covid> list)
{
var result = await _hR_CovidRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Covid hR_Covid)
{
var result = _hR_CovidRepository.Update(hR_Covid);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Covid hR_Covid)
{
var result = await _hR_CovidRepository.AsyncUpdate(hR_Covid);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Covid> list)
{
var result = _hR_CovidRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Covid> list)
{
var result = await _hR_CovidRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Covid> GetAllToList()
{
var result = _hR_CovidRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Covid>> AsyncGetAllToList()
{
var result = await _hR_CovidRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Covid> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_CovidRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Covid>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_CovidRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

