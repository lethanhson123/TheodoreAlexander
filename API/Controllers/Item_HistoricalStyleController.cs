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
    public class Item_HistoricalStyleController : BaseController
    {
        private readonly IItem_HistoricalStyleRepository _item_HistoricalStyleRepository;
        public Item_HistoricalStyleController(IItem_HistoricalStyleRepository item_HistoricalStyleRepository) : base()
        {
            _item_HistoricalStyleRepository = item_HistoricalStyleRepository;
        }       
        [HttpGet]
        public List<Item_HistoricalStyle> GetByItem_IDToList(string Item_ID)
        {
            var result = _item_HistoricalStyleRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(Item_HistoricalStyle model)
        {
            var result = _item_HistoricalStyleRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string HistoricalStyle_ID)
        {
            var result = _item_HistoricalStyleRepository.DeleteBySQL(Item_ID, HistoricalStyle_ID);
            return result;
        }
    }
}

