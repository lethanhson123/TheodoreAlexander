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
    public class SKUListingForSizeAvailabilityController : BaseController
    {
        private readonly ISKUListingForSizeAvailabilityRepository _sKUListingForSizeAvailabilityRepository;
        public SKUListingForSizeAvailabilityController(ISKUListingForSizeAvailabilityRepository sKUListingForSizeAvailabilityRepository) : base()
        {
            _sKUListingForSizeAvailabilityRepository = sKUListingForSizeAvailabilityRepository;
        }
        [HttpGet]
        public List<SKUListingForSizeAvailability> GetByItem_IDToList(Guid Item_ID)
        {
            var result = _sKUListingForSizeAvailabilityRepository.GetByItem_IDToList(Item_ID);
            return result;
        }
        [HttpPost]
        public string InsertBySQL(SKUListingForSizeAvailability model)
        {
            string result = AppGlobal.InitializationString;
            result = _sKUListingForSizeAvailabilityRepository.InsertBySQL(model);
            return result;
        }
        [HttpGet]
        public string DeleteBySQL(string ID)
        {
            string result = AppGlobal.InitializationString;            
            result = _sKUListingForSizeAvailabilityRepository.DeleteBySQL(ID);
            return result;
        }
    }
}

