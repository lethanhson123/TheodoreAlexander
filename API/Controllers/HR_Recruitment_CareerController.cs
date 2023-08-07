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
    public class HR_Recruitment_CareerController : BaseController
    {
        private readonly IHR_Recruitment_CareerRepository _hR_Recruitment_CareerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HR_Recruitment_CareerController(IHR_Recruitment_CareerRepository hR_Recruitment_CareerRepository, IWebHostEnvironment webHostEnvironment) : base()
        {
            _hR_Recruitment_CareerRepository = hR_Recruitment_CareerRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public int Add(HR_Recruitment_Career hR_Recruitment_Career)
        {
            var result = _hR_Recruitment_CareerRepository.Add(hR_Recruitment_Career);
            if (result > 0)
            {
                Mail mail = new Mail();
                GetMailBody(hR_Recruitment_Career, mail);
                Mail.SendNotUserNameAndPassword(mail);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(HR_Recruitment_Career hR_Recruitment_Career)
        {
            var result = await _hR_Recruitment_CareerRepository.AsyncAdd(hR_Recruitment_Career);
            if (result > 0)
            {
                string aPIDevCall = AppGlobal.APIDevURL + "Email/AsyncSendNotUserNameAndPasswordByHR_Recruitment_Career";
                var content = new StringContent(JsonConvert.SerializeObject(hR_Recruitment_Career), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var task = client.PostAsync(aPIDevCall, content);
                await task.Result.Content.ReadAsStringAsync();
            }
            return result;
        }
        private void GetMailBody(HR_Recruitment_Career hR_Recruitment_Career, Mail mail)
        {
            string fileName = AppGlobal.HR_Recruitment_RegisterHTML;
            string subPath = AppGlobal.Download + "/" + AppGlobal.HTML;
            var physicalPathRead = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
            using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                {
                    mail.Body = r.ReadToEnd();
                }
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.FullName))
            {
                hR_Recruitment_Career.FullName = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.Phone))
            {
                hR_Recruitment_Career.Phone = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.Email))
            {
                hR_Recruitment_Career.Email = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.JobFunction))
            {
                hR_Recruitment_Career.JobFunction = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.Experience))
            {
                hR_Recruitment_Career.Experience = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.MediaSource))
            {
                hR_Recruitment_Career.MediaSource = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.RecommendPhone))
            {
                hR_Recruitment_Career.RecommendPhone = AppGlobal.InitializationString;
            }
            if (string.IsNullOrEmpty(hR_Recruitment_Career.RecommendFullName))
            {
                hR_Recruitment_Career.RecommendFullName = AppGlobal.InitializationString;
            }

            mail.Subject = mail.Subject + " - " + hR_Recruitment_Career.FullName + " - " + hR_Recruitment_Career.Phone;
            mail.Body = mail.Body.Replace(@"[FullName]", hR_Recruitment_Career.FullName);
            mail.Body = mail.Body.Replace(@"[Phone]", hR_Recruitment_Career.Phone);
            mail.Body = mail.Body.Replace(@"[Email]", hR_Recruitment_Career.Email);
            mail.Body = mail.Body.Replace(@"[JobFunction]", hR_Recruitment_Career.JobFunction);
            mail.Body = mail.Body.Replace(@"[Experience]", hR_Recruitment_Career.Experience);
            mail.Body = mail.Body.Replace(@"[MediaSource]", hR_Recruitment_Career.MediaSource);
            mail.Body = mail.Body.Replace(@"[RecommendPhone]", hR_Recruitment_Career.RecommendPhone);
            mail.Body = mail.Body.Replace(@"[RecommendFullName]", hR_Recruitment_Career.RecommendFullName);
        }
        [HttpPost]
        public int AddRange(List<HR_Recruitment_Career> list)
        {
            var result = _hR_Recruitment_CareerRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<HR_Recruitment_Career> list)
        {
            var result = await _hR_Recruitment_CareerRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(HR_Recruitment_Career hR_Recruitment_Career)
        {
            var result = _hR_Recruitment_CareerRepository.Update(hR_Recruitment_Career);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(HR_Recruitment_Career hR_Recruitment_Career)
        {
            var result = await _hR_Recruitment_CareerRepository.AsyncUpdate(hR_Recruitment_Career);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<HR_Recruitment_Career> list)
        {
            var result = _hR_Recruitment_CareerRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<HR_Recruitment_Career> list)
        {
            var result = await _hR_Recruitment_CareerRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<HR_Recruitment_Career> GetAllToList()
        {
            var result = _hR_Recruitment_CareerRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Recruitment_Career>> AsyncGetAllToList()
        {
            var result = await _hR_Recruitment_CareerRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<HR_Recruitment_Career> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _hR_Recruitment_CareerRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<HR_Recruitment_Career>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _hR_Recruitment_CareerRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public HR_Recruitment_Career GetByID(int ID)
        {
            HR_Recruitment_Career result = _hR_Recruitment_CareerRepository.GetByID(ID);
            if (result == null)
            {
                result = new HR_Recruitment_Career();
            }
            return result;
        }
        [HttpGet]
        public async Task<string> AsyncSendMailByID(int ID)
        {
            string result = AppGlobal.InitializationString;
            HR_Recruitment_Career hR_Recruitment_Career = _hR_Recruitment_CareerRepository.GetByID(ID);
            if (hR_Recruitment_Career.ID > 0)
            {
                string aPIDevCall = AppGlobal.APIDevURL + "Email/AsyncSendNotUserNameAndPasswordByHR_Recruitment_Career";
                var content = new StringContent(JsonConvert.SerializeObject(hR_Recruitment_Career), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var task = client.PostAsync(aPIDevCall, content);
                await task.Result.Content.ReadAsStringAsync();
            }
            return result;
        }
        [HttpGet]
        public List<HR_Recruitment_Career> GetByRecommendPhoneToList(string recommendPhone)
        {
            List<HR_Recruitment_Career> result = _hR_Recruitment_CareerRepository.GetByRecommendPhoneToList(recommendPhone);
            return result;
        }
        [HttpGet]
        public List<HR_Recruitment_Career> GetByRecommendPhoneAndSearchStringToList(string recommendPhone, string searchString)
        {
            List<HR_Recruitment_Career> result = _hR_Recruitment_CareerRepository.GetByRecommendPhoneAndSearchStringToList(recommendPhone, searchString);
            return result;
        }
        [HttpGet]
        public List<HR_Recruitment_Career> GetBySearchStringToList(string searchString)
        {
            List<HR_Recruitment_Career> result = _hR_Recruitment_CareerRepository.GetBySearchStringToList(searchString);
            return result;
        }

    }
}

