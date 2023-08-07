using BL.BUServices;
using BL.DTO;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TA_Web_2020_API.Helper;
using TA_Web_2020_API.ViewModel;

namespace TA_Web_2020_API.Controllers
{
    [RoutePrefix("api/shoppingcart")]
    public class ShoppingCartController : TABaseAPIController
    {
        private readonly IOrderService _orderService;

        public ShoppingCartController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IHttpActionResult UpdateShoppingCart(BL.DTO.AddToCardRequestObj addToCardRequestObj)
        {
            if (!ModelState.IsValid)
            {
                return new GenerateResponeHelper<string>("Invailid request", false, Request, HttpStatusCode.BadRequest);
            }
            var jwtModel = _helper.GenerateJWTViewModel();
            if (jwtModel.UserId == Guid.Empty)
            {
                return new GenerateResponeHelper<string>("Update shopping cart failed: Invailid User", false, Request, HttpStatusCode.BadRequest);
            }

            string errorMessage = String.Empty;
            try
            {
                var result = _orderService.UpdateShoppingCart(addToCardRequestObj, jwtModel, out errorMessage);
                if (String.IsNullOrEmpty(errorMessage))
                {
                    return new GenerateResponeHelper<BL.DTO.ShoppingCartViewModel>(result, true, Request, HttpStatusCode.OK);
                }
                else
                {
                    return new GenerateResponeHelper<string>(errorMessage, false, Request, HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                BL.Helper.SendErrorEmail(Request, ex);
                return new GenerateResponeHelper<string>(String.Format("Error: {0}: {1}", ex.Message, errorMessage), false, Request, HttpStatusCode.InternalServerError);
            }
        }
        [HttpGet]
        public async Task<IHttpActionResult> RemoveItemInShoppingCart(string Id)
        {
            try
            {
                var ItemItd = BL.Helper.TryParseStringToGuid(Id);
                if (ItemItd == Guid.Empty)
                {
                    return new GenerateResponeHelper<string>("Remove item in shopping cart failed", false, Request, HttpStatusCode.BadRequest);
                }
                else
                {
                    var jwtModel = _helper.GenerateJWTViewModel();
                    if (jwtModel.UserId == Guid.Empty)
                    {
                        return new GenerateResponeHelper<string>("Remove item in shopping cart failed, Invailid User", false, Request, HttpStatusCode.BadRequest);
                    }
                    var result = await _orderService.RemoveItemInShoppingCart((Guid)ItemItd, jwtModel);
                    return new GenerateResponeHelper<BL.DTO.ShoppingCartViewModel>(result, true, Request, HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                BL.Helper.SendErrorEmail(Request, ex);
                return new GenerateResponeHelper<string>("Error: " + ex.Message, false, Request, HttpStatusCode.InternalServerError);
            }
        }

        //getshopping cart count
        //TODO

        [HttpGet]
        public async Task<IHttpActionResult> GetShoppingCartItem()
        {
            try
            {
                var jwtModel = _helper.GenerateJWTViewModel();
                if (jwtModel.UserId == Guid.Empty)
                {
                    return new GenerateResponeHelper<string>("Get items in shopping cart failed, Invailid User", false, Request, HttpStatusCode.BadRequest);
                }
                var result = _orderService.GetShoppingCartByUserId(jwtModel);
                return new GenerateResponeHelper<BL.DTO.ShoppingCartViewModel>(result, true, Request, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                BL.Helper.SendErrorEmail(Request, ex);
                return new GenerateResponeHelper<string>("Error: " + ex.Message, false, Request, HttpStatusCode.InternalServerError);
            }
        }
        [HttpGet]
        public async Task<IHttpActionResult> CheckOutShoppingCart()
        {
            try
            {
                var jwtModel = _helper.GenerateJWTViewModel();
                if (jwtModel.UserId == Guid.Empty)
                {
                    return new GenerateResponeHelper<string>("Check out shopping cart failed, Invailid User", false, Request, HttpStatusCode.BadRequest);
                }
                var cart = await _orderService.CheckOutShoppingCart(jwtModel);
                return new GenerateResponeHelper<BL.DTO.AvailabilityChangedShoppingCart>(cart, true, Request, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                BL.Helper.SendErrorEmail(Request, ex);
                return new GenerateResponeHelper<string>("Error: " + ex.Message, false, Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IHttpActionResult GetInfosToCreateNewOrder()
        {
            try
            {
                var jwtModel = _helper.GenerateJWTViewModel();
                var result = new List<OrderDto> { _orderService.GetInfosToCreateNewOrder(jwtModel) }.AsQueryable().Select(OrderViewModel.Dto2ViewModelSelector).FirstOrDefault();
                return new GenerateResponeHelper<OrderViewModel>(result, true, Request, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                BL.Helper.SendErrorEmail(Request, ex);
                return new GenerateResponeHelper<string>("Error: " + ex.Message, false, Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> SubmitOrder(OrderViewModel orderUpdateModel)
        {
            try
            {
                var jwtModel = _helper.GenerateJWTViewModel();
                if (jwtModel.UserId == Guid.Empty)
                {
                    return new GenerateResponeHelper<string>("Invailid User", false, Request, HttpStatusCode.BadRequest);
                }
                if (string.IsNullOrEmpty(orderUpdateModel.StoreID))
                {
                    orderUpdateModel.StoreID = "";
                }
                if (string.IsNullOrEmpty(orderUpdateModel.TausID))
                {
                    orderUpdateModel.TausID = "";
                }
                OrderDto orderDto = new List<OrderViewModel> { orderUpdateModel }.AsQueryable().Select(OrderViewModel.ViewModel2DtoSelector).FirstOrDefault();
                orderDto = await _orderService.SubmitOrder(orderDto, jwtModel);
                OrderViewModel resViewModel = new List<OrderDto> { orderDto }.AsQueryable().Select(OrderViewModel.Dto2ViewModelSelector).FirstOrDefault();
                return new GenerateResponeHelper<OrderViewModel>(resViewModel, true, Request, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                BL.Helper.SendErrorEmail(Request, ex);
                return new GenerateResponeHelper<OrderViewModel>(orderUpdateModel, false, Request, HttpStatusCode.InternalServerError);
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> SubmitOrder2021()
        {
            OrderViewModel orderUpdateModel = new OrderViewModel();
            orderUpdateModel.SpecialInstruction = "We will be testing order emails today. If an order has “TEST ORDER DO NOT PROCESS” in the notes, please know that it is not an actual order.";
            orderUpdateModel.ContainerReference = "";
            orderUpdateModel.BillingAddressString = "dasd, dsad, Bulqize, Qarku i Dibres, Albania, fdsfsd, Phone: fsdf";            
            orderUpdateModel.OrderBy = null;
            orderUpdateModel.OrderDate = DateTime.Parse("0001-01-01T00:00:00");
            orderUpdateModel.ShippingAddressString = "dasd, dsad, Bulqize, Qarku i Dibres, Albania, fdsfsd, Phone: fsdf";
            orderUpdateModel.ShippingDate = null;
            orderUpdateModel.ShoppingCartId = Guid.Parse("00000000-0000-0000-0000-000000000000");            
            orderUpdateModel.StoreID = "0a696fbc-b749-4b61-8c2a-11379522b088";
            orderUpdateModel.ShoppingCartInfos = new BL.DTO.ShoppingCartViewModel();
            orderUpdateModel.ShoppingCartInfos.Count = "2";
            orderUpdateModel.ShoppingCartInfos.Total = "1290.00000000";
            orderUpdateModel.ShoppingCartInfos.Volume = "0.75";

            try
            {
                var jwtModel = _helper.GenerateJWTViewModel();
                jwtModel.UserId = Guid.Parse("807c03fc-9e15-4200-a7f1-bfae48128cb0");
                if (jwtModel.UserId == Guid.Empty)
                {
                    return new GenerateResponeHelper<string>("Invailid User", false, Request, HttpStatusCode.BadRequest);
                }
                OrderDto orderDto = new List<OrderViewModel> { orderUpdateModel }.AsQueryable().Select(OrderViewModel.ViewModel2DtoSelector).FirstOrDefault();               
                orderDto = await _orderService.SubmitOrder(orderDto, jwtModel);
                OrderViewModel resViewModel = new List<OrderDto> { orderDto }.AsQueryable().Select(OrderViewModel.Dto2ViewModelSelector).FirstOrDefault();
                return new GenerateResponeHelper<OrderViewModel>(resViewModel, true, Request, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                BL.Helper.SendErrorEmail(Request, ex);
                return new GenerateResponeHelper<OrderViewModel>(orderUpdateModel, false, Request, HttpStatusCode.InternalServerError);
            }
        }
    }
}
