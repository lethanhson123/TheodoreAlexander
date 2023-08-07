using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class HistoricalStyleController : BaseController
    {
        private readonly IHistoricalStyleRepository _historicalStyleRepository;
        public HistoricalStyleController(IHistoricalStyleRepository historicalStyleRepository) : base()
        {
            _historicalStyleRepository = historicalStyleRepository;
        }
        
        [HttpGet]
        public List<HistoricalStyle> GetAllToList()
        {
            var result = _historicalStyleRepository.GetAllToList();
            return result;
        }
       
    }
}

