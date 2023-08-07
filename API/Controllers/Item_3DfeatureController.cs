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
    public class Item_3DfeatureController : BaseController
    {
        private readonly IItem_3DfeatureRepository _item_3DfeatureRepository;
        public Item_3DfeatureController(IItem_3DfeatureRepository item_3DfeatureRepository) : base()
        {
            _item_3DfeatureRepository = item_3DfeatureRepository;
        }       
        [HttpGet]
        public List<Item_3Dfeature> GetByItem_IDToList(string Item_ID)
        {
            var result = _item_3DfeatureRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(Item_3Dfeature model)
        {
            var result = _item_3DfeatureRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string Feature_ID3D)
        {
            var result = _item_3DfeatureRepository.DeleteBySQL(Item_ID, Feature_ID3D);
            return result;
        }
    }
}

