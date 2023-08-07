using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class ProcessAndTechniqueController : BaseController
    {
        private readonly IProcessAndTechniqueRepository _processAndTechniqueRepository;
        public ProcessAndTechniqueController(IProcessAndTechniqueRepository processAndTechniqueRepository) : base()
        {
            _processAndTechniqueRepository = processAndTechniqueRepository;
        }
        
        [HttpGet]
        public List<ProcessAndTechnique> GetAllToList()
        {
            var result = _processAndTechniqueRepository.GetAllToList();
            return result;
        }
       
    }
}

