using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class CenturyController : BaseController
    {
        private readonly ICenturyRepository _centuryRepository;
        public CenturyController(ICenturyRepository centuryRepository) : base()
        {
            _centuryRepository = centuryRepository;
        }
        
        [HttpGet]
        public List<Century> GetAllToList()
        {
            var result = _centuryRepository.GetAllToList();
            return result;
        }
       
    }
}

