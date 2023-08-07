using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) : base()
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public int Add(User user)
        {
            var result = _userRepository.Add(user);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(User user)
        {
            var result = await _userRepository.AsyncAdd(user);
            return result;
        }
        [HttpPost]
        public int AddRange(List<User> list)
        {
            var result = _userRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<User> list)
        {
            var result = await _userRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(User user)
        {
            var result = _userRepository.Update(user);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(User user)
        {
            var result = await _userRepository.AsyncUpdate(user);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<User> list)
        {
            var result = _userRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<User> list)
        {
            var result = await _userRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<User> GetAllToList()
        {
            var result = _userRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<User>> AsyncGetAllToList()
        {
            var result = await _userRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<User> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _userRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<User>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _userRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<UserDataTransfer> GetDataTransferByStoreIDToList(string storeID)
        {
            var result = _userRepository.GetDataTransferByStoreIDToList(storeID);
            return result;
        }
        [HttpGet]
        public List<UserDataTransfer> GetDataTransferByRowNumberToList(int rowNumber)
        {
            var result = _userRepository.GetDataTransferByRowNumberToList(rowNumber);
            return result;
        }
        [HttpGet]
        public List<UserDataTransfer> GetUserEmailDataTransferByDateBeginAndDateEndToList(int dateBeginYear, int dateBeginMonth, int dateBeginDay, int dateEndYear, int dateEndMonth, int dateEndDay, bool isSubcribed, bool isRegister, bool isQuotation)
        {
            var result = _userRepository.GetUserEmailDataTransferByDateBeginAndDateEndToList(dateBeginYear, dateBeginMonth, dateBeginDay, dateEndYear, dateEndMonth, dateEndDay, isSubcribed, isRegister, isQuotation);
            return result;
        }
        [HttpGet]
        public UserDataTransfer001 GetUserDataTransfer001ByID(string ID)
        {
            var result = _userRepository.GetUserDataTransfer001ByID(ID);
            return result;
        }
        [HttpGet]
        public string SyncEMMA(int dateBeginYear, int dateBeginMonth, int dateBeginDay, int dateEndYear, int dateEndMonth, int dateEndDay, bool isSubcribed, bool isRegister, bool isQuotation, bool isSubscriberUS, bool isUserUS, bool isQuoteUS)
        {
            List<UserDataTransfer> listUserDataTransfer = _userRepository.GetUserEmailDataTransferByDateBeginAndDateEndToList(dateBeginYear, dateBeginMonth, dateBeginDay, dateEndYear, dateEndMonth, dateEndDay, isSubcribed, isRegister, isQuotation);
            foreach (UserDataTransfer item in listUserDataTransfer)
            {
                if (!string.IsNullOrEmpty(item.Email))
                {
                    EMMA model = new EMMA();
                    model.email = item.Email.Trim();
                    model.signup_form_id = AppGlobal.SignupID;
                    model.opt_in_confirmation = false;
                    List<string> group_ids = new List<string>();
                    if (isQuoteUS == true)
                    {
                        group_ids.Add(AppGlobal.WebsiteRequestQuoteUS);
                    }
                    if (isUserUS == true)
                    {
                        group_ids.Add(AppGlobal.WebsiteUserUS);
                    }
                    if (isSubscriberUS == true)
                    {
                        group_ids.Add(AppGlobal.WebsiteSubscriberUS);
                    }
                    model.group_ids = group_ids;
                    if (model.group_ids.Count > 0)
                    {
                        string content = JsonConvert.SerializeObject(model);
                        var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                        HttpClientHandler handler = new HttpClientHandler();
                        handler.Credentials = new NetworkCredential(AppGlobal.PublicKey, AppGlobal.PrivateKey);
                        HttpClient request = new HttpClient(handler);
                        System.Threading.Tasks.Task<HttpResponseMessage> result = request.PostAsync(String.Format("https://api.e2ma.net/{0}/members/signup", AppGlobal.AccountID), stringContent);
                    }
                }
            }
            return AppGlobal.InitializationString;
        }
    }
}

