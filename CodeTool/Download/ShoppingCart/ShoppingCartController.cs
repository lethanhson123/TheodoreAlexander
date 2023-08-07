using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class ShoppingCartController: BaseController
{
private readonly IShoppingCartRepository _shoppingCartRepository;
public ShoppingCartController(IShoppingCartRepository shoppingCartRepository) : base()
{
_shoppingCartRepository = shoppingCartRepository;
}
[HttpPost]
public int Add(ShoppingCart shoppingCart)
{
var result = _shoppingCartRepository.Add(shoppingCart);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(ShoppingCart shoppingCart)
{
var result = await _shoppingCartRepository.AsyncAdd(shoppingCart);
 return result;
}
[HttpPost]
public int AddRange(List<ShoppingCart> list)
{
var result = _shoppingCartRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<ShoppingCart> list)
{
var result = await _shoppingCartRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(ShoppingCart shoppingCart)
{
var result = _shoppingCartRepository.Update(shoppingCart);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(ShoppingCart shoppingCart)
{
var result = await _shoppingCartRepository.AsyncUpdate(shoppingCart);
 return result;
}
[HttpDelete]
public int RemoveRange(List<ShoppingCart> list)
{
var result = _shoppingCartRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<ShoppingCart> list)
{
var result = await _shoppingCartRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<ShoppingCart> GetAllToList()
{
var result = _shoppingCartRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<ShoppingCart>> AsyncGetAllToList()
{
var result = await _shoppingCartRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<ShoppingCart> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _shoppingCartRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<ShoppingCart>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _shoppingCartRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

