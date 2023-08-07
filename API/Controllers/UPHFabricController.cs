using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class UPHFabricController : BaseController
    {
        private readonly IUPHFabricRepository _uPHFabricRepository;
        public UPHFabricController(IUPHFabricRepository uPHFabricRepository) : base()
        {
            _uPHFabricRepository = uPHFabricRepository;
        }
        [HttpGet]
        public List<UPHFabric> GetByIsFabricAndIsLeatherAndIsTrimsAndSearchStringToList(bool isFabric, bool isLeather, bool isTrims, string searchString)
        {
            var result = _uPHFabricRepository.GetByIsFabricAndIsLeatherAndIsTrimsAndSearchStringToList(isFabric, isLeather, isTrims, searchString);
            return result;
        }
    }
}

