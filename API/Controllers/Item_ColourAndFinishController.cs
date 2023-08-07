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
    public class Item_ColourAndFinishController : BaseController
    {
        private readonly IItem_ColourAndFinishRepository _item_ColourAndFinishRepository;
        public Item_ColourAndFinishController(IItem_ColourAndFinishRepository item_ColourAndFinishRepository) : base()
        {
            _item_ColourAndFinishRepository = item_ColourAndFinishRepository;
        }       
        [HttpGet]
        public List<Item_ColourAndFinish> GetByItem_IDToList(string Item_ID)
        {
            var result = _item_ColourAndFinishRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(Item_ColourAndFinish model)
        {
            var result = _item_ColourAndFinishRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string ColourAndFinish_ID)
        {
            var result = _item_ColourAndFinishRepository.DeleteBySQL(Item_ID, ColourAndFinish_ID);
            return result;
        }
    }
}

