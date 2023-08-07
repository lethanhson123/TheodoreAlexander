using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
public class ShapeController: BaseController
{
private readonly IShapeRepository _shapeRepository;
public ShapeController(IShapeRepository shapeRepository) : base()
{
_shapeRepository = shapeRepository;
}
[HttpPost]
public int Add(Shape shape)
{
var result = _shapeRepository.Add(shape);
 return result;
}
[HttpPost]
public async Task<int> AsyncAdd(Shape shape)
{
var result = await _shapeRepository.AsyncAdd(shape);
 return result;
}
[HttpPost]
public int AddRange(List<Shape> list)
{
var result = _shapeRepository.AddRange(list);
 return result;
}
[HttpPost]
public async Task<int> AsyncAddRange(List<Shape> list)
{
var result = await _shapeRepository.AsyncAddRange(list);
 return result;
}
[HttpPut]
public int Update(Shape shape)
{
var result = _shapeRepository.Update(shape);
 return result;
}
[HttpPut]
public async Task<int> AsyncUpdate(Shape shape)
{
var result = await _shapeRepository.AsyncUpdate(shape);
 return result;
}
[HttpDelete]
public int RemoveRange(List<Shape> list)
{
var result = _shapeRepository.RemoveRange(list);
 return result;
}
[HttpDelete]
public async Task<int> AsyncRemoveRange(List<Shape> list)
{
var result = await _shapeRepository.AsyncRemoveRange(list);
 return result;
}
[HttpGet]
public List<Shape> GetAllToList()
{
var result = _shapeRepository.GetAllToList();
 return result;
}
[HttpGet]
public async Task<List<Shape>> AsyncGetAllToList()
{
var result = await _shapeRepository.AsyncGetAllToList();
 return result;
}
[HttpGet]
public List<Shape> GetByPageAndPageSizeToList(int page, int pageSize)
{
var result = _shapeRepository.GetByPageAndPageSizeToList(page,pageSize);
 return result;
}
[HttpGet]
public async Task<List<Shape>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
{
var result = await _shapeRepository.AsyncGetByPageAndPageSizeToList(page,pageSize);
 return result;
}
}
}

