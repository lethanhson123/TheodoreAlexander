using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_CovidTestController: BaseController
{
private readonly IHR_CovidTestRepository _hR_CovidTestRepository;
public HR_CovidTestController(IHR_CovidTestRepository hR_CovidTestRepository) : base()
{
_hR_CovidTestRepository = hR_CovidTestRepository;
}
[HttpPost]
public int Add(HR_CovidTest hR_CovidTest)
{
var result = _hR_CovidTestRepository.Add(hR_CovidTest);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_CovidTest hR_CovidTest)
{
var result = await _hR_CovidTestRepository.AsyncAdd(hR_CovidTest);
 return result;
}
[HttpPost]
public int AddRange(List<HR_CovidTest> list)
{
var result = _hR_CovidTestRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_CovidTest> list)
{
var result = await _hR_CovidTestRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_CovidTest hR_CovidTest)
{
var result = _hR_CovidTestRepository.Update(hR_CovidTest);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_CovidTest hR_CovidTest)
{
var result = await _hR_CovidTestRepository.AsyncUpdate(hR_CovidTest);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_CovidTest> list)
{
var result = _hR_CovidTestRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_CovidTest> list)
{
var result = await _hR_CovidTestRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_CovidTest> GetAllToList()
{
var result = _hR_CovidTestRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_CovidTest>> AsyncGetAllToList()
{
var result = await _hR_CovidTestRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_CovidTest> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_CovidTestRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_CovidTest>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_CovidTestRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

