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
    public class RelatedItemController : BaseController
    {
        private readonly IRelatedItemRepository _relatedItemRepository;
        public RelatedItemController(IRelatedItemRepository relatedItemRepository) : base()
        {
            _relatedItemRepository = relatedItemRepository;
        }
        [HttpGet]
        public List<RelatedItem> GetByItem_IDToList(Guid Item_ID)
        {
            var result = _relatedItemRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(RelatedItem model)
        {
            string result = AppGlobal.InitializationString;
            result = _relatedItemRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string RelatedItem_ID)
        {
            string result = AppGlobal.InitializationString;
            RelatedItem model = new RelatedItem();
            model.Item_ID = Guid.Parse(Item_ID);
            model.RelatedItem_ID = Guid.Parse(RelatedItem_ID);
            result = _relatedItemRepository.DeleteBySQL(model);
            return result;
        }
    }
}

