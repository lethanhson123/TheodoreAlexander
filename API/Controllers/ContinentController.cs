using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class ContinentController : BaseController
    {
        private readonly IContinentRepository _continentRepository;
        public ContinentController(IContinentRepository continentRepository) : base()
        {
            _continentRepository = continentRepository;
        }       
        [HttpGet]
        public List<Continent> GetAllToList()
        {
            var result = _continentRepository.GetAllToList();
            return result;
        }        
    }
}

