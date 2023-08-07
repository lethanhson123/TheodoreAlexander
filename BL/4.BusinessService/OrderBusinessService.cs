using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BL.CustomExceptions;
using System.Configuration;
using BL.EntityService;
using BL.DTO;
using System.Transactions;
using DAL.EntityService;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using TA.Data2021.Repositories;


namespace BL.BusinessService
{
    public class OrderBusinessService
    {
        private bool disposed = false;
        private readonly ShoppingCartModelServices _shoppingCartModelServices;
        private readonly ItemEntityService _itemModelServices;
        private readonly DealerEntityService _dealerServices;
        private readonly AddressEntityService _addressServices;
        private readonly UserBusinessService _userService;

        private readonly IMarketingResourceCategoryRepository _marketingResourceCategoryRepository;
        private readonly ShoppingCartRepository _shoppingCartRepository;
        private readonly ShoppingCart_ItemRepository _shoppingCart_ItemRepository;

        public OrderBusinessService(ShoppingCartModelServices shoppingCartModelServices
            , ItemEntityService itemModelServices
            , DealerEntityService dealerServices
            , AddressEntityService addressServices
            , UserBusinessService userService
            , IMarketingResourceCategoryRepository marketingResourceCategoryRepository
            , ShoppingCartRepository shoppingCartRepository
            , ShoppingCart_ItemRepository shoppingCart_ItemRepository)
        {
            _shoppingCartModelServices = shoppingCartModelServices;
            _itemModelServices = itemModelServices;
            _dealerServices = dealerServices;
            _addressServices = addressServices;
            _userService = userService;
            _marketingResourceCategoryRepository = marketingResourceCategoryRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingCart_ItemRepository = shoppingCart_ItemRepository;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _shoppingCartModelServices.Dispose();
                _itemModelServices.Dispose();
                _dealerServices.Dispose();
                _addressServices.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<ShoppingCart_Item> GetShoppingCartByUserId(Guid userId)
        {
            try
            {
                var shoppingCart = _shoppingCartModelServices.GetShoppingCartByUserId(userId).FirstOrDefault();
                if (shoppingCart != null)
                {
                    return shoppingCart.ShoppingCart_Item.ToList();
                }
                return new List<ShoppingCart_Item>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ShoppingCart_Item> UpdateShoppingCart(DTO.AddToCardRequestObj addToCardRequestObj, JWTIdentityViewModel jwtModel, out string errorMessage)
        {
            try
            {
                errorMessage = String.Empty;
                List<ShoppingCart_Item> cartItems = new List<ShoppingCart_Item>();
                {
                    try
                    {
                        if (addToCardRequestObj.Quantity == 0)
                        {
                            errorMessage = "Please choose the quantity to order";
                            return null;
                        }

                        var item = _itemModelServices.Get().FirstOrDefault(o => o.ID == addToCardRequestObj.ItemId);
                        if (item == null)
                        {
                            errorMessage = "Sorry, the item is not available";
                            return null;
                        }

                        int quantityMultiplier = item.QuantityMultiplier != 0 ? item.QuantityMultiplier : 1;
                        if (addToCardRequestObj.Quantity % quantityMultiplier != 0)
                        {
                            errorMessage = String.Format("Please purchased {0} at a time.", item.QuantityMultiplier);
                            return null;
                        }

                        if (jwtModel.UserType == LocalUserType.Dealer || jwtModel.UserType == LocalUserType.Designer)
                        {
                            var shoppingCart = _shoppingCartModelServices.GetShoppingCartByUserId(jwtModel.UserId.Value).FirstOrDefault();
                            if (shoppingCart == null)
                            {
                                shoppingCart = new ShoppingCart { ID = Guid.NewGuid(), UserID = jwtModel.UserId.Value };
                                _shoppingCartModelServices.AddShopingCart(shoppingCart);
                            }
                            var shopingCartItem = _shoppingCartModelServices.GetShoppingCartItems().FirstOrDefault(o => o.Item_ID == item.ID && o.ShoppingCart_ID == shoppingCart.ID);
                            if (shopingCartItem == null)
                            {
                                shopingCartItem = new ShoppingCart_Item
                                {
                                    ShoppingCart_ID = shoppingCart.ID,
                                    Item_ID = item.ID,
                                    Quantity = addToCardRequestObj.Quantity,
                                    DateAdded = DateTime.UtcNow
                                };
                                _shoppingCartModelServices.AddShoppingCartItem(shopingCartItem);
                            }
                            else
                            {
                                shopingCartItem.Quantity = addToCardRequestObj.IsAdd ? shopingCartItem.Quantity + addToCardRequestObj.Quantity : addToCardRequestObj.Quantity;
                                _shoppingCartModelServices.EditShoppingCartItem(shopingCartItem);
                            }
                            cartItems = GetShoppingCartByUserId(jwtModel.UserId.Value);
                        }
                        else
                        {
                            errorMessage = "Please contact us to upgrade your account then you can make an order";
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return cartItems;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<ShoppingCart_Item>> RemoveItemInShoppingCart(Guid ItemId, JWTIdentityViewModel jwtModel)
        {
            try
            {
                List<ShoppingCart_Item> cartItems = new List<ShoppingCart_Item>();

                var shoppingCart = _shoppingCartModelServices.GetShoppingCartByUserId(jwtModel.UserId.Value).FirstOrDefault();
                if (shoppingCart == null)
                {
                    throw new Exception();
                }
                var item = await _shoppingCartModelServices.GetShoppingCartItems().FirstOrDefaultAsync(o => o.Item_ID == ItemId && o.ShoppingCart_ID == shoppingCart.ID);
                if (item == null)
                {
                    throw new Exception();
                }
                var LstShippingStatusItem = await _shoppingCartModelServices.GetShoppingCartItemShippingStatuses().Where(o => o.Item_ID == ItemId && o.ShoppingCart_ID == shoppingCart.ID).ToListAsync();
                if (LstShippingStatusItem.Count() != 0)
                {
                    await _shoppingCartModelServices.RemoveRangeShoppingCartItemShippingStatus(LstShippingStatusItem);
                }
                await _shoppingCartModelServices.RemoveShoppingCartItem(item);
                cartItems = GetShoppingCartByUserId(jwtModel.UserId.Value);
                return cartItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<ShoppingCartItemViewMoel>> CheckAvailabilityChangedItem(JWTIdentityViewModel jwtModel, IList<ShoppingCartItemViewMoel> cartItems)
        {
            try
            {
                //Foreach item in shopping cart - Get inventories and check Is Availability changed item
                IList<BL.DTO.Inventories> lstInventory = await GetInventories((Guid)jwtModel.UserId);
                foreach (var item in cartItems)
                {
                    if (!item.IsAvailable)
                    {
                        item.IsAvailabiliyChanged = true;
                        item.NewAvailability = "Unfortunately this item is no longer available.<br /><br />If you continue to checkout, this item will be removed from your Shopping Cart automatically.<br/>";
                    }
                    else
                    {
                        var itemInInventories = lstInventory.FirstOrDefault(o => o.Item_ID == item.ID && o.MinimumDelay == item.MinimumDelay);
                        if (itemInInventories != null && itemInInventories.Quantity >= item.Quantity)
                        {// If there is enough quantity to serve the delivery as viewed before validation, Availability has not Changed
                            item.IsAvailabiliyChanged = false;
                            item.NewAvailability = itemInInventories.DeliveryTime;
                        }
                        else
                        {
                            //Availability has changed
                            int numDelivered = 0;
                            itemInInventories = lstInventory.FirstOrDefault(o => o.Item_ID == item.ID);
                            int originalInventory = itemInInventories.Quantity >= 1000000000 ? itemInInventories.Quantity - 1000000000 : itemInInventories.Quantity;
                            if (itemInInventories != null && originalInventory >= item.Quantity)
                            {
                                item.IsAvailabiliyChanged = true;
                                item.NewAvailability = "Please note the availability has changed for this item. <br/><br/>" + itemInInventories.DeliveryTime;
                            }
                            else
                            {
                                // Inventories exist for this item, but the fastest delivery does not have enough quantity to serve the request
                                item.NewAvailability = "The quantity you requested exceeds our current availability. We will deliver the item as follows:<br/><ul>";
                                var lstItemInInventories = lstInventory.Where(o => o.Item_ID == item.ID).OrderBy(o => o.MinimumDelay).ToList();
                                foreach (var currentInventoryItem in lstItemInInventories)
                                {
                                    if (currentInventoryItem.Quantity > 0)
                                    {
                                        int thisDelivery = (numDelivered + currentInventoryItem.Quantity) >= item.Quantity ? item.Quantity - numDelivered : currentInventoryItem.Quantity;
                                        item.NewAvailability += string.Format("<li>{0} {1}.</li>", thisDelivery, currentInventoryItem.DeliveryTime);
                                        numDelivered += thisDelivery;
                                        if (numDelivered >= item.Quantity) break;
                                    }
                                }
                                item.NewAvailability += "</ul>";
                                item.IsAvailabiliyChanged = true;
                            }
                        }
                    }

                }
                return cartItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<IList<BL.DTO.Inventories>> GetInventories(Guid UserId)
        {
            try
            {
                return await _shoppingCartModelServices.GetInventories(UserId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ReserveItemsInShoppingCart(Guid UserId)
        {
            bool result = false;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var shoppingCart = await _shoppingCartModelServices.GetShoppingCartByUserId(UserId).FirstOrDefaultAsync();
                if (shoppingCart == null)
                {
                    scope.Complete();
                    return result;
                }
                //delete old shopping cart item shipping status
                var oldShoppingCartItemShippingStatus = await _shoppingCartModelServices.GetShoppingCartItemShippingStatuses().Where(o => o.ShoppingCart_ID == shoppingCart.ID).ToListAsync();
                await _shoppingCartModelServices.RemoveRangeShoppingCartItemShippingStatus(oldShoppingCartItemShippingStatus);
                // Retrive the current inventories for the items in shopping cart.
                var inventories = _shoppingCartModelServices.GetCurrentInventories(shoppingCart.ID);
                //Last shipping status
                var lastShippingStatus = await _shoppingCartModelServices.GetLastShippingStatus().FirstAsync();
                var shoppingCartItems = await _shoppingCartModelServices.GetShoppingCartItems().Where(o => o.ShoppingCart_ID == shoppingCart.ID).ToListAsync();

                //List Item not active (will be delete)
                List<ShoppingCart_Item> lstShoppingCartItemNotActive = new List<ShoppingCart_Item>();
                //List Shopping Cart Item Shipping Status to Add
                List<ShoppingCart_Item_ShippingStatus> lstShoppingCartItemShippingStatus = new List<ShoppingCart_Item_ShippingStatus>();

                foreach (var item in shoppingCartItems)
                {
                    if (!item.Item.IsActive.Value)
                    {
                        lstShoppingCartItemNotActive.Add(item);
                        continue;
                    }
                    int reserved = 0;
                    var itemShippingStatuses = inventories.Where(o => o.Item_ID == item.Item_ID).OrderBy(o => o.MinimumDelay);
                    foreach (var iss in itemShippingStatuses)
                    {
                        int shipping = Math.Min(item.Quantity - reserved, iss.Quantity);
                        if (iss.ShippingStatus_ID == lastShippingStatus.ID) shipping = item.Quantity - reserved;
                        if (shipping > 0)
                        {
                            lstShoppingCartItemShippingStatus.Add(new ShoppingCart_Item_ShippingStatus()
                            {
                                ShoppingCart_ID = shoppingCart.ID,
                                Item_ID = item.Item_ID,
                                ShippingStatus_ID = iss.ShippingStatus_ID,
                                Quantity = shipping
                            });
                            reserved += shipping;
                            if (reserved >= item.Quantity) break;
                        }
                    }

                    if (reserved < item.Quantity)
                    {
                        lstShoppingCartItemShippingStatus.Add(new ShoppingCart_Item_ShippingStatus()
                        {
                            ShoppingCart_ID = shoppingCart.ID,
                            Item_ID = item.Item_ID,
                            ShippingStatus_ID = lastShippingStatus.ID,
                            Quantity = item.Quantity - reserved
                        });
                    }
                }

                //Delete not active item in shopping cart
                await _shoppingCartModelServices.RemoveShopingCartItems(lstShoppingCartItemNotActive);
                await _shoppingCartModelServices.InsertShoppingCartItemShippingStatuses(lstShoppingCartItemShippingStatus);
                scope.Complete();
                result = true;
            }
            return result;
        }

        public async Task<string> CheckingShoppingCartOrder(OrderDto orderUpdateModel, Guid UserId)
        {
            try
            {
                var ck = string.Empty;
                //Invailid shopping cart
                var shoppingCart = await _shoppingCartModelServices.GetShoppingCartByUserId(UserId).FirstOrDefaultAsync();
                if (shoppingCart == null)
                {
                    ck = "Invaild shopping cart";
                }
                if (orderUpdateModel.ShoppingCartInfos != null)
                {
                    //if (orderUpdateModel.ShoppingCartInfos.LstItem.Count() == 0)
                    //{
                    //    ck = "Sorry, there is no item in your shopping cart";
                    //}
                }
                return ck;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BL.DTO.OrderDto> ProcessOrder(OrderDto orderUpdateModel, Guid UserId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    Guid shoppingCartId = await ReduceInventory(UserId);
                    UserViewModel user = await _userService.GetUserById(UserId);
                    Dealer dealer = _dealerServices.GetDealerByUserId(UserId);
                    var shippingDates = await _shoppingCartModelServices.GetShippingDates(shoppingCartId).OrderBy(o => o.MinimumDelay).Select(o => o.DeliveryTime).ToListAsync();
                    BL.DTO.OrderDto orderedOrderInfos = new BL.DTO.OrderDto
                    {
                        ShoppingCartInfos = orderUpdateModel.ShoppingCartInfos,
                        ContainerReference = orderUpdateModel.ContainerReference,
                        OrderDate = DateTime.UtcNow,
                        SpecialInstruction = orderUpdateModel.SpecialInstruction,
                        ShoppingCartId = shoppingCartId,
                        ShippingDate = shippingDates,
                        OrderBy = user.Firstname + " " + user.Lastname,
                        BillingAddressString = orderUpdateModel.BillingAddressString,
                        ShippingAddressString = orderUpdateModel.ShippingAddressString,
                        StoreID = orderUpdateModel.StoreID,
                        TausID = orderUpdateModel.TausID,
                    };

                    var sendEmailResult = await SendOrderEmail2021Version002(orderedOrderInfos, user, dealer);
                    scope.Complete();
                    return orderedOrderInfos;
                }
                catch (Exception ex)
                {
                    string mes = ex.Message;
                    scope.Dispose();
                    throw ex;
                }
            }            
        }

        private string GetAddressString(Guid AddressId)
        {
            try
            {
                string address = string.Empty;
                var s = _addressServices.Get(AddressId).FirstOrDefault();
                if (s != null)
                {
                    address = Helper.CalculateAddress(s.AddressLine1, s.AddressLine2, s.City.Name, s.City.Region.Name, s.City.Region.Country.Name, s.PostalCode, s.Phone);
                }
                return address;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<Guid> ReduceInventory(Guid UserId)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var shoppingCart = await _shoppingCartModelServices.GetShoppingCartByUserId(UserId).FirstOrDefaultAsync();
                    await _shoppingCartModelServices.ReduceInventory(shoppingCart);
                    scope.Complete();
                    return shoppingCart.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> SendOrderEmail(BL.DTO.OrderDto orderedOrderInfos, UserViewModel user, Dealer dealer = null)
        {
            try
            {
                string sirvProductPhotos = ConfigurationManager.AppSettings["SirvProductPhoto"];
                string webURL = ConfigurationManager.AppSettings["WebURL"];
                string emailContent = String.Empty;
                emailContent = @"<style type='text/css' media='screen'> body { background-color: #ffffff; margin: 0; padding: 0; font-family: 'Arial'; font-size: 11px; } a img { border: none; } a { border: none; } td.permission { padding: 30px 0 10px 0; } .header h1 { font-family: Georgia; font-size: 32px; font-weight: normal; color: #bfbfbf; display: inline; text-align: left; } .date h3 { font-family: Georgia; font-size: 14px; color: #bfbfbf; font-weight: normal; text-align: right; display: inline; font-style: italic; } .body { background-color: #ffffff; } td.mainbar { padding: 22px 14px 0 14px; } p.legal { font-size: 10px; } .mainbar p { font-family: 'Arial'; font-size: 12px; color: #333333; margin: 0 0 10px 0; text-align: left; } .mainbar p.first { margin-top: 10px; } .mainbar h2 { font-family: 'Arial'; font-size: 16px; color: #000000; text-transform: uppercase; margin: 10px 0 16px 0; } .mainbar h2 a { font-family: 'Arial'; font-size: 16px; color: #000000; text-transform: uppercase; text-decoration: none; font-style: normal; } #eImage { padding: 8px 0 0 10px; } .mainbar a { font-family: Arial; font-size: 13px; color: #2679b9; font-style: italic; } .mainbar a.center { font-size: 12px; text-align: center; display: block; color: #999999; padding: 8px 0 12px 0; text-decoration: none; } .mainbar img.inline { border: 1px solid #dedede; padding: 4px; } .mainbar td { vertical-align: top; } td.footer { padding: 0 0 10px 0; } .footer p { font-size: 11px; margin: 0; padding: 0; } .footer p.first { margin: 14px 0 0 0; } .footer a { font-family: 'Arial'; font-size: 11px; color: #2679b9; } #content {display:block; background: url(../images/auxbkg-content.jpg) no-repeat #fff; width:981px; height:260px;}.footer-bottom{position:relative; bottom:0px;}.dlrSelector, .dlrSearch{line-height:normal;}#shoppingCart {width:100%; padding-top:64px;}#shoppingCart #breadcrumbs {color:#333333;font-family:Arial;font-size:11px;overflow:hidden;padding:37px 22px 10px 50px;}#cartShipping #top h1, #shoppingCart h1.heading {font-weight:normal; font-style:italic;}#shoppingCart h1.heading {font-style:normal;}#shoppingCart #emptyCart p {color:#333; background-color: #e5e5e5; font-size: 12px; font-weight: bold; margin: -30px 40px 30px 0; padding: 30px 0 0 20px; height: 60px;}#shoppingCart #top p {float:left; width:455px; padding:1em 20px 2em 0; font-size:0.917em;color:#333333;text-align:right;line-height:17px}#shoppingCart #top h1 {float:left; width:430px; padding:10px 0 0 20px;}#shoppingCart #cartHeader, #shoppingCart table.cartContents {margin: 0 auto; clear:both;}#shoppingCart #selectHeader {clear:both; width:100%; height:63px;line-height:57px;}#shoppingCart #selectHeader li, #shoppingCart #cartFooter li{float:left; line-height:53px;}#shoppingCart #selectHeader #cartTotals {height:64px;float:right;background: url(../images/bkg-cart.jpg) no-repeat;width:605px;}#shoppingCart #selectHeader li strong, #shoppingCart #cartFooter li strong {font-weight:normal;}#shoppingCart #top h1.heading span {color:#666666;font-size:11px;}.separtor{border-right: 1px solid #989898;}#shoppingCart #top {width:926px; margin: 0 auto; overflow:hidden;}#shoppingCart #selectCategory {width:320px; position:relative;background: url(../images/bkg-selectCategoryCart.jpg) no-repeat right top; height:56px;}#shoppingCart .blueFinisher{background: url(../images/bkg-totals.jpg) no-repeat 100% 0; height:63px; width:625px;}.content-no-sidebar-full{padding:0!important;}.content-no-sidebar-full div.subsection a {line-height:18px;}#btnSeeAllProductResults span.iconArrowRight{width:10px;}#divEmpty{padding-top:40px; clear:both;width:881px; margin:0 auto;}#Volume {padding-left:8px; line-height:17px;}.col1{width:101px;}.col2 {width:120px;}.col3 {width:74px;}.pricing .col1 {width:78px;}.pricing .col2 {width:73px;}.cartContents .pricing td.col3{width:65px;padding-left:15px;}.m {width:23px;vertical-align:middle!important;}.cartContents {margin-top:10px;}.cartContents thead tr{height: 35px; line-height: 35px; background-color:#e6e6e6; color:#19212e; font-weight:bold;}.cartContents tbody td {padding:30px 0; vertical-align:top;}.cartContents .availability td {padding:0;}.cartContents tbody tr.row {background: url(../images/separator-products.jpg) center center no-repeat;}.cartContents tbody tr.row td {padding:0;}.cartContents .pricing tbody tr {background: none!important;}.cartContents table td {vertical-align:top;}.cartContents .separator {border-right:1px solid #989898;}.cartContents .sku {padding: .5em 0;}.cartContents .sku, #shoppingCart table table {width:100%; overflow:hidden;}.cartContents .sku li {float:left;font-size:11px}.cartContents .pricing input {border:1px solid #d0d0d0; font-size:0.917em; padding:.5em; width:25px;border:1px solid #cdcdcd;padding:.25em; width:40px;text-align:right;}.cartContents td.productImage {text-align:center; width:185px; margin:0 auto;}.cartContents td.productInfo {width:445px;}.cartContents td.productInfo h1{font-size:16px; font-family:georgia,garamond,serif;font-weight:bold}.cartContents td.productInfo ul.options {font-size:12px;}.cartContents tr {background: url(../images/separator-product.jpg) no-repeat; }.cartContents .pricing td {padding:0 0 10px 0;line-height:23px;}.cartContents td.pricingContent {width:290px;font-size:14px;}.hrLine {clear:both;background:url(../images/hr-dot.gif) repeat-x; margin:10px 0;height:1px;width:100%;}a.section-link {margin: 6px 0 0 0;}.tipsy-inner {padding: 6px 15px 6px 15px !important;}.remove {clear:both; display:block; padding-top:20px; text-transform: uppercase; color: #556e97!important; font-weight:bold;font-size:0.833em;}.remove:link{text-decoration:underline;}.sku li span {color:#19212e!important;font-size:11px;}.sku li {color:#666666;}.sku .separator {padding: 0 10px 0 0; line-height:17px;}.options{color:#333333;padding:5px 0 0 0 !important;}.pricing input {background-color:#fff; border:1px solid #cdcdcd; }.pricingError {background-color:#fef8d2;}.pricing {font-size:1.167em; font-weight:bold; width:290px; margin: 0 auto;}.availability {width:272px;font-size:11px;}.availability .title {color:#252525;width:70px;}.availability table {width:270px;}.availability .availMsg {color:#898989;padding-left:5px;}.availability .errorMsg ul {padding-top:24px;}.pricingContent .errorMsg {margin-bottom:.7em;}.productInfo h1 a{color:#252e3c;}.productInfo h1 a:hover {color:#9f3a1a;}div.backtotopsm {width: 881px; margin-left: auto; margin-right: auto;}ol, ul { list-style:none outside none;}</style><table width='100 % ' cellspacing='0' cellpadding='0' bgcolor='#ffffff'> <tr> <td align='center'> <table width='700' cellspacing='0' cellpadding='0'> <tr> <td style='height:77' align='left' class='header'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td> <asp:Image ID='imgHeader' runat='server' Width='700' Height='49' AlternateText='Theodore Alexander' /> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> <td align='center'> <table width='700' cellspacing='0' cellpadding='0' class='body'> <tr> <td align='left' valign='top' class='mainbar'> <p> To whom it may concern, </p> <p> An order has been submitted through the Theodore Alexander web site, please review and process this order.</p> <table width='100%'> <tr> <td style='width: 40%'> <b>Total Items</b> </td> <td> " + orderedOrderInfos.ShoppingCartInfos.Count + " </td> </tr> <tr> <td> <b>Order subtotal*</b> </td> <td> " + Double.Parse(orderedOrderInfos.ShoppingCartInfos.Total).ToString("C0") + " </td> </tr> <tr> <td> <b>Order volume</b> </td> <td> " + orderedOrderInfos.ShoppingCartInfos.Volume + " CBM </td> </tr> <tr> <td> <b>Ordered by</b> </td> <td> " + user.Firstname + " " + user.Lastname + " </td> </tr> ";
                if (dealer != null)
                {
                    emailContent += @"<tr> <td> <b>Store name</b> </td> <td>" + (dealer.Stores.FirstOrDefault() != null ? dealer.Stores.FirstOrDefault().Name : "") + "</td> </tr>";
                }
                emailContent += @"<tr> <td> <b>Login name</b> </td> <td> " + user.Username + " </td> </tr> <tr> <td> <b>User type</b> </td> <td> " + user.UserTypeName + " </td> </tr> <tr> <td> <b>Customer ID</b> </td> <td> " + user.ID + " </td> </tr> <tr> <td> <b>Order date and time</b> </td> <td> " + orderedOrderInfos.OrderDate + " </td> </tr> <tr> <td> <b>Estimated shipping date(s)</b> </td> <td> " + String.Join("<br/>", orderedOrderInfos.ShippingDate) + " </td> </tr> <tr> <td><b>Email</b></td> <td>" + user.Email + "</td> </tr> <tr> <td> <b>Billing Address</b> </td> <td> " + orderedOrderInfos.BillingAddressString + " </td> </tr> <tr> <td> <b>Shipping Address</b> </td> <td> " + orderedOrderInfos.ShippingAddressString + " </td> </tr> <tr> <td> <b>Container Reference Number</b> </td> <td> " + orderedOrderInfos.ContainerReference + " </td> </tr> <tr> <td> <b>Order Notes</b> </td> <td> " + orderedOrderInfos.SpecialInstruction + " </td> </tr> </table> </td> </tr> <tr> <td> <div id='shoppingCart'>";
                emailContent += @"<table style='width:100%'>";
                foreach (var item in orderedOrderInfos.ShoppingCartInfos.LstItem)
                {
                    emailContent += @"<tr><td><a href='" + webURL + "/product-detail/" + item.ID + "' target='_blank'><img src='" + sirvProductPhotos + "/" + item.SKU.Substring(0, 3) + "/" + item.SKU + "_main_1.jpg?w=200&profile=new_PlaceHolderImageNotFound'/></a></td><td><div><b>" + item.ProductName + "</b></div><ul><li>" + item.SKU + "</li><li>" + Math.Round(item.Volume, 3) + " CBM</li></ul></td><td><div><b>" + item.Quantity + " x " + (dealer != null ? item.WholesalePriceList.DealerPrice.Price : item.WholesalePriceList.DesignerPrice.Price) + " = " + item.ItemTotal.ToString("C0") + "</b></div><div>Availability:" + item.Availability + "</div></td></tr>";
                }
                emailContent += @"</table>";
                emailContent += @"</div> </td> </tr> <tr> </table> </td> </tr></table>";
                string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                string emailTo = ConfigurationManager.AppSettings["TradeEnquiryEmailTo"];
                var sendMailResult = await Helper.SendMail(emailFrom, emailFrom, emailTo, emailTo, "An order has been submitted", emailContent);
                //send email to Willy, Sydney, Dan for test
                string environment = ConfigurationManager.AppSettings["TA-Environment"];
                if (!String.IsNullOrEmpty(environment) && environment.StartsWith("TA-RELEASE"))
                {
                    //await Helper.SendMail(emailFrom, emailFrom, "wjohan@theodorealexander.com", "wjohan@theodorealexander.com", "An order has been submitted", emailContent);
                    //await Helper.SendMail(emailFrom, emailFrom, "swells@theodorealexander.com", "swells@theodorealexander.com", "An order has been submitted", emailContent);                    
                    await Helper.SendMail(emailFrom, emailFrom, "ludan@theodorealexander.com", "ludan@theodorealexander.com", "An order has been submitted", emailContent);
                }
                return sendMailResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<bool> SendOrderEmail2021(BL.DTO.OrderDto orderedOrderInfos, UserViewModel user, Dealer dealer = null)
        {
            try
            {
                string sirvProductPhotos = ConfigurationManager.AppSettings["SirvProductPhoto"];
                string webURL = ConfigurationManager.AppSettings["WebURL"];
                string emailContent = String.Empty;
                string orderCode = orderedOrderInfos.OrderDate.ToString("yyyyMMdd") + orderedOrderInfos.OrderDate.Hour + orderedOrderInfos.OrderDate.Minute + "_" + user.Firstname.Replace(@" ", @"") + user.Lastname.Replace(@" ", @"");


                TA.Data2021.Models.ShoppingCart shoppingCart = new TA.Data2021.Models.ShoppingCart();
                shoppingCart.Code = orderCode;
                shoppingCart.OrderDate = orderedOrderInfos.OrderDate;
                shoppingCart.ItemCount = orderedOrderInfos.ShoppingCartInfos.Count;
                shoppingCart.Total = Double.Parse(orderedOrderInfos.ShoppingCartInfos.Total).ToString("C0");
                shoppingCart.Volume = orderedOrderInfos.ShoppingCartInfos.Volume;
                shoppingCart.FirstName = user.Firstname;
                shoppingCart.LastName = user.Lastname;
                if (dealer != null)
                {
                    shoppingCart.StoreName = (dealer.Stores.FirstOrDefault() != null ? dealer.Stores.FirstOrDefault().Name : "");
                }
                shoppingCart.UserName = user.Username;
                shoppingCart.UserTypeName = user.UserTypeName;
                shoppingCart.UserID = user.ID;
                shoppingCart.ShippingDate = String.Join("<br/>", orderedOrderInfos.ShippingDate);
                shoppingCart.Email = user.Email;
                shoppingCart.UserName = user.Username;
                shoppingCart.BillingAddressString = orderedOrderInfos.BillingAddressString;
                shoppingCart.ShippingAddressString = orderedOrderInfos.ShippingAddressString;
                shoppingCart.ContainerReference = orderedOrderInfos.ContainerReference;
                shoppingCart.SpecialInstruction = orderedOrderInfos.SpecialInstruction;
                shoppingCart.ID = orderedOrderInfos.ShoppingCartId;

                List<TA.Data2021.Models.ShoppingCart_Item> listShoppingCart_Item = new List<TA.Data2021.Models.ShoppingCart_Item>();

                StringBuilder htmlContent = new StringBuilder();
                htmlContent.AppendLine(@"<body style='background-color:#eeeeee; font-family: Roboto, Helvetica, sans-serif;'>");
                htmlContent.AppendLine(@"<link href='https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap' rel='stylesheet'>");
                htmlContent.AppendLine(@"<style type='text/css'>");
                htmlContent.AppendLine(@"* {");
                htmlContent.AppendLine(@"margin: 0;");
                htmlContent.AppendLine(@"padding: 0;");
                htmlContent.AppendLine(@"}");
                htmlContent.AppendLine(@"#customers {");
                htmlContent.AppendLine(@"font-family: Roboto, Helvetica, sans-serif;");
                htmlContent.AppendLine(@"border-collapse: collapse;");
                htmlContent.AppendLine(@"width: 100%;");
                htmlContent.AppendLine(@"}");
                htmlContent.AppendLine(@"#customers td,");
                htmlContent.AppendLine(@"#customers th {");
                htmlContent.AppendLine(@"border: 0;");
                htmlContent.AppendLine(@"padding: 8px;");
                htmlContent.AppendLine(@"}");
                htmlContent.AppendLine(@"#customers td:nth-child(2) {");
                htmlContent.AppendLine(@"font-weight: bold;");
                htmlContent.AppendLine(@"}");
                htmlContent.AppendLine(@"#product_ta {");
                htmlContent.AppendLine(@"font-family: Roboto, Helvetica, sans-serif;");
                htmlContent.AppendLine(@"border-collapse: collapse;");
                htmlContent.AppendLine(@"width: 100%;");
                htmlContent.AppendLine(@"}");
                htmlContent.AppendLine(@"#product_ta tr {");
                htmlContent.AppendLine(@"border-bottom: 1px solid #e4e4e4;");
                htmlContent.AppendLine(@"padding: 20px 0 50px 0;");
                htmlContent.AppendLine(@"}");
                htmlContent.AppendLine(@"#product_ta tr:last-child {");
                htmlContent.AppendLine(@"border-bottom: none;");
                htmlContent.AppendLine(@"}");
                htmlContent.AppendLine(@"#product_ta tr td {");
                htmlContent.AppendLine(@"padding: 20px 0;");
                htmlContent.AppendLine(@"}");
                htmlContent.AppendLine(@"#product_ta tr p {");
                htmlContent.AppendLine(@"padding: 5px 0;");
                htmlContent.AppendLine(@"}");
                htmlContent.AppendLine(@"</style>");
                htmlContent.AppendLine(@"<table width='100%' border='0' cellspacing='0' cellpadding='0' style='font-family: Roboto, Helvetica, sans-serif; width: 100%; margin: 0 auto; max-width: 1000px; background-color: #ffffff;'>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td align='center' valign='top' width='100%'>");
                htmlContent.AppendLine(@"<table width='80%' border='0' cellspacing='0' cellpadding='0' align='center' class='MainContainer' bgcolor='#fff' style='padding:15px; background:#fff; margin:10px auto;'>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td align='center' valign='top' width='100%'>");
                htmlContent.AppendLine(@"<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td align='center' valign='top' width='100%'>");
                htmlContent.AppendLine(@"<table width='100%' cellpadding='0' cellspacing='0' border='0' style='margin: 0 auto; height: auto;' align='center'>");
                htmlContent.AppendLine(@"<tr align='center'>");
                htmlContent.AppendLine(@"<td style='width: 100%; padding: 10px 5px 5px 5px;text-align: center'>");
                htmlContent.AppendLine(@"<img src='https://theodorealexander.sirv.com/website/Frontend/Live/assests/emailwishlist/logo_ta.png' style = 'max-width: 100%;'>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr align='center'>");
                htmlContent.AppendLine(@"<td style='width: 100%; padding: 10px 5px 5px 5px;text-align: center; font-size: 30px;font-family: Roboto, Helvetica, sans-serif;'>");
                htmlContent.AppendLine(@"Thank you for ordering");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr align='center'>");
                htmlContent.AppendLine(@"<td style='width: 100%; padding: 10px 5px 5px 5px;text-align: center; padding-bottom: 20px; text-align: justify; line-height: 25px;font-family: Roboto, Helvetica, sans-serif;'>");
                htmlContent.AppendLine(@"We’ve received your order and will send you an acknowledgement of your order status within <b>48 hours </b>. If you need any assistance with your order in the meanwhile, please contact our Customer Services Team at <b>1-336-885-5005</b>. We are available to help you between the hours of <b> 8 a.m to 5 p.m EST </b>, Monday to Friday. You can also contact us via email at <b>info@theodorealexander.com</b>. Check your order history any time in the account area.");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td style='height: 5px; background-color: #F5f5f5;'></td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td style='padding-top: 20px;'>");
                htmlContent.AppendLine(@"<table id='customers'>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Order code</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>#" + orderCode + "</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Total Items</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + orderedOrderInfos.ShoppingCartInfos.Count + "</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Order subtotal *</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + Double.Parse(orderedOrderInfos.ShoppingCartInfos.Total).ToString("C0") + "</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Order volume</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + orderedOrderInfos.ShoppingCartInfos.Volume + " CBM</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Ordered by</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + user.Firstname + " " + user.Lastname + "</td>");
                htmlContent.AppendLine(@"</tr>");
                if (dealer != null)
                {
                    htmlContent.AppendLine(@"<tr>");
                    htmlContent.AppendLine(@"<td>Dealers name</td>");
                    htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + (dealer.Stores.FirstOrDefault() != null ? dealer.Stores.FirstOrDefault().Name : "") + "</td>");
                    htmlContent.AppendLine(@"</tr>");
                    htmlContent.AppendLine(@"<tr>");
                    htmlContent.AppendLine(@"<td>Dealers ID</td>");
                    htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + (dealer.Stores.FirstOrDefault() != null ? dealer.Stores.FirstOrDefault().ID.ToString() : "") + "</td>");
                    htmlContent.AppendLine(@"</tr>");
                }
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>User name</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + user.Username + "</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>User type</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + user.UserTypeName + "</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>User ID</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + user.ID + "</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Order date and time</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + orderedOrderInfos.OrderDate + "</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Estimated shipping date(s) </td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + String.Join("<br/>", orderedOrderInfos.ShippingDate) + "</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Email</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>" + user.Email + "</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Billing Address</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>");
                htmlContent.AppendLine(@"" + orderedOrderInfos.BillingAddressString);
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Shipping Address</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>");
                htmlContent.AppendLine(@"" + orderedOrderInfos.ShippingAddressString);
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Container Reference Number</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>");
                htmlContent.AppendLine(@"" + orderedOrderInfos.ContainerReference);
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td>Order Notes</td>");
                htmlContent.AppendLine(@"<td style='font-weight:bold;'>");
                htmlContent.AppendLine(@"" + orderedOrderInfos.SpecialInstruction);
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"</table>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"</table>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"</table>");
                htmlContent.AppendLine(@"<table width='100%'>");

                foreach (var item in orderedOrderInfos.ShoppingCartInfos.LstItem)
                {
                    htmlContent.AppendLine(@"<tr>");
                    htmlContent.AppendLine(@"<td>");
                    htmlContent.AppendLine(@"<table id='product_ta'>");
                    htmlContent.AppendLine(@"<tr style='border-bottom:1px solid #e4e4e4'>");
                    htmlContent.AppendLine(@"<td style='width:40%'>");
                    htmlContent.AppendLine(@"<a href='" + webURL + "/product-detail/" + item.ID + "' target='_blank' title='" + item.ProductName + "'><img title='" + item.ProductName + "' alt='" + item.ProductName + "' src='" + sirvProductPhotos + "/" + item.SKU.Substring(0, 3) + "/" + item.SKU + "_main_1.jpg?w=200&h=200' /></a>");
                    htmlContent.AppendLine(@"</td>");
                    htmlContent.AppendLine(@"<td style='text-align:left'>");
                    htmlContent.AppendLine(@"<p style='font-weight: bold; font-size: 20px;'>");
                    htmlContent.AppendLine(@"<a style='text-decoration: none; color:#212121' href='" + webURL + "/product-detail/" + item.ID + "' target='_blank' title='" + item.ProductName + "'>" + item.ProductName + "</a>");
                    htmlContent.AppendLine(@"</p>");
                    htmlContent.AppendLine(@"<p><a style='text-decoration: none; color:#212121' href='" + webURL + "/product-detail/" + item.ID + "' target='_blank' title='" + item.ProductName + "'>" + item.SKU + "</a></p>");
                    htmlContent.AppendLine(@"<p>" + Math.Round(item.Volume, 3) + " CBM</p>");
                    htmlContent.AppendLine(@"<p>" + item.Quantity + " x " + (dealer != null ? item.WholesalePriceList.DealerPrice.Price : item.WholesalePriceList.DesignerPrice.Price) + " = " + item.ItemTotal.ToString("C0") + "</p>");
                    htmlContent.AppendLine(@"<p>Availability: " + item.Availability + "</p>");
                    htmlContent.AppendLine(@"</td>");
                    htmlContent.AppendLine(@"</tr>");
                    htmlContent.AppendLine(@"</table>");
                    htmlContent.AppendLine(@"</td>");
                    htmlContent.AppendLine(@"</tr>");

                    TA.Data2021.Models.ShoppingCart_Item shoppingCart_Item = new TA.Data2021.Models.ShoppingCart_Item();
                    shoppingCart_Item.URL = webURL + "/product-detail/" + item.ID;
                    shoppingCart_Item.ImageURL = sirvProductPhotos + "/" + item.SKU.Substring(0, 3) + "/" + item.SKU + "_main_1.jpg?w=200&h=200";
                    shoppingCart_Item.Availability = item.Availability;
                    shoppingCart_Item.ProductName = item.ProductName;
                    shoppingCart_Item.SKU = item.SKU;
                    shoppingCart_Item.ShoppingCart_ID = orderedOrderInfos.ShoppingCartId;
                    shoppingCart_Item.Item_ID = item.ID;
                    shoppingCart_Item.Volume = Math.Round(item.Volume, 3);
                    shoppingCart_Item.Quantity = item.Quantity;
                    shoppingCart_Item.Price = (dealer != null ? item.WholesalePriceList.DealerPrice.Price : item.WholesalePriceList.DesignerPrice.Price);
                    shoppingCart_Item.ItemTotal = item.ItemTotal;
                    shoppingCart_Item.DealerPrice = item.WholesalePriceList.DealerPrice.Price;
                    shoppingCart_Item.DesignerPrice = item.WholesalePriceList.DesignerPrice.Price;
                    listShoppingCart_Item.Add(shoppingCart_Item);
                }

                htmlContent.AppendLine(@"</table>");
                htmlContent.AppendLine(@"<table cellpadding='0' cellspacing='0' border='0' width='100%' height='20'>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td></td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"</table>");
                htmlContent.AppendLine(@"<table cellpadding='0' cellspacing='0' border='0' style='margin: 0 auto; height: auto; max-width:450px' align='center' class='MainContainer'>");
                htmlContent.AppendLine(@"<tr align='center'>");
                htmlContent.AppendLine(@"<td colspan='6' class='follow-us-lable' style='margin: 0 auto; width:50%; text-transform:uppercase; padding:15px 0 15px 0; font-size:13px;'>");
                htmlContent.AppendLine(@"Follow us on Social");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td align='center'>");
                htmlContent.AppendLine(@"<a href='https://www.instagram.com/theodore_alexander_official' target= '_blank' title= 'instagram'>");
                htmlContent.AppendLine(@"<img style='margin: 0 2px 0 0' src='https://theodorealexander.sirv.com/website/Frontend/Live/assests/emailwishlist/instagram.png' width='25' height='25' title='instagram' alt='instagram'>");
                htmlContent.AppendLine(@"</a>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"<td align='center'>");
                htmlContent.AppendLine(@"<a href='https://www.facebook.com/TheoAlex' target='_blank' title='facebook'>");
                htmlContent.AppendLine(@"<img style='margin: 0 2px 0 0' src='https://theodorealexander.sirv.com/website/Frontend/Live/assests/emailwishlist/facebook.png' width='15' height='29' title='facebook' alt='facebook'>");
                htmlContent.AppendLine(@"</a>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"<td align='center'>");
                htmlContent.AppendLine(@"<a href='https://www.youtube.com/channel/UC1nO0CpfCMquPW05mTv5R4A' target='_blank' title='youtube'>");
                htmlContent.AppendLine(@"<img style='margin: 0 2px 0 0' src='https://theodorealexander.sirv.com/website/Frontend/Live/assests/emailwishlist/youtube.png' width='31' height='21' title='youtube' alt='youtube'>");
                htmlContent.AppendLine(@"</a>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"<td align='center'>");
                htmlContent.AppendLine(@"<a href='https://twitter.com/theoalex' target='_blank' title='twitter'>");
                htmlContent.AppendLine(@"<img style='margin: 0 2px 0 0' src='https://theodorealexander.sirv.com/website/Frontend/Live/assests/emailwishlist/twitter.png' width='28' height='23' title='twitter' alt='twitter'>");
                htmlContent.AppendLine(@"</a>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"<td align='center'>");
                htmlContent.AppendLine(@"<a href='https://id.pinterest.com/theodore_alexander/' target='_blank' title='pinterest'>");
                htmlContent.AppendLine(@"<img style='margin: 0 2px 0 0' src='https://theodorealexander.sirv.com/website/Frontend/Live/assests/emailwishlist/pinterest.png' width='21' height='27' title='pinterest' alt='pinterest'>");
                htmlContent.AppendLine(@"</a>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"<td align='center'>");
                htmlContent.AppendLine(@"<a href='https://www.linkedin.com/company/theodore-alexander' target='_blank' title='linkedin'>");
                htmlContent.AppendLine(@"<img style='margin: 0 2px 0 0' src='https://theodorealexander.sirv.com/website/Frontend/Live/assests/emailwishlist/linkedIn.png' width='25' height='25' title='linkedin' alt='linkedin'>");
                htmlContent.AppendLine(@"</a>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"</table>");
                htmlContent.AppendLine(@"<table cellpadding= '0' cellspacing='0' border='0' style='margin: 0 auto; max-width:600px; padding:20px 0' align='center' class='MainContainer'>");
                htmlContent.AppendLine(@"<tr>");
                htmlContent.AppendLine(@"<td colspan='6' align='center' style='color:#636363; font-size:13px;'>");
                htmlContent.AppendLine(@"Theodore Alexander, one of the finest furniture brands in the world.");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"</table>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"</table>");
                htmlContent.AppendLine(@"</td>");
                htmlContent.AppendLine(@"</tr>");
                htmlContent.AppendLine(@"</table>");
                htmlContent.AppendLine(@"</body>");

                emailContent = htmlContent.ToString();
                string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                string emailTo = ConfigurationManager.AppSettings["TradeEnquiryEmailTo"];

                string mailDisplay = "Theodore Alexander";
                string mailTitle = "Order code #" + orderCode + " by " + user.Email + " at " + orderedOrderInfos.OrderDate;
                StringBuilder sendMailResult = new StringBuilder();
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, user.Email, user.Email, mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: " + user.Email);
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: " + user.Email);
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "info@theodorealexander.com", "info@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: info@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: info@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "csd_taus@theodorealexander.com", "csd_taus@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: csd_taus@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: csd_taus@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "csd@theodorealexander.com", "csd@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: csd@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: csd@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "kmullen@theodorealexander.com", "kmullen@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: kmullen@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: kmullen@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "lrogers@theodorealexander.com", "lrogers@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: lrogers@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: lrogers@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "mtaylor@theodorealexander.com", "mtaylor@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: mtaylor@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: mtaylor@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "sholt@theodorealexander.com", "sholt@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: sholt@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: sholt@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "shaire@theodorealexander.com", "shaire@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: shaire@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: shaire@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "wjohan@theodorealexander.com", "wjohan@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: wjohan@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: wjohan@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "ludan@theodorealexander.com", "ludan@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: ludan@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: ludan@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                try
                {
                    await Helper.SendMail(mailDisplay, emailFrom, "ltson@theodorealexander.com", "ltson@theodorealexander.com", mailTitle, emailContent);
                    sendMailResult.AppendLine(@"Success: ltson@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                    sendMailResult.AppendLine(@"Not Success: ltson@theodorealexander.com");
                    sendMailResult.AppendLine(@"<br/>");
                }
                var sendMailResultBoolean = true;
                try
                {
                    sendMailResultBoolean = await Helper.SendMail(mailDisplay, emailFrom, "ltson@theodorealexander.com", "ltson@theodorealexander.com", mailTitle + " - Result", sendMailResult.ToString());
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                }
                return sendMailResultBoolean;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private async Task<string> SendOrderEmail2021Version002(BL.DTO.OrderDto orderedOrderInfos, UserViewModel user, Dealer dealer = null)
        {
            string result = TA.Helpers2021.AppGlobal.InitializationString;
            try
            {
                string sirvProductPhotos = ConfigurationManager.AppSettings["SirvProductPhoto"];
                string webURL = ConfigurationManager.AppSettings["WebURL"];
                string emailContent = String.Empty;
                string orderCode = orderedOrderInfos.OrderDate.ToString("yyyyMMdd") + orderedOrderInfos.OrderDate.Hour + orderedOrderInfos.OrderDate.Minute + "_" + user.Firstname.Replace(@" ", @"") + user.Lastname.Replace(@" ", @"");

                TA.Data2021.Models.ShoppingCart shoppingCart = new TA.Data2021.Models.ShoppingCart();
                shoppingCart.Code = orderCode;
                shoppingCart.OrderDate = orderedOrderInfos.OrderDate;
                if (orderedOrderInfos.ShoppingCartInfos != null)
                {
                    try
                    {
                        if (orderedOrderInfos.ShoppingCartInfos.Count != null)
                        {
                            shoppingCart.ItemCount = orderedOrderInfos.ShoppingCartInfos.Count;
                        }
                        if (orderedOrderInfos.ShoppingCartInfos.Total != null)
                        {
                            shoppingCart.Total = Double.Parse(orderedOrderInfos.ShoppingCartInfos.Total).ToString("C0");
                        }
                        if (orderedOrderInfos.ShoppingCartInfos.Volume != null)
                        {
                            shoppingCart.Volume = orderedOrderInfos.ShoppingCartInfos.Volume;
                        }
                    }
                    catch (Exception e)
                    {
                        string mes01 = e.Message;
                    }
                }
                shoppingCart.FirstName = user.Firstname;
                shoppingCart.LastName = user.Lastname;
                try
                {
                    shoppingCart.CBMTotal = decimal.Parse(shoppingCart.Volume);
                    shoppingCart.PriceTotal = decimal.Parse(shoppingCart.Total);
                    shoppingCart.ItemTotal = int.Parse(shoppingCart.ItemCount);
                }
                catch (Exception e)
                {
                    string mes01 = e.Message;
                }
                if (dealer != null)
                {
                    shoppingCart.StoreName = (dealer.Stores.FirstOrDefault() != null ? dealer.Stores.FirstOrDefault().Name : "");
                }
                shoppingCart.UserName = user.Username;
                shoppingCart.UserTypeName = user.UserTypeName;
                shoppingCart.UserID = user.ID;
                shoppingCart.ShippingDate = String.Join("<br/>", orderedOrderInfos.ShippingDate);
                shoppingCart.Email = user.Email;
                shoppingCart.UserName = user.Username;
                shoppingCart.BillingAddressString = orderedOrderInfos.BillingAddressString;
                shoppingCart.ShippingAddressString = orderedOrderInfos.ShippingAddressString;
                shoppingCart.StoreID = orderedOrderInfos.StoreID;
                shoppingCart.TausID = orderedOrderInfos.TausID;
                shoppingCart.ContainerReference = orderedOrderInfos.ContainerReference;
                shoppingCart.SpecialInstruction = orderedOrderInfos.SpecialInstruction;
                shoppingCart.ID = orderedOrderInfos.ShoppingCartId;
                if (orderedOrderInfos.ShoppingCartInfos != null)
                {
                    if (orderedOrderInfos.ShoppingCartInfos.LstItem != null)
                    {
                        List<TA.Data2021.Models.ShoppingCart_Item> listShoppingCart_Item = new List<TA.Data2021.Models.ShoppingCart_Item>();
                        foreach (var item in orderedOrderInfos.ShoppingCartInfos.LstItem)
                        {
                            TA.Data2021.Models.ShoppingCart_Item shoppingCart_Item = new TA.Data2021.Models.ShoppingCart_Item();
                            shoppingCart_Item.URL = webURL + "/product-detail/" + item.ID;
                            shoppingCart_Item.ImageURL = sirvProductPhotos + "/" + item.SKU.Substring(0, 3) + "/" + item.SKU + "_main_1.jpg";
                            shoppingCart_Item.Availability = item.Availability;
                            shoppingCart_Item.ProductName = item.ProductName;
                            shoppingCart_Item.SKU = item.SKU;
                            shoppingCart_Item.ShoppingCart_ID = orderedOrderInfos.ShoppingCartId;
                            shoppingCart_Item.Item_ID = item.ID;
                            shoppingCart_Item.Volume = Math.Round(item.Volume, 3);
                            shoppingCart_Item.Quantity = item.Quantity;
                            shoppingCart_Item.ItemTotal = item.ItemTotal;
                            shoppingCart_Item.DealerPrice = item.WholesalePriceList.DealerPrice.Price;
                            shoppingCart_Item.DesignerPrice = item.WholesalePriceList.DesignerPrice.Price;
                            _shoppingCart_ItemRepository.UpdateBySQL(shoppingCart_Item);
                        }
                    }
                }
                shoppingCart.IsActive = true;
                result = _shoppingCartRepository.UpdateBySQL(shoppingCart);
                shoppingCart = _shoppingCartRepository.GetByID(shoppingCart.ID.ToString());
                string shoppingCartAPIURL = TA.Helpers2021.AppGlobal.APIDEV + "Email/AsyncSendNotUserNameAndPasswordByShoppingCartObject";
                var content001 = new StringContent(JsonConvert.SerializeObject(shoppingCart), Encoding.UTF8, "application/json");
                HttpClient client001 = new HttpClient();
                var task001 = client001.PostAsync(shoppingCartAPIURL, content001);
                await task001.Result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}

