using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class ColourAndFinishController : BaseController
    {
        private readonly IColourAndFinishRepository _colourAndFinishRepository;
        public ColourAndFinishController(IColourAndFinishRepository colourAndFinishRepository) : base()
        {
            _colourAndFinishRepository = colourAndFinishRepository;
        }
        
        [HttpGet]
        public List<ColourAndFinish> GetAllToList()
        {
            var result = _colourAndFinishRepository.GetAllToList();
            return result;
        }
       
    }
}

