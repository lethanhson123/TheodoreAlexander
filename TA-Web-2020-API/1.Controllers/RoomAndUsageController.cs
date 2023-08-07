using BL.CustomExceptions;
using DAL.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using TA_Web_2020_API.Helper;
using BL.DTO;
using BL.BUServices;
using System.Web.Script.Serialization;
using TA.Data2021.Repositories;
using System.Collections.Generic;
using TA.Helpers2021;
using Newtonsoft.Json;
using System.IO;

namespace TA_Web_2020_API.Controllers
{
    [RoutePrefix("api/RoomAndUsage")]
    public class RoomAndUsageController : TABaseAPIController
    {
        private readonly IRoomAndUsageRepository _roomAndUsageRepository;
        public RoomAndUsageController(IRoomAndUsageRepository roomAndUsageRepository) : base()
        {
            _roomAndUsageRepository = roomAndUsageRepository;
        }
        [HttpGet]
        public IHttpActionResult GetByID(string ID)
        {
            TA.Data2021.Models.RoomAndUsage item = _roomAndUsageRepository.GetByID(ID);          
            return new GenerateResponeHelper<TA.Data2021.Models.RoomAndUsage>(item, true, Request, HttpStatusCode.OK);
        }
        [HttpGet]
        public IHttpActionResult GetByURLCode(string URLCode)
        {
            TA.Data2021.Models.RoomAndUsage item = _roomAndUsageRepository.GetByURLCode(URLCode);            
            return new GenerateResponeHelper<TA.Data2021.Models.RoomAndUsage>(item, true, Request, HttpStatusCode.OK);
        }
        [HttpGet]
        public IHttpActionResult GetByIsActiveAndRegionToList(bool isActive, string region)
        {            
            List<TA.Data2021.Models.RoomAndUsage> list = _roomAndUsageRepository.GetByIsActiveAndIsActiveTAUSToList(isActive, AppGlobal.InitializationIsActiveTAUS(region));
            return new GenerateResponeHelper<List<TA.Data2021.Models.RoomAndUsage>>(list, true, Request, HttpStatusCode.OK);
        }
        [HttpGet]
        public IHttpActionResult GetByIsActiveToList(bool isActive)
        {          
            List<TA.Data2021.Models.RoomAndUsage> list = _roomAndUsageRepository.GetByIsActiveToList(isActive);
            return new GenerateResponeHelper<List<TA.Data2021.Models.RoomAndUsage>>(list, true, Request, HttpStatusCode.OK);
        }
    }
}
