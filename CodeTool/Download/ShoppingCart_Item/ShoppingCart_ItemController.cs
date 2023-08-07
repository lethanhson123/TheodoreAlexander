using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class ShoppingCart_ItemController: BaseController
{
private readonly IShoppingCart_ItemRepository _shoppingCart_ItemRepository;
public ShoppingCart_ItemController(IShoppingCart_ItemRepository shoppingCart_ItemRepository) : base()
{
_shoppingCart_ItemRepository = shoppingCart_ItemRepository;
}
[HttpPost]
public int Add(ShoppingCart_Item shoppingCart_Item)
{
var result = _shoppingCart_ItemRepository.Add(shoppingCart_Item);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(ShoppingCart_Item shoppingCart_Item)
{
var result = await _shoppingCart_ItemRepository.AsyncAdd(shoppingCart_Item);
 return result;
}
[HttpPost]
public int AddRange(List<ShoppingCart_Item> list)
{
var result = _shoppingCart_ItemRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<ShoppingCart_Item> list)
{
var result = await _shoppingCart_ItemRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(ShoppingCart_Item shoppingCart_Item)
{
var result = _shoppingCart_ItemRepository.Update(shoppingCart_Item);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(ShoppingCart_Item shoppingCart_Item)
{
var result = await _shoppingCart_ItemRepository.AsyncUpdate(shoppingCart_Item);
 return result;
}
[HttpDelete]
public int RemoveRange(List<ShoppingCart_Item> list)
{
var result = _shoppingCart_ItemRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<ShoppingCart_Item> list)
{
var result = await _shoppingCart_ItemRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<ShoppingCart_Item> GetAllToList()
{
var result = _shoppingCart_ItemRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<ShoppingCart_Item>> AsyncGetAllToList()
{
var result = await _shoppingCart_ItemRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<ShoppingCart_Item> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _shoppingCart_ItemRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<ShoppingCart_Item>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _shoppingCart_ItemRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

