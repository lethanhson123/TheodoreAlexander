using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class ShippingStatusController: BaseController
{
private readonly IShippingStatusRepository _shippingStatusRepository;
public ShippingStatusController(IShippingStatusRepository shippingStatusRepository) : base()
{
_shippingStatusRepository = shippingStatusRepository;
}
[HttpPost]
public int Add(ShippingStatus shippingStatus)
{
var result = _shippingStatusRepository.Add(shippingStatus);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(ShippingStatus shippingStatus)
{
var result = await _shippingStatusRepository.AsyncAdd(shippingStatus);
 return result;
}
[HttpPost]
public int AddRange(List<ShippingStatus> list)
{
var result = _shippingStatusRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<ShippingStatus> list)
{
var result = await _shippingStatusRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(ShippingStatus shippingStatus)
{
var result = _shippingStatusRepository.Update(shippingStatus);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(ShippingStatus shippingStatus)
{
var result = await _shippingStatusRepository.AsyncUpdate(shippingStatus);
 return result;
}
[HttpDelete]
public int RemoveRange(List<ShippingStatus> list)
{
var result = _shippingStatusRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<ShippingStatus> list)
{
var result = await _shippingStatusRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<ShippingStatus> GetAllToList()
{
var result = _shippingStatusRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<ShippingStatus>> AsyncGetAllToList()
{
var result = await _shippingStatusRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<ShippingStatus> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _shippingStatusRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<ShippingStatus>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _shippingStatusRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

