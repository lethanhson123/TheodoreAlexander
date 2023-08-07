using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class RegionController : BaseController
    {
        private readonly IRegionRepository _regionRepository;
        public RegionController(IRegionRepository regionRepository) : base()
        {
            _regionRepository = regionRepository;
        }
        [HttpGet]
        public List<Region> GetByCountryIDToList(string countryID)
        {
            var result = _regionRepository.GetByCountryIDToList(Guid.Parse(countryID));
            return result;
        }
        [HttpGet]
        public List<Region> GetByCountryIDOrSearchStringToList(string countryID, string searchString)
        {
            var result = _regionRepository.GetByCountryIDOrSearchStringToList(countryID, searchString);
            return result;
        }
    }
}

