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
    public class Item_CenturyController : BaseController
    {
        private readonly IItem_CenturyRepository _item_CenturyRepository;
        public Item_CenturyController(IItem_CenturyRepository item_CenturyRepository) : base()
        {
            _item_CenturyRepository = item_CenturyRepository;
        }       
        [HttpGet]
        public List<Item_Century> GetByItem_IDToList(string Item_ID)
        {
            var result = _item_CenturyRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(Item_Century model)
        {
            var result = _item_CenturyRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string Century_ID)
        {
            var result = _item_CenturyRepository.DeleteBySQL(Item_ID, Century_ID);
            return result;
        }
    }
}

