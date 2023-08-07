using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class CollectionController: BaseController
{
private readonly ICollectionRepository _collectionRepository;
public CollectionController(ICollectionRepository collectionRepository) : base()
{
_collectionRepository = collectionRepository;
}
[HttpPost]
public int Add(Collection collection)
{
var result = _collectionRepository.Add(collection);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Collection collection)
{
var result = await _collectionRepository.AsyncAdd(collection);
 return result;
}
[HttpPost]
public int AddRange(List<Collection> list)
{
var result = _collectionRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Collection> list)
{
var result = await _collectionRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Collection collection)
{
var result = _collectionRepository.Update(collection);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Collection collection)
{
var result = await _collectionRepository.AsyncUpdate(collection);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Collection> list)
{
var result = _collectionRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Collection> list)
{
var result = await _collectionRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Collection> GetAllToList()
{
var result = _collectionRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Collection>> AsyncGetAllToList()
{
var result = await _collectionRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Collection> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _collectionRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Collection>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _collectionRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

