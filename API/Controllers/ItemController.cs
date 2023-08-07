using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class ItemController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository, IWebHostEnvironment webHostEnvironment) : base()
        {
            _webHostEnvironment = webHostEnvironment;
            _itemRepository = itemRepository;
            Initialization();
        }
        [HttpPost]
        public int Add(Item item)
        {
            var result = _itemRepository.Add(item);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(Item item)
        {
            var result = await _itemRepository.AsyncAdd(item);
            return result;
        }
        [HttpPost]
        public int AddRange(List<Item> list)
        {
            var result = _itemRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<Item> list)
        {
            var result = await _itemRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(Item item)
        {
            var result = _itemRepository.Update(item);
            return result;
        }
        [HttpPut]
        public int UpdateBySQL(Item item)
        {
            var result = _itemRepository.UpdateBySQL(item);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(Item item)
        {
            var result = await _itemRepository.AsyncUpdate(item);
            return result;
        }

        [HttpDelete]
        public int RemoveRange(List<Item> list)
        {
            var result = _itemRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<Item> list)
        {
            var result = await _itemRepository.AsyncRemoveRange(list);
            return result;
        }
        [HttpGet]
        public List<Item> GetAllToList()
        {
            var result = _itemRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<Item>> AsyncGetAllToList()
        {
            var result = await _itemRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<Item> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _itemRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<Item>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _itemRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public int UpdateItemsURLCode()
        {
            var result = _itemRepository.UpdateItemsURLCode();
            return result;
        }
        [HttpGet]
        public int UpdateItemsDescription()
        {
            var result = _itemRepository.UpdateItemsDescription();
            return result;
        }
        [HttpGet]
        public int UpdateItemsImageCount()
        {
            var result = _itemRepository.UpdateItemsImageCount();
            return result;
        }
        [HttpGet]
        public Item GetByID(string ID)
        {
            Item result = new Item();
            Guid guidID = new Guid();
            try
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    ID = ID.Split('.')[0];
                    ID = ID.Split('/')[ID.Split('/').Length - 1];
                    guidID = new Guid(ID);
                    result = _itemRepository.GetByID(guidID);
                }
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public Item GetByURLCode(string URLCode)
        {
            Item result = new Item();
            try
            {
                if (!string.IsNullOrEmpty(URLCode))
                {
                    URLCode = URLCode.Split('.')[0];
                    URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                    result = _itemRepository.GetByURLCode(URLCode);
                    if (string.IsNullOrEmpty(result.SKU))
                    {
                        Guid ID = new Guid(URLCode);
                        result = _itemRepository.GetByID(ID);
                    }
                }
            }
            catch
            {
            }
            return result;
        }
        [HttpGet]
        public Guid GetIDByURLCode(string URLCode)
        {
            Item result = new Item();
            try
            {
                if (!string.IsNullOrEmpty(URLCode))
                {
                    URLCode = URLCode.Split('.')[0];
                    URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                    result = _itemRepository.GetByURLCode(URLCode);
                }
            }
            catch
            {
            }
            return result.ID;
        }
        [HttpGet]
        public List<Item> GetByIDListToList(string IDList)
        {
            List<Item> result = _itemRepository.GetByIDListToList(IDList);
            return result;
        }
        [HttpGet]
        public List<Item> GetBySKUListToList(string SKUList)
        {
            List<Item> result = _itemRepository.GetBySKUListToList(SKUList);
            return result;
        }

        [HttpPost]
        public List<Item> PostBySKUListToList()
        {
            List<Item> result = new List<Item>();
            Item item = JsonConvert.DeserializeObject<Item>(Request.Form["data"]);
            if (!string.IsNullOrEmpty(item.SKU))
            {
                result = _itemRepository.GetBySKUListToList(item.SKU);
            }
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            var result = _itemRepository.GetDataTransferBySearchStringToList(searchString);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByRowNumberToList(int rowNumber)
        {
            var result = _itemRepository.GetDataTransferByRowNumberToList(rowNumber);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(bool extending, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(IsActiveTAUS, extending, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public int GetItemCountByIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(bool isActiveTAUS, bool extending, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(isActiveTAUS, extending, inStockProgram, isStocked).Count;
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(string collection_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(IsActiveTAUS, collection_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(string shape_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(IsActiveTAUS, shape_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(string lifeStyle_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(IsActiveTAUS, lifeStyle_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(bool isActiveTAUS, string type_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(isActiveTAUS, type_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(string roomAndUsage_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(IsActiveTAUS, roomAndUsage_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(string brand_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(IsActiveTAUS, brand_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(string searchString, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            try
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.Split('.')[0];
                    searchString = searchString.Split('/')[searchString.Split('/').Length - 1];
                    result = _itemRepository.GetDataTransferByIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(IsActiveTAUS, searchString, inStockProgram, isStocked);
                }
            }
            catch
            {
            }
            return result;
        }

        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string type_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(user_ID, isActiveTAUS, type_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string shape_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(user_ID, isActiveTAUS, shape_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(user_ID, isActiveTAUS, roomAndUsage_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(user_ID, isActiveTAUS, lifeStyle_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string collection_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(user_ID, isActiveTAUS, collection_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string brand_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(user_ID, isActiveTAUS, brand_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool extending, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(user_ID, isActiveTAUS, extending, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string searchString, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(user_ID, isActiveTAUS, searchString, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndRegionAndIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(string user_ID, string region, string searchString, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(user_ID, InitializationIsActiveTAUS(user_ID, region), searchString, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndRegionAndIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(string user_ID, string region, bool extending, bool inStockProgram, bool isStocked)
        {

            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(user_ID, InitializationIsActiveTAUS(user_ID, region), extending, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndRegionAndIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(string user_ID, string region, string type_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(user_ID, InitializationIsActiveTAUS(user_ID, region), type_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndRegionAndIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(string user_ID, string region, string shape_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(user_ID, InitializationIsActiveTAUS(user_ID, region), shape_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndRegionAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(string user_ID, string region, string roomAndUsage_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(user_ID, InitializationIsActiveTAUS(user_ID, region), roomAndUsage_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndRegionAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(string user_ID, string region, string lifeStyle_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(user_ID, InitializationIsActiveTAUS(user_ID, region), lifeStyle_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndRegionAndIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(string user_ID, string region, string collection_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(user_ID, InitializationIsActiveTAUS(user_ID, region), collection_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndRegionAndIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(string user_ID, string region, string brand_ID, bool inStockProgram, bool isStocked)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(user_ID, InitializationIsActiveTAUS(user_ID, region), brand_ID, inStockProgram, isStocked);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked, bool isCFPItem, bool isNew)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(user_ID, isActiveTAUS, room_IDList, brand_IDList, type_IDList, shape_IDList, style_IDList, lifeStyle_IDList, collection_IDList, designer_IDList, searchString, extending, isStocked, isCFPItem, isNew);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndFilters002ToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked, bool isCFPItem, bool isNew, bool isBestSeller)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndFilters002ToList(user_ID, isActiveTAUS, room_IDList, brand_IDList, type_IDList, shape_IDList, style_IDList, lifeStyle_IDList, collection_IDList, designer_IDList, searchString, extending, isStocked, isCFPItem, isNew, isBestSeller);
            return result;
        }
        [HttpGet]
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndFilters001ToList(bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString)
        {
            var result = _itemRepository.GetDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(AppGlobal.InitializationString, isActiveTAUS, room_IDList, brand_IDList, type_IDList, shape_IDList, style_IDList, lifeStyle_IDList, collection_IDList, designer_IDList, searchString, false, false, false, false);
            return result;
        }
        [HttpGet]
        public async Task<string> AsyncGetByConectionStringAndIsActiveWithImageCountIsNullToList()
        {
            string itemPath = "Item";
            string ftpUrl = AppGlobal.InitializationString;
            FtpWebRequest requestLIVEFTP;
            byte[] fileContents;
            List<Item> list = _itemRepository.GetConectionStringByIsActiveWithImageCountIsNullToList(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE);
            foreach (Item item in list)
            {
                string fileName = item.ImageSirv;
                fileName = fileName.Split('/')[fileName.Split('/').Length - 1];
                if (!string.IsNullOrEmpty(fileName))
                {
                    item.ProductName = item.ProductName.Trim();
                    item.ProductName = item.ProductName.Replace(@"  ", "");
                    item.ProductName = item.ProductName.Replace(@"   ", " ");
                    item.URLCode = AppGlobal.SetName(item.ProductName) + "-" + AppGlobal.SetName(item.SKU);
                    fileName = item.SKU + "_main_1." + fileName.Split('.')[fileName.Split('.').Length - 1];
                    string subPath = AppGlobal.Images + @"\" + itemPath;
                    var physicalPathCreate = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
                    using (WebClient client = new WebClient())
                    {
                        try
                        {
                            client.DownloadFile(new Uri(item.ImageSirv), physicalPathCreate);
                            item.IsDownloadImageSirv = true;
                            item.Image = AppGlobal.DomainURLLIVE + AppGlobal.Images + @"/" + itemPath + @"/" + fileName;
                            await _itemRepository.AsyncUpdateBySQLAndConectionStringByIDWithImageIsNull(item, AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE);
                            using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(physicalPathCreate))
                            {
                                image.Mutate(x => x.Resize(AppGlobal.ImageWidth, AppGlobal.ImageHeight));
                                image.Save(physicalPathCreate);

                                ftpUrl = AppGlobal.LIVEFTP + AppGlobal.Images + @"/" + itemPath + @"/" + fileName;
                                requestLIVEFTP = (FtpWebRequest)WebRequest.Create(ftpUrl);
                                requestLIVEFTP.Method = WebRequestMethods.Ftp.UploadFile;
                                requestLIVEFTP.Credentials = new NetworkCredential(AppGlobal.LIVEFTPUserName, AppGlobal.LIVEFTPPassword);
                                fileContents = System.IO.File.ReadAllBytes(physicalPathCreate);
                                requestLIVEFTP.ContentLength = fileContents.Length;
                                using (Stream requestStream = requestLIVEFTP.GetRequestStream())
                                {
                                    requestStream.Write(fileContents, 0, fileContents.Length);
                                }
                            }

                        }
                        catch (Exception e)
                        {
                            string mes = e.Message;
                        }
                    }
                }
            }
            return AppGlobal.InitializationDateTimeCode;
        }

        [HttpGet]
        public async Task<string> AsyncDownloadAllImages()
        {
            string itemPath = "Item";
            string ftpUrl = AppGlobal.InitializationString;
            FtpWebRequest requestLIVEFTP;
            byte[] fileContents;
            List<Item> list = await _itemRepository.AsyncGetByActiveAndConectionStringToList(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE);
            foreach (Item item in list)
            {
                WebRequest webRequest = WebRequest.Create(item.Image);
                WebResponse webResponse;
                try
                {
                    webResponse = webRequest.GetResponse();
                }
                catch
                {
                    if ((!string.IsNullOrEmpty(item.ImageSirv)) && (!string.IsNullOrEmpty(item.Image)))
                    {
                        string fileName = item.Image.Split('/')[item.Image.Split('/').Length - 1];
                        string subPath = AppGlobal.Images + @"\" + itemPath;
                        var physicalPathCreate = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
                        using (WebClient client = new WebClient())
                        {
                            try
                            {
                                client.DownloadFile(new Uri(item.ImageSirv), physicalPathCreate);
                                using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(physicalPathCreate))
                                {
                                    image.Mutate(x => x.Resize(AppGlobal.ImageWidth, AppGlobal.ImageHeight));
                                    image.Save(physicalPathCreate);

                                    ftpUrl = AppGlobal.LIVEFTP + AppGlobal.Images + @"/" + itemPath + @"/" + fileName;
                                    requestLIVEFTP = (FtpWebRequest)WebRequest.Create(ftpUrl);
                                    requestLIVEFTP.Method = WebRequestMethods.Ftp.UploadFile;
                                    requestLIVEFTP.Credentials = new NetworkCredential(AppGlobal.LIVEFTPUserName, AppGlobal.LIVEFTPPassword);
                                    fileContents = System.IO.File.ReadAllBytes(physicalPathCreate);
                                    requestLIVEFTP.ContentLength = fileContents.Length;
                                    using (Stream requestStream = requestLIVEFTP.GetRequestStream())
                                    {
                                        requestStream.Write(fileContents, 0, fileContents.Length);
                                    }
                                }

                            }
                            catch (Exception e)
                            {
                                string mes = e.Message;
                            }
                        }
                    }
                }
            }
            return AppGlobal.InitializationDateTimeCode;
        }

        [HttpPost]
        public JsonResult DownloadImagesByURLList()
        {
            string result = AppGlobal.InitializationString;
            try
            {
                string itemPath = "Item";
                string ftpUrl = AppGlobal.InitializationString;
                FtpWebRequest requestLIVEFTP;
                byte[] fileContents;
                string uRLList = JsonConvert.DeserializeObject<string>(Request.Form["data"]);
                int count = uRLList.Split(' ').Length;
                for (int j = 0; j < count; j++)
                {
                    string uRL = uRLList.Split(' ')[j];
                    uRL = uRL.Split('/')[uRL.Split('/').Length - 1];                    
                    string fileName = uRL.Split('/')[uRL.Split('/').Length - 1];
                    string subPath = AppGlobal.Images + @"\" + itemPath;
                    var physicalPathCreate = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
                    string imageSirv = "https://theodorealexander.sirv.com/ProductPhotos/" + fileName.Substring(0, 3) + "/" + fileName;
                    using (WebClient client = new WebClient())
                    {
                        try
                        {
                            client.DownloadFile(new Uri(imageSirv), physicalPathCreate);
                            using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(physicalPathCreate))
                            {
                                image.Mutate(x => x.Resize(AppGlobal.ImageWidth, AppGlobal.ImageHeight));
                                image.Save(physicalPathCreate);

                                ftpUrl = AppGlobal.LIVEFTP + AppGlobal.Images + @"/" + itemPath + @"/" + fileName;
                                requestLIVEFTP = (FtpWebRequest)WebRequest.Create(ftpUrl);
                                requestLIVEFTP.Method = WebRequestMethods.Ftp.UploadFile;
                                requestLIVEFTP.Credentials = new NetworkCredential(AppGlobal.LIVEFTPUserName, AppGlobal.LIVEFTPPassword);
                                fileContents = System.IO.File.ReadAllBytes(physicalPathCreate);
                                requestLIVEFTP.ContentLength = fileContents.Length;
                                using (Stream requestStream = requestLIVEFTP.GetRequestStream())
                                {
                                    requestStream.Write(fileContents, 0, fileContents.Length);
                                }
                            }

                        }
                        catch (Exception e)
                        {
                            string mes = e.Message;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return Json(result);
        }

        [HttpGet]
        public string GetByConectionStringAndIsActiveWithImageIsNullToList()
        {
            string itemPath = "Item";
            string ftpUrl = AppGlobal.InitializationString;
            FtpWebRequest requestLIVEFTP;
            byte[] fileContents;
            List<Item> list = _itemRepository.GetByActiveAndConectionStringToList(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE);
            foreach (Item item in list)
            {
                string fileName = item.ImageSirv;
                fileName = fileName.Split('/')[fileName.Split('/').Length - 1];
                if (!string.IsNullOrEmpty(fileName))
                {
                    fileName = item.SKU + "_main_1." + fileName.Split('.')[fileName.Split('.').Length - 1];
                    string subPath = AppGlobal.Images + @"\" + itemPath;
                    var physicalPathCreate = Path.Combine(AppGlobal.APILIVEWebRootPath, subPath, fileName);
                    using (WebClient client = new WebClient())
                    {
                        try
                        {
                            client.DownloadFile(new Uri(item.ImageSirv), physicalPathCreate);
                            item.IsDownloadImageSirv = true;
                            item.Image = AppGlobal.DomainURLLIVE + AppGlobal.Images + @"/" + itemPath + @"/" + fileName;
                            using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(physicalPathCreate))
                            {
                                image.Mutate(x => x.Resize(AppGlobal.ImageWidth, AppGlobal.ImageHeight));
                                image.Save(physicalPathCreate);
                                ftpUrl = AppGlobal.LIVEFTP + AppGlobal.Images + @"/" + itemPath + @"/" + fileName;
                                requestLIVEFTP = (FtpWebRequest)WebRequest.Create(ftpUrl);
                                requestLIVEFTP.Method = WebRequestMethods.Ftp.UploadFile;
                                requestLIVEFTP.Credentials = new NetworkCredential(AppGlobal.LIVEFTPUserName, AppGlobal.LIVEFTPPassword);
                                fileContents = System.IO.File.ReadAllBytes(physicalPathCreate);
                                requestLIVEFTP.ContentLength = fileContents.Length;
                                using (Stream requestStream = requestLIVEFTP.GetRequestStream())
                                {
                                    requestStream.Write(fileContents, 0, fileContents.Length);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            string mes = e.Message;
                        }
                    }
                }
            }

            //string fileName = "_main_1.jpg";
            //string subPath = AppGlobal.Images + @"\" + itemPath;
            //var physicalPathCreate = Path.Combine(AppGlobal.APILIVEWebRootPath, subPath, fileName);
            //using (WebClient client = new WebClient())
            //{
            //    try
            //    {
            //        client.DownloadFile(new Uri("https://theodorealexander.com/images/item/U7075K_main_1.jpg"), physicalPathCreate);
            //        using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(physicalPathCreate))
            //        {
            //            image.Mutate(x => x.Resize(AppGlobal.ImageWidth, AppGlobal.ImageHeight));
            //            image.Save(physicalPathCreate);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        string mes = e.Message;
            //    }
            //}

            return AppGlobal.InitializationDateTimeCode;
        }
        private void Initialization()
        {
            //_itemRepository.UpdateItemsURLCode();
            //_itemRepository.UpdateItemsDescription();
            //DownloadItemImagesWithImageIsNull();
        }
        private bool InitializationIsActiveTAUS(string user_ID, string region)
        {
            bool isActiveTAUS = false;
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(region))
            {
                if (region == AppGlobal.InitializationRegion)
                {
                    isActiveTAUS = true;
                }
            }
            return isActiveTAUS;
        }
        private void DownloadItemImagesWithImageIsNull()
        {
            string result = AppGlobal.InitializationString;
            List<Item> list = _itemRepository.GetWithImageIsNullToList();
            bool isDownload = false;
            foreach (Item item in list)
            {
                string fileName = item.ImageSirv;
                fileName = fileName.Split('/')[fileName.Split('/').Length - 1];
                if (!string.IsNullOrEmpty(fileName))
                {
                    string subPath = AppGlobal.Images + @"\Item";
                    var physicalPathCreate = Path.Combine(_webHostEnvironment.WebRootPath, subPath, fileName);
                    using (WebClient client = new WebClient())
                    {
                        try
                        {
                            client.DownloadFile(new Uri(item.ImageSirv), physicalPathCreate);
                            isDownload = true;
                            item.IsDownloadImageSirv = true;
                            item.Image = fileName;
                            _itemRepository.UpdateBySQL(item);
                            if (isDownload == true)
                            {
                                //using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(physicalPathCreate))
                                //{
                                //    image.Mutate(x => x.Resize(AppGlobal.ImageWidth, AppGlobal.ImageHeight));
                                //    image.SaveAsync(physicalPathCreate);
                                //}
                            }
                        }
                        catch (Exception e)
                        {
                            result = e.Message;
                            isDownload = false;
                        }
                    }
                }
            }
        }
    }
}
