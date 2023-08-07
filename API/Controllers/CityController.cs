using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class CityController : BaseController
    {
        private readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository) : base()
        {
            _cityRepository = cityRepository;
        }
        [HttpGet]
        public List<City> GetByRegionIDOrSearchStringToList(string regionID, string searchString)
        {
            var result = _cityRepository.GetByRegionIDOrSearchStringToList(regionID, searchString);
            return result;
        }
    }
}

