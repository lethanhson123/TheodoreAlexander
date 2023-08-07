using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class Feature2DController : BaseController
    {
        private readonly IFeature2DRepository _feature2DRepository;
        public Feature2DController(IFeature2DRepository feature2DRepository) : base()
        {
            _feature2DRepository = feature2DRepository;
        }
        
        [HttpGet]
        public List<Feature2D> GetAllToList()
        {
            var result = _feature2DRepository.GetAllToList();
            return result;
        }
       
    }
}

