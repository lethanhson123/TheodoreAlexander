using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_BlockNameController: BaseController
{
private readonly IHR_BlockNameRepository _hR_BlockNameRepository;
public HR_BlockNameController(IHR_BlockNameRepository hR_BlockNameRepository) : base()
{
_hR_BlockNameRepository = hR_BlockNameRepository;
}
[HttpPost]
public int Add(HR_BlockName hR_BlockName)
{
var result = _hR_BlockNameRepository.Add(hR_BlockName);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_BlockName hR_BlockName)
{
var result = await _hR_BlockNameRepository.AsyncAdd(hR_BlockName);
 return result;
}
[HttpPost]
public int AddRange(List<HR_BlockName> list)
{
var result = _hR_BlockNameRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_BlockName> list)
{
var result = await _hR_BlockNameRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_BlockName hR_BlockName)
{
var result = _hR_BlockNameRepository.Update(hR_BlockName);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_BlockName hR_BlockName)
{
var result = await _hR_BlockNameRepository.AsyncUpdate(hR_BlockName);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_BlockName> list)
{
var result = _hR_BlockNameRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_BlockName> list)
{
var result = await _hR_BlockNameRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_BlockName> GetAllToList()
{
var result = _hR_BlockNameRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_BlockName>> AsyncGetAllToList()
{
var result = await _hR_BlockNameRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_BlockName> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_BlockNameRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_BlockName>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_BlockNameRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

