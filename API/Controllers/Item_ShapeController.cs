using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class Item_ShapeController : BaseController
    {
        private readonly IItem_ShapeRepository _item_ShapeRepository;
        public Item_ShapeController(IItem_ShapeRepository item_ShapeRepository) : base()
        {
            _item_ShapeRepository = item_ShapeRepository;
        }       
        [HttpGet]
        public List<Item_Shape> GetByItem_IDToList(string Item_ID)
        {
            var result = _item_ShapeRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(Item_Shape item_Shape)
        {            
            var result = _item_ShapeRepository.InsertBySQL(item_Shape);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string Shape_ID)
        {
            var result = _item_ShapeRepository.DeleteBySQL(Item_ID, Shape_ID);
            return result;
        }
    }
}

