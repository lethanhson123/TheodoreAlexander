using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class ItemController: BaseController
{
private readonly IItemRepository _itemRepository;
public ItemController(IItemRepository itemRepository) : base()
{
_itemRepository = itemRepository;
}
[HttpPost]
public int Add(Item item)
{
var result = _itemRepository.Add(item);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Item item)
{
var result = await _itemRepository.AsyncAdd(item);
 return result;
}
[HttpPost]
public int AddRange(List<Item> list)
{
var result = _itemRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Item> list)
{
var result = await _itemRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Item item)
{
var result = _itemRepository.Update(item);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Item item)
{
var result = await _itemRepository.AsyncUpdate(item);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Item> list)
{
var result = _itemRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Item> list)
{
var result = await _itemRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Item> GetAllToList()
{
var result = _itemRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Item>> AsyncGetAllToList()
{
var result = await _itemRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Item> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _itemRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Item>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _itemRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

