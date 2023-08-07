using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class HR_Recruitment_IntroduceController : BaseController
    {
        private readonly IHR_Recruitment_IntroduceRepository _hR_Recruitment_IntroduceRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HR_Recruitment_IntroduceController(IHR_Recruitment_IntroduceRepository hR_Recruitment_IntroduceRepository, IWebHostEnvironment webHostEnvironment) : base()
        {
            _hR_Recruitment_IntroduceRepository = hR_Recruitment_IntroduceRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public int Add(HR_Recruitment_Introduce hR_Recruitment_Introduce)
        {
            var result = _hR_Recruitment_IntroduceRepository.Add(hR_Recruitment_Introduce);
            if (result > 0)
            {
                Mail mail = new Mail();
                GetMailBody(hR_Recruitment_Introduce, mail);
                Mail.SendNotUserNameAndPassword(mail);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(HR_Recruitment_Introduce hR_Recruitment_Introduce)
        {
            var result = await _hR_Recruitment_IntroduceRepository.AsyncAdd(hR_Recruitment_Introduce);
            if (result > 0)
            {
                string aPIDevCall = AppGlobal.APIDevURL + "Email/AsyncSendNotUserNameAndPasswordByHR_Recruitment_Introduce";
                var content = new StringContent(JsonConvert.SerializeObject(hR_Recruitment_Introduce), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var task = client.PostAsync(aPIDevCall, content);
                await task.Result.Content.ReadAsStringAsync();
            }
            return result;
        }
        private void GetMailBody(HR_Recruitment_Introduce hR_Recruitment_Introduce, Mail mail)
        {
            string fileName = AppGlobal.HR_Recruitment_RecommenderHTML;
            string subPath = AppGlobal.Download + "/" + AppGlobal.HTML;
            var physicalPathRead = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
            using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                {
                    mail.Body = r.ReadToEnd();
                }
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Introduce.FullName))
            {
                hR_Recruitment_Introduce.FullName = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Introduce.Phone))
            {
                hR_Recruitment_Introduce.Phone = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Introduce.BankID))
            {
                hR_Recruitment_Introduce.BankID = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Introduce.BankName))
            {
                hR_Recruitment_Introduce.BankName = AppGlobal.InitializationString;
            }
            mail.Subject = "HR - Recruitment recommender - " + hR_Recruitment_Introduce.FullName + " - " + hR_Recruitment_Introduce.Phone;
            mail.Body = mail.Body.Replace(@"[FullName]", hR_Recruitment_Introduce.FullName);
            mail.Body = mail.Body.Replace(@"[Phone]", hR_Recruitment_Introduce.Phone);
            mail.Body = mail.Body.Replace(@"[BankID]", hR_Recruitment_Introduce.BankID);
            mail.Body = mail.Body.Replace(@"[BankName]", hR_Recruitment_Introduce.BankName);
        }
        [HttpPost]
        public int AddRange(List<HR_Recruitment_Introduce> list)
        {
            var result = _hR_Recruitment_IntroduceRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<HR_Recruitment_Introduce> list)
        {
            var result = await _hR_Recruitment_IntroduceRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(HR_Recruitment_Introduce hR_Recruitment_Introduce)
        {
            var result = _hR_Recruitment_IntroduceRepository.Update(hR_Recruitment_Introduce);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(HR_Recruitment_Introduce hR_Recruitment_Introduce)
        {
            var result = await _hR_Recruitment_IntroduceRepository.AsyncUpdate(hR_Recruitment_Introduce);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<HR_Recruitment_Introduce> list)
        {
            var result = _hR_Recruitment_IntroduceRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<HR_Recruitment_Introduce> list)
        {
            var result = await _hR_Recruitment_IntroduceRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<HR_Recruitment_Introduce> GetAllToList()
        {
            var result = _hR_Recruitment_IntroduceRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Recruitment_Introduce>> AsyncGetAllToList()
        {
            var result = await _hR_Recruitment_IntroduceRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<HR_Recruitment_Introduce> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _hR_Recruitment_IntroduceRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Recruitment_Introduce>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _hR_Recruitment_IntroduceRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public HR_Recruitment_Introduce GetByID(int ID)
        {
            HR_Recruitment_Introduce result = _hR_Recruitment_IntroduceRepository.GetByID(ID);
            if (result == null)
            {
                result = new HR_Recruitment_Introduce();
            }
            return result;
        }
        [HttpGet]
        public HR_Recruitment_Introduce GetByPhone(string phone)
        {
            HR_Recruitment_Introduce result = _hR_Recruitment_IntroduceRepository.GetByPhone(phone);
            return result;
        }
        [HttpGet]
        public List<HR_Recruitment_Introduce> GetBySearchStringToList(string searchString)
        {
            var result = _hR_Recruitment_IntroduceRepository.GetBySearchStringToList(searchString);
            return result;
        }
    }
}

