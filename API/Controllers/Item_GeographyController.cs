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
    public class Item_GeographyController : BaseController
    {
        private readonly IItem_GeographyRepository _item_GeographyRepository;
        public Item_GeographyController(IItem_GeographyRepository item_GeographyRepository) : base()
        {
            _item_GeographyRepository = item_GeographyRepository;
        }       
        [HttpGet]
        public List<Item_Geography> GetByItem_IDToList(string Item_ID)
        {
            var result = _item_GeographyRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(Item_Geography model)
        {
            var result = _item_GeographyRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string Geography_ID)
        {
            var result = _item_GeographyRepository.DeleteBySQL(Item_ID, Geography_ID);
            return result;
        }
    }
}

