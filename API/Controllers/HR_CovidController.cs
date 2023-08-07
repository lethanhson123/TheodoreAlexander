using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class HR_CovidController : BaseController
    {
        private readonly IHR_CovidRepository _hR_CovidRepository;
        public HR_CovidController(IHR_CovidRepository hR_CovidRepository) : base()
        {
            _hR_CovidRepository = hR_CovidRepository;
        }
        [HttpPost]
        public int Add(HR_Covid hR_Covid)
        {
            hR_Covid.ID = 0;
            var result = _hR_CovidRepository.Add(hR_Covid);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(HR_Covid hR_Covid)
        {
            hR_Covid.ID = 0;
            var result = await _hR_CovidRepository.AsyncAdd(hR_Covid);
            return result;
        }
        [HttpPost]
        public int AddRange(List<HR_Covid> list)
        {
            var result = _hR_CovidRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<HR_Covid> list)
        {
            var result = await _hR_CovidRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(HR_Covid hR_Covid)
        {
            var result = _hR_CovidRepository.Update(hR_Covid);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(HR_Covid hR_Covid)
        {
            var result = await _hR_CovidRepository.AsyncUpdate(hR_Covid);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<HR_Covid> list)
        {
            var result = _hR_CovidRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<HR_Covid> list)
        {
            var result = await _hR_CovidRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<HR_Covid> GetAllToList()
        {
            var result = _hR_CovidRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Covid>> AsyncGetAllToList()
        {
            var result = await _hR_CovidRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<HR_Covid> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _hR_CovidRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Covid>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _hR_CovidRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public HR_Covid GetByID(int ID)
        {
            HR_Covid result = _hR_CovidRepository.GetByID(ID);
            return result;
        }
        [HttpGet]
        public List<HR_Covid> GetByCovidTypeIDToList(int covidTypeID)
        {
            var result = _hR_CovidRepository.GetByCovidTypeIDToList(covidTypeID);
            return result;
        }
        [HttpGet]
        public List<HR_CovidDataTransfer> GetDataTransferByEmployeeIDToList(int employeeID)
        {
            var result = _hR_CovidRepository.GetDataTransferByEmployeeIDToList(employeeID);
            return result;
        }
        [HttpGet]
        public List<HR_CovidDataTransfer> GetByF0ToList()
        {
            var result = _hR_CovidRepository.GetDataTransferByCovidTypeIDToList(AppGlobal.F0);
            return result;
        }
        [HttpGet]
        public List<HR_CovidDataTransfer> GetByF1ToList()
        {
            var result = _hR_CovidRepository.GetDataTransferByCovidTypeIDToList(AppGlobal.F1);
            return result;
        }
        [HttpGet]
        public List<HR_CovidDataTransfer> GetByF2ToList()
        {
            var result = _hR_CovidRepository.GetDataTransferByCovidTypeIDToList(AppGlobal.F2);
            return result;
        }
        [HttpGet]
        public List<HR_CovidDataTransfer> GetByNotInfectedToList()
        {
            var result = _hR_CovidRepository.GetDataTransferByCovidTypeIDToList(AppGlobal.NotInfected);
            return result;
        }

        [HttpGet]
        public List<HR_CovidDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            var result = _hR_CovidRepository.GetDataTransferBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<HR_CovidDataTransfer> GetDataTransferBySearchStringAndCodeManageToList(string searchString, string codeManage)
        {
            var result = _hR_CovidRepository.GetDataTransferBySearchStringAndCodeManageToList(searchString, codeManage);
            return result;
        }
        [HttpGet]
        public List<HR_Covid> GetByWithCodeManageToList()
        {
            var result = _hR_CovidRepository.GetByWithCodeManageToList();
            return result;
        }
    }
}

