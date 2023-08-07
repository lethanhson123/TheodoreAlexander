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
    public class RelatedSkuForSpecialGroupController : BaseController
    {
        private readonly IRelatedSkuForSpecialGroupRepository _relatedSkuForSpecialGroupRepository;
        public RelatedSkuForSpecialGroupController(IRelatedSkuForSpecialGroupRepository relatedSkuForSpecialGroupRepository) : base()
        {
            _relatedSkuForSpecialGroupRepository = relatedSkuForSpecialGroupRepository;
        }
        [HttpGet]
        public List<RelatedSkuForSpecialGroup> GetByItem_IDToList(Guid Item_ID)
        {
            var result = _relatedSkuForSpecialGroupRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(RelatedSkuForSpecialGroup model)
        {
            string result = AppGlobal.InitializationString;
            result = _relatedSkuForSpecialGroupRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string Item_ID, string SKU)
        {
            string result = AppGlobal.InitializationString;
            RelatedSkuForSpecialGroup model = new RelatedSkuForSpecialGroup();
            model.Item_ID = Guid.Parse(Item_ID);
            model.SKU = SKU;
            result = _relatedSkuForSpecialGroupRepository.DeleteBySQL(model);
            return result;
        }
    }
}

