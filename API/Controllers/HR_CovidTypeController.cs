using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_CovidTypeController: BaseController
{
private readonly IHR_CovidTypeRepository _hR_CovidTypeRepository;
public HR_CovidTypeController(IHR_CovidTypeRepository hR_CovidTypeRepository) : base()
{
_hR_CovidTypeRepository = hR_CovidTypeRepository;
}
[HttpPost]
public int Add(HR_CovidType hR_CovidType)
{
var result = _hR_CovidTypeRepository.Add(hR_CovidType);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_CovidType hR_CovidType)
{
var result = await _hR_CovidTypeRepository.AsyncAdd(hR_CovidType);
 return result;
}
[HttpPost]
public int AddRange(List<HR_CovidType> list)
{
var result = _hR_CovidTypeRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_CovidType> list)
{
var result = await _hR_CovidTypeRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_CovidType hR_CovidType)
{
var result = _hR_CovidTypeRepository.Update(hR_CovidType);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_CovidType hR_CovidType)
{
var result = await _hR_CovidTypeRepository.AsyncUpdate(hR_CovidType);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_CovidType> list)
{
var result = _hR_CovidTypeRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_CovidType> list)
{
var result = await _hR_CovidTypeRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_CovidType> GetAllToList()
{
var result = _hR_CovidTypeRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_CovidType>> AsyncGetAllToList()
{
var result = await _hR_CovidTypeRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_CovidType> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_CovidTypeRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_CovidType>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_CovidTypeRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

