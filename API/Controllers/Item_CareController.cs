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
    public class Item_CareController : BaseController
    {
        private readonly IItem_CareRepository _item_CareRepository;
        public Item_CareController(IItem_CareRepository item_CareRepository) : base()
        {
            _item_CareRepository = item_CareRepository;
        }       
        [HttpGet]
        public List<Item_Care> GetByItem_IDToList(string Item_ID)
        {
            var result = _item_CareRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(Item_Care model)
        {
            var result = _item_CareRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string Care_ID)
        {
            var result = _item_CareRepository.DeleteBySQL(Item_ID, Care_ID);
            return result;
        }
    }
}

