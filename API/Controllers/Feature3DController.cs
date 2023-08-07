using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class Feature3DController : BaseController
    {
        private readonly IFeature3DRepository _Feature3DRepository;
        public Feature3DController(IFeature3DRepository Feature3DRepository) : base()
        {
            _Feature3DRepository = Feature3DRepository;
        }
        
        [HttpGet]
        public List<Feature3D> GetAllToList()
        {
            var result = _Feature3DRepository.GetAllToList();
            return result;
        }
       
    }
}

