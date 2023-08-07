using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class ShoppingCart_Item_ShippingStatusController: BaseController
{
private readonly IShoppingCart_Item_ShippingStatusRepository _shoppingCart_Item_ShippingStatusRepository;
public ShoppingCart_Item_ShippingStatusController(IShoppingCart_Item_ShippingStatusRepository shoppingCart_Item_ShippingStatusRepository) : base()
{
_shoppingCart_Item_ShippingStatusRepository = shoppingCart_Item_ShippingStatusRepository;
}
[HttpPost]
public int Add(ShoppingCart_Item_ShippingStatus shoppingCart_Item_ShippingStatus)
{
var result = _shoppingCart_Item_ShippingStatusRepository.Add(shoppingCart_Item_ShippingStatus);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(ShoppingCart_Item_ShippingStatus shoppingCart_Item_ShippingStatus)
{
var result = await _shoppingCart_Item_ShippingStatusRepository.AsyncAdd(shoppingCart_Item_ShippingStatus);
 return result;
}
[HttpPost]
public int AddRange(List<ShoppingCart_Item_ShippingStatus> list)
{
var result = _shoppingCart_Item_ShippingStatusRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<ShoppingCart_Item_ShippingStatus> list)
{
var result = await _shoppingCart_Item_ShippingStatusRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(ShoppingCart_Item_ShippingStatus shoppingCart_Item_ShippingStatus)
{
var result = _shoppingCart_Item_ShippingStatusRepository.Update(shoppingCart_Item_ShippingStatus);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(ShoppingCart_Item_ShippingStatus shoppingCart_Item_ShippingStatus)
{
var result = await _shoppingCart_Item_ShippingStatusRepository.AsyncUpdate(shoppingCart_Item_ShippingStatus);
 return result;
}
[HttpDelete]
public int RemoveRange(List<ShoppingCart_Item_ShippingStatus> list)
{
var result = _shoppingCart_Item_ShippingStatusRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<ShoppingCart_Item_ShippingStatus> list)
{
var result = await _shoppingCart_Item_ShippingStatusRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<ShoppingCart_Item_ShippingStatus> GetAllToList()
{
var result = _shoppingCart_Item_ShippingStatusRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<ShoppingCart_Item_ShippingStatus>> AsyncGetAllToList()
{
var result = await _shoppingCart_Item_ShippingStatusRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<ShoppingCart_Item_ShippingStatus> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _shoppingCart_Item_ShippingStatusRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<ShoppingCart_Item_ShippingStatus>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _shoppingCart_Item_ShippingStatusRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

