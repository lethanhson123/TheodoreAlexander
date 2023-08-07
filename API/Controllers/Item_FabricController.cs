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
    public class Item_FabricController : BaseController
    {
        private readonly IItem_FabricRepository _item_FabricRepository;
        public Item_FabricController(IItem_FabricRepository item_FabricRepository) : base()
        {
            _item_FabricRepository = item_FabricRepository;
        }
        [HttpPost]
        public string InsertBySQL(Item_Fabric model)
        {
            string result = AppGlobal.InitializationString;
            result = _item_FabricRepository.InsertBySQL(model);
            return result;
        }
        [HttpPut]
        public string UpdateBySQL(Item_Fabric model)
        {
            string result = AppGlobal.InitializationString;
            result = _item_FabricRepository.UpdateBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string ID)
        {
            string result = AppGlobal.InitializationString;           
            result = _item_FabricRepository.DeleteBySQL(ID);
            return result;
        }
        [HttpGet]
        public List<Item_Fabric> GetByItemIDToList(string ItemID)
        {
            var result = _item_FabricRepository.GetByItemIDToList(ItemID);
            return result;
        }

    }
}

