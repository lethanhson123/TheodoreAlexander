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
    public class Item_StatusController : BaseController
    {
        private readonly IItem_StatusRepository _item_StatusRepository;
        public Item_StatusController(IItem_StatusRepository item_StatusRepository) : base()
        {
            _item_StatusRepository = item_StatusRepository;
        }
        [HttpPut]
        public int UpdateBySQL(Item_Status model)
        {
            int result = AppGlobal.InitializationNumber;
            result = _item_StatusRepository.UpdateBySQL(model);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Item_Status> GetBySKUToList(string SKU)
        {
            var result = _item_StatusRepository.GetBySKUToList(SKU);
            return result;
        }
    }
}

