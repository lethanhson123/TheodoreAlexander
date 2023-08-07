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
    public class Item_ProcessAndTechniqueController : BaseController
    {
        private readonly IItem_ProcessAndTechniqueRepository _item_ProcessAndTechniqueRepository;
        public Item_ProcessAndTechniqueController(IItem_ProcessAndTechniqueRepository item_ProcessAndTechniqueRepository) : base()
        {
            _item_ProcessAndTechniqueRepository = item_ProcessAndTechniqueRepository;
        }       
        [HttpGet]
        public List<Item_ProcessAndTechnique> GetByItem_IDToList(string Item_ID)
        {
            var result = _item_ProcessAndTechniqueRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(Item_ProcessAndTechnique model)
        {
            var result = _item_ProcessAndTechniqueRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string ProcessAndTechnique_ID)
        {
            var result = _item_ProcessAndTechniqueRepository.DeleteBySQL(Item_ID, ProcessAndTechnique_ID);
            return result;
        }
    }
}

