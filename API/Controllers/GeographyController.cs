using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class GeographyController : BaseController
    {
        private readonly IGeographyRepository _geographyRepository;
        public GeographyController(IGeographyRepository geographyRepository) : base()
        {
            _geographyRepository = geographyRepository;
        }
        
        [HttpGet]
        public List<Geography> GetAllToList()
        {
            var result = _geographyRepository.GetAllToList();
            return result;
        }
       
    }
}

