using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class RoomAndUsageController: BaseController
{
private readonly IRoomAndUsageRepository _roomAndUsageRepository;
public RoomAndUsageController(IRoomAndUsageRepository roomAndUsageRepository) : base()
{
_roomAndUsageRepository = roomAndUsageRepository;
}
[HttpPost]
public int Add(RoomAndUsage roomAndUsage)
{
var result = _roomAndUsageRepository.Add(roomAndUsage);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(RoomAndUsage roomAndUsage)
{
var result = await _roomAndUsageRepository.AsyncAdd(roomAndUsage);
 return result;
}
[HttpPost]
public int AddRange(List<RoomAndUsage> list)
{
var result = _roomAndUsageRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<RoomAndUsage> list)
{
var result = await _roomAndUsageRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(RoomAndUsage roomAndUsage)
{
var result = _roomAndUsageRepository.Update(roomAndUsage);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(RoomAndUsage roomAndUsage)
{
var result = await _roomAndUsageRepository.AsyncUpdate(roomAndUsage);
 return result;
}
[HttpDelete]
public int RemoveRange(List<RoomAndUsage> list)
{
var result = _roomAndUsageRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<RoomAndUsage> list)
{
var result = await _roomAndUsageRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<RoomAndUsage> GetAllToList()
{
var result = _roomAndUsageRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<RoomAndUsage>> AsyncGetAllToList()
{
var result = await _roomAndUsageRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<RoomAndUsage> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _roomAndUsageRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<RoomAndUsage>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _roomAndUsageRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

