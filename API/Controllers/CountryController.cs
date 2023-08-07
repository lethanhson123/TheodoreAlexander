using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class CountryController : BaseController
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository) : base()
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        public List<Country> GetAllToList()
        {
            var result = _countryRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public List<Country> GetBySearchStringToList(string searchString)
        {
            var result = _countryRepository.GetBySearchStringToList(searchString);
            return result;
        }        
    }
}

