using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository) : base()
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        [HttpPost]
        public int Add(ShoppingCart shoppingCart)
        {
            var result = _shoppingCartRepository.Add(shoppingCart);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(ShoppingCart shoppingCart)
        {
            var result = await _shoppingCartRepository.AsyncAdd(shoppingCart);
            return result;
        }
        [HttpPost]
        public int AddRange(List<ShoppingCart> list)
        {
            var result = _shoppingCartRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<ShoppingCart> list)
        {
            var result = await _shoppingCartRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(ShoppingCart shoppingCart)
        {
            var result = _shoppingCartRepository.Update(shoppingCart);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncUpdateBySQLAndSendMail(ShoppingCart shoppingCart)
        {
            var result = await _shoppingCartRepository.AsyncUpdateBySQL(shoppingCart);
            if (!string.IsNullOrEmpty(shoppingCart.Code))
            {
                string aPIDevCall = AppGlobal.APIDevURL + "Email/AsyncSendNotUserNameAndPasswordByShoppingCartObject";
                var content = new StringContent(JsonConvert.SerializeObject(shoppingCart), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var task = client.PostAsync(aPIDevCall, content);
                await task.Result.Content.ReadAsStringAsync();
            }
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(ShoppingCart shoppingCart)
        {
            var result = await _shoppingCartRepository.AsyncUpdate(shoppingCart);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<ShoppingCart> list)
        {
            var result = _shoppingCartRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<ShoppingCart> list)
        {
            var result = await _shoppingCartRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<ShoppingCart> GetAllToList()
        {
            var result = _shoppingCartRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public List<ShoppingCart> GetBySearchStringToList(string searchString)
        {
            var result = _shoppingCartRepository.GetBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public async Task<List<ShoppingCart>> AsyncGetAllToList()
        {
            var result = await _shoppingCartRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<ShoppingCart> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _shoppingCartRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<ShoppingCart>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _shoppingCartRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public ShoppingCart GetByID(string ID)
        {
            ShoppingCart result = new ShoppingCart();
            if (!string.IsNullOrEmpty(ID))
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = _shoppingCartRepository.GetByID(ID);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncUpdateBySQL(ShoppingCart shoppingCart)
        {
            int result = await _shoppingCartRepository.AsyncUpdateBySQL(shoppingCart);
            return result;
        }
    }
}

