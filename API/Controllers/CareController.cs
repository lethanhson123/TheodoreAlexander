using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class CareController : BaseController
    {
        private readonly ICareRepository _careRepository;
        public CareController(ICareRepository careRepository) : base()
        {
            _careRepository = careRepository;
        }
        
        [HttpGet]
        public List<Care> GetAllToList()
        {
            var result = _careRepository.GetAllToList();
            return result;
        }
       
    }
}

