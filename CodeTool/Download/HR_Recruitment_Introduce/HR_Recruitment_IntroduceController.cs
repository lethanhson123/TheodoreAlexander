using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class HR_Recruitment_IntroduceController: BaseController
{
private readonly IHR_Recruitment_IntroduceRepository _hR_Recruitment_IntroduceRepository;
public HR_Recruitment_IntroduceController(IHR_Recruitment_IntroduceRepository hR_Recruitment_IntroduceRepository) : base()
{
_hR_Recruitment_IntroduceRepository = hR_Recruitment_IntroduceRepository;
}
[HttpPost]
public int Add(HR_Recruitment_Introduce hR_Recruitment_Introduce)
{
var result = _hR_Recruitment_IntroduceRepository.Add(hR_Recruitment_Introduce);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(HR_Recruitment_Introduce hR_Recruitment_Introduce)
{
var result = await _hR_Recruitment_IntroduceRepository.AsyncAdd(hR_Recruitment_Introduce);
 return result;
}
[HttpPost]
public int AddRange(List<HR_Recruitment_Introduce> list)
{
var result = _hR_Recruitment_IntroduceRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<HR_Recruitment_Introduce> list)
{
var result = await _hR_Recruitment_IntroduceRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(HR_Recruitment_Introduce hR_Recruitment_Introduce)
{
var result = _hR_Recruitment_IntroduceRepository.Update(hR_Recruitment_Introduce);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(HR_Recruitment_Introduce hR_Recruitment_Introduce)
{
var result = await _hR_Recruitment_IntroduceRepository.AsyncUpdate(hR_Recruitment_Introduce);
 return result;
}
[HttpDelete]
public int RemoveRange(List<HR_Recruitment_Introduce> list)
{
var result = _hR_Recruitment_IntroduceRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<HR_Recruitment_Introduce> list)
{
var result = await _hR_Recruitment_IntroduceRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<HR_Recruitment_Introduce> GetAllToList()
{
var result = _hR_Recruitment_IntroduceRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<HR_Recruitment_Introduce>> AsyncGetAllToList()
{
var result = await _hR_Recruitment_IntroduceRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<HR_Recruitment_Introduce> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _hR_Recruitment_IntroduceRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<HR_Recruitment_Introduce>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _hR_Recruitment_IntroduceRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

