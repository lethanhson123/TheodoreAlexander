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
    public class Item_2DfeatureController : BaseController
    {
        private readonly IItem_2DfeatureRepository _item_2DfeatureRepository;
        public Item_2DfeatureController(IItem_2DfeatureRepository item_2DfeatureRepository) : base()
        {
            _item_2DfeatureRepository = item_2DfeatureRepository;
        }       
        [HttpGet]
        public List<Item_2Dfeature> GetByItem_IDToList(string Item_ID)
        {
            var result = _item_2DfeatureRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(Item_2Dfeature model)
        {
            var result = _item_2DfeatureRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string Feature_ID2D)
        {
            var result = _item_2DfeatureRepository.DeleteBySQL(Item_ID, Feature_ID2D);
            return result;
        }
    }
}

