using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class UPHColourController : BaseController
    {
        private readonly IUPHColourRepository _uPHColourRepository;
        public UPHColourController(IUPHColourRepository uPHColourRepository) : base()
        {
            _uPHColourRepository = uPHColourRepository;
        }
        [HttpPut]
        public int Update(UPHColour uPHColour)
        {
            var result = _uPHColourRepository.Update(uPHColour);
            return result;
        }
        [HttpGet]
        public List<UPHColour> GetAllToList()
        {
            var result = _uPHColourRepository.GetAllToList();
            return result;
        }
    }
}

