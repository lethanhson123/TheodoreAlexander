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
    public class Item_PriceController : BaseController
    {
        private readonly IItem_PriceRepository _item_PriceRepository;
        public Item_PriceController(IItem_PriceRepository item_PriceRepository) : base()
        {
            _item_PriceRepository = item_PriceRepository;
        }
        [HttpPut]
        public int UpdateBySQL(Item_Price model)
        {
            int result = AppGlobal.InitializationNumber;
            result = _item_PriceRepository.UpdateBySQL(model);
            return result;
        }
        [HttpGet]
        public List<TA.Data.Models.Item_Price> GetBySKUToList(string SKU)
        {
            var result = _item_PriceRepository.GetBySKUToList(SKU);
            return result;
        }
    }
}

