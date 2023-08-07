using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_Recruitment_CareerController: BaseController
{
private readonly IHR_Recruitment_CareerRepository _hR_Recruitment_CareerRepository;
public HR_Recruitment_CareerController(IHR_Recruitment_CareerRepository hR_Recruitment_CareerRepository) : base()
{
_hR_Recruitment_CareerRepository = hR_Recruitment_CareerRepository;
}
[HttpPost]
public int Add(HR_Recruitment_Career hR_Recruitment_Career)
{
var result = _hR_Recruitment_CareerRepository.Add(hR_Recruitment_Career);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Recruitment_Career hR_Recruitment_Career)
{
var result = await _hR_Recruitment_CareerRepository.AsyncAdd(hR_Recruitment_Career);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Recruitment_Career> list)
{
var result = _hR_Recruitment_CareerRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Recruitment_Career> list)
{
var result = await _hR_Recruitment_CareerRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Recruitment_Career hR_Recruitment_Career)
{
var result = _hR_Recruitment_CareerRepository.Update(hR_Recruitment_Career);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Recruitment_Career hR_Recruitment_Career)
{
var result = await _hR_Recruitment_CareerRepository.AsyncUpdate(hR_Recruitment_Career);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Recruitment_Career> list)
{
var result = _hR_Recruitment_CareerRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Recruitment_Career> list)
{
var result = await _hR_Recruitment_CareerRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Recruitment_Career> GetAllToList()
{
var result = _hR_Recruitment_CareerRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Recruitment_Career>> AsyncGetAllToList()
{
var result = await _hR_Recruitment_CareerRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Recruitment_Career> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_Recruitment_CareerRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Recruitment_Career>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_Recruitment_CareerRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

