using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly TheodoreAlexander_NewContext _context;

        public ItemRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(Item model)
        {
            model.ProductName = model.ProductName.Trim();
            model.ProductName = model.ProductName.Replace(@"  ", "");
            model.ProductName = model.ProductName.Replace(@"   ", " ");
            if (string.IsNullOrEmpty(model.URLCode))
            {
                model.URLCode = AppGlobal.SetName(model.ProductName) + "-" + AppGlobal.SetName(model.SKU);
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = Regex.Replace(model.ExtendedDescription, "<.*?>", String.Empty);
            }
            if (string.IsNullOrEmpty(model.METAKeyword))
            {
                model.METAKeyword = model.ProductName + ", " + model.SKU;
            }
            if (string.IsNullOrEmpty(model.METADescription))
            {
                model.METADescription = model.Description;
            }
            if (model.INCHSideAndFrontRailApronClearance == null)
            {
                model.INCHSideAndFrontRailApronClearance = model.CMSideAndFrontRailApronClearance / AppGlobal.CMToINCH;
            }
            if (model.INCHSlatToTopOfSideRailClearance == null)
            {
                model.INCHSlatToTopOfSideRailClearance = model.CMSlatToTopOfSideRailClearance / AppGlobal.CMToINCH;
            }
            if (model.INCHSlatToTopOfFootRailClearance == null)
            {
                model.INCHSlatToTopOfFootRailClearance = model.CMSlatToTopOfFootRailClearance / AppGlobal.CMToINCH;
            }
            if (model.SketchImage == null)
            {
                string sketchImage = AppGlobal.GenerateSketchImageURL(model.SKU);
                WebRequest webRequestSketchImage = WebRequest.Create(sketchImage);
                WebResponse webResponSesketchImage;
                try
                {
                    webResponSesketchImage = webRequestSketchImage.GetResponse();
                    model.SketchImage = sketchImage;
                }
                catch
                {
                }
            }
            if (model.SeatingPlanImage == null)
            {
                string seatingPlanImage = AppGlobal.GenerateSeatingPlanImageURL(model.SKU);
                WebRequest webRequestSketchImage = WebRequest.Create(seatingPlanImage);
                WebResponse webResponSesketchImage;
                try
                {
                    webResponSesketchImage = webRequestSketchImage.GetResponse();
                    model.SeatingPlanImage = seatingPlanImage;
                }
                catch
                {
                }
            }

            if (model.SeatingPlanPdf == null)
            {
                string seatingPlanPdf = AppGlobal.GenerateSeatingPlanPDFURL(model.SKU);
                WebRequest webRequestSketchImage = WebRequest.Create(seatingPlanPdf);
                WebResponse webResponSesketchImage;
                try
                {
                    webResponSesketchImage = webRequestSketchImage.GetResponse();
                    model.SeatingPlanPdf = seatingPlanPdf;
                }
                catch
                {
                }
            }
            if (model.ImageCount == null)
            {
                model.ImageCount = AppGlobal.InitializationNumber;
                int count = 1;
                bool check = true;
                while (check == true)
                {
                    string imageURL = AppGlobal.GenerateImageMoreURL(model.SKU, count);
                    WebRequest webRequest = WebRequest.Create(imageURL);
                    WebResponse webResponse;
                    try
                    {
                        webResponse = webRequest.GetResponse();
                        model.ImageCount = model.ImageCount + 1;
                        count = count + 1;
                    }
                    catch
                    {
                        check = false;
                    }
                }
            }
        }
        public async Task<string> AsyncInitialization(Item model)
        {
            model.ProductName = model.ProductName.Trim();
            model.ProductName = model.ProductName.Replace(@"  ", "");
            model.ProductName = model.ProductName.Replace(@"   ", " ");
            if (string.IsNullOrEmpty(model.URLCode))
            {
                model.URLCode = AppGlobal.SetName(model.ProductName) + "-" + AppGlobal.SetName(model.SKU);
                model.URLCode = model.URLCode.Replace(@" ", @"");
                model.URLCode = model.URLCode.Replace(@"  ", @"");
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = Regex.Replace(model.ExtendedDescription, "<.*?>", String.Empty);
            }
            if (string.IsNullOrEmpty(model.METAKeyword))
            {
                model.METAKeyword = model.ProductName + ", " + model.SKU;
            }
            if (string.IsNullOrEmpty(model.METADescription))
            {
                model.METADescription = model.Description;
            }
            if (model.INCHSideAndFrontRailApronClearance == null)
            {
                model.INCHSideAndFrontRailApronClearance = model.CMSideAndFrontRailApronClearance / AppGlobal.CMToINCH;
            }
            if (model.INCHSlatToTopOfSideRailClearance == null)
            {
                model.INCHSlatToTopOfSideRailClearance = model.CMSlatToTopOfSideRailClearance / AppGlobal.CMToINCH;
            }
            if (model.INCHSlatToTopOfFootRailClearance == null)
            {
                model.INCHSlatToTopOfFootRailClearance = model.CMSlatToTopOfFootRailClearance / AppGlobal.CMToINCH;
            }
            if (model.SketchImage == null)
            {
                string sketchImage = AppGlobal.GenerateSketchImageURL(model.SKU);
                WebRequest webRequestSketchImage = WebRequest.Create(sketchImage);
                WebResponse webResponSesketchImage;
                try
                {
                    webResponSesketchImage = await webRequestSketchImage.GetResponseAsync();
                    model.SketchImage = sketchImage;
                }
                catch
                {
                }
            }
            if (model.SeatingPlanImage == null)
            {
                string seatingPlanImage = AppGlobal.GenerateSeatingPlanImageURL(model.SKU);
                WebRequest webRequestSketchImage = WebRequest.Create(seatingPlanImage);
                WebResponse webResponSesketchImage;
                try
                {
                    webResponSesketchImage = await webRequestSketchImage.GetResponseAsync();
                    model.SeatingPlanImage = seatingPlanImage;
                }
                catch
                {
                }
            }

            if (model.SeatingPlanPdf == null)
            {
                string seatingPlanPdf = AppGlobal.GenerateSeatingPlanPDFURL(model.SKU);
                WebRequest webRequestSketchImage = WebRequest.Create(seatingPlanPdf);
                WebResponse webResponSesketchImage;
                try
                {
                    webResponSesketchImage = await webRequestSketchImage.GetResponseAsync();
                    model.SeatingPlanPdf = seatingPlanPdf;
                }
                catch
                {
                }
            }
            if (model.ImageCount == null)
            {
                model.ImageCount = AppGlobal.InitializationNumber;
                int count = 1;
                bool check = true;
                while (check == true)
                {
                    string imageURL = AppGlobal.GenerateImageMoreURL(model.SKU, count);
                    WebRequest webRequest = WebRequest.Create(imageURL);
                    WebResponse webResponse;
                    try
                    {
                        webResponse = await webRequest.GetResponseAsync();
                        model.ImageCount = model.ImageCount + 1;
                        count = count + 1;
                    }
                    catch
                    {
                        check = false;
                    }
                }
            }
            return "";
        }
        public async Task<string> AsyncInitializationWithImageIsNull(Item model)
        {
            model.ProductName = model.ProductName.Trim();
            model.ProductName = model.ProductName.Replace(@"  ", "");
            model.ProductName = model.ProductName.Replace(@"   ", " ");
            model.URLCode = AppGlobal.SetName(model.ProductName) + "-" + AppGlobal.SetName(model.SKU);
            model.Description = Regex.Replace(model.ExtendedDescription, "<.*?>", String.Empty);
            model.METAKeyword = model.ProductName + ", " + model.SKU;
            model.METADescription = model.Description;
            string sketchImage = AppGlobal.GenerateSketchImageURL(model.SKU);
            WebRequest webRequestSketchImage = WebRequest.Create(sketchImage);
            WebResponse webResponSesketchImage;
            try
            {
                webResponSesketchImage = await webRequestSketchImage.GetResponseAsync();
                model.SketchImage = sketchImage;
            }
            catch
            {
                model.SketchImage = null;
            }
            string seatingPlanImage = AppGlobal.GenerateSeatingPlanImageURL(model.SKU);
            WebRequest webRequestSeatingPlanImage = WebRequest.Create(seatingPlanImage);
            WebResponse webResponSeatingPlanImage;
            try
            {
                webResponSeatingPlanImage = await webRequestSeatingPlanImage.GetResponseAsync();
                model.SeatingPlanImage = seatingPlanImage;
            }
            catch
            {
                model.SeatingPlanImage = null;
            }
            string seatingPlanPdf = AppGlobal.GenerateSeatingPlanPDFURL(model.SKU);
            WebRequest webRequestSeatingPlanPdf = WebRequest.Create(seatingPlanPdf);
            WebResponse webResponSeatingPlanPdf;
            try
            {
                webResponSeatingPlanPdf = await webRequestSeatingPlanPdf.GetResponseAsync();
                model.SeatingPlanPdf = seatingPlanPdf;
            }
            catch
            {
                model.SeatingPlanPdf = null;
            }
            model.ImageCount = AppGlobal.InitializationNumber;
            int count = 1;
            bool check = true;
            while (check == true)
            {
                string imageURL = AppGlobal.GenerateImageMoreURL(model.SKU, count);
                WebRequest webRequest = WebRequest.Create(imageURL);
                WebResponse webResponse;
                try
                {
                    webResponse = await webRequest.GetResponseAsync();
                    model.ImageCount = model.ImageCount + 1;
                    count = count + 1;
                }
                catch
                {
                    check = false;
                }
            }
            return "";
        }
        //public int InsertBySQL(Item model)
        //{
        //    int result = AppGlobal.InitializationNumber;
        //    Initialization(model);
        //    SqlParameter[] parameters = InsertSingleItemByIDSqlParameter(model);
        //    string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemInsertSingleItemByID", parameters);
        //    return result;
        //}
        public int ItemInsertOrUpdateSingleItemBySQL(ItemDataTransfer model)
        {
            int result = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.SKU))
            {
                Initialization(model);
                SqlParameter[] parameters = InsertItemDataTransferSingleItemByIDSqlParameter(model);
                string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemInsertOrUpdateSingleItem", parameters);
            }
            return result;
        }
        public int UpdateSearchTable()
        {
            int result = AppGlobal.InitializationNumber;
            string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "usp_UpdateSearchTable");
            return result;
        }
        public int UpdateNewSearchTable()
        {
            int result = AppGlobal.InitializationNumber;
            string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "usp_UpdateNewSearchTable");
            return result;
        }
        public override int Update(Item model)
        {
            int result = AppGlobal.InitializationNumber;
            Item existModel = GetByID(model.ID);
            if (existModel != null)
            {
                existModel = model;
                Initialization(existModel);
                _context.Set<Item>().Update(existModel);
                result = _context.SaveChanges();
            }
            return result;
        }
        public int UpdateBySQL(Item model)
        {
            int result = AppGlobal.InitializationNumber;
            Initialization(model);
            SqlParameter[] parameters = UpdateSingleItemByIDSqlParameter(model);
            string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemUpdateSingleItemByID", parameters);
            return result;
        }

        public int UpdateBySQL001(Item model)
        {
            int result = AppGlobal.InitializationNumber;
            Initialization(model);
            SqlParameter[] parameters = UpdateSingleItemByIDSqlParameter(model);
            string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemUpdateSingleItemByID001", parameters);
            return result;
        }
        public async Task<int> AsyncUpdateBySQL001(Item model)
        {
            int result = AppGlobal.InitializationNumber;
            await AsyncInitialization(model);
            SqlParameter[] parameters = UpdateSingleItemByIDSqlParameter(model);
            string executeNonQuery = await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemUpdateSingleItemByID001", parameters);
            return result;
        }
        public int UpdateBedInfomationBySQL(Item model)
        {
            int result = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.SKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",model.SKU),
                    new SqlParameter("@CMSideAndFrontRailApronClearance",model.CMSideAndFrontRailApronClearance),
                    new SqlParameter("@CMSlatToTopOfSideRailClearance",model.CMSlatToTopOfSideRailClearance),
                    new SqlParameter("@CMSlatToTopOfFootRailClearance",model.CMSlatToTopOfFootRailClearance),
                };
                string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemUpdateBedInfomationSingleItemBySKU", parameters);
            }
            return result;
        }
        public int UpdateProductNameAndExtendedDescriptionBySQL(Item model)
        {
            int result = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.SKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",model.SKU),
                    new SqlParameter("@ProductName",model.ProductName),
                    new SqlParameter("@ExtendedDescription",model.ExtendedDescription),
                };
                string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemUpdateProductNameAndExtendedDescriptionSingleItemBySKU", parameters);
            }
            return result;
        }
        public int UpdateIsBestSellerBySQL(Item model)
        {
            int result = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.SKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",model.SKU),
                    new SqlParameter("@IsBestSeller",model.IsBestSeller),
                };
                string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemUpdateIsBestSellerSingleItemBySKU", parameters);
            }
            return result;
        }
        public int UpdateAdditionalFeaturesBySQL(Item model)
        {
            int result = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.SKU))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKU",model.SKU),
                    new SqlParameter("@AdditionalFeatures",model.AdditionalFeatures),
                };
                string executeNonQuery = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemUpdateAdditionalFeaturesSingleItemBySKU", parameters);
            }
            return result;
        }
        public int UpdateBySQLAndConectionString(Item model, string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            Initialization(model);
            SqlParameter[] parameters = UpdateSingleItemByIDSqlParameter(model);
            string executeNonQuery = SQLHelper.ExecuteNonQuery(conectionString, "sp_ItemUpdateSingleItemByID", parameters);
            return result;
        }
        public async Task<int> AsyncUpdateBySQL(Item model)
        {
            int result = AppGlobal.InitializationNumber;
            Initialization(model);
            SqlParameter[] parameters = UpdateSingleItemByIDSqlParameter(model);
            await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemUpdateSingleItemByID", parameters);
            return result;
        }
        public async Task<int> AsyncUpdateBySQLAndConectionString(Item model, string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            await AsyncInitialization(model);
            SqlParameter[] parameters = UpdateSingleItemByIDSqlParameter(model);
            await SQLHelper.ExecuteNonQueryAsync(conectionString, "sp_ItemUpdateSingleItemByID", parameters);
            return result;
        }
        public async Task<int> AsyncUpdateBySQLAndConectionString001(Item model, string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            await AsyncInitialization(model);
            SqlParameter[] parameters = UpdateSingleItemByIDSqlParameter001(model);
            await SQLHelper.ExecuteNonQueryAsync(conectionString, "sp_ItemUpdateSingleItemByID001", parameters);
            return result;
        }
        public async Task<int> AsyncUpdateBySQLAndConectionStringByIDWithImageIsNull(Item model, string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            await AsyncInitializationWithImageIsNull(model);
            SqlParameter[] parameters = SqlParameterByIDWithImageIsNull(model);
            string mes = await SQLHelper.ExecuteNonQueryAsync(conectionString, "sp_ItemUpdateSingleItemByIDWithImageIsNull", parameters);
            return result;
        }
        public async Task<int> AsyncUpdateBySQLAndConectionStringByIDWithImageIsNull001(Item model, string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
               new SqlParameter("@ID",model.ID),
                new SqlParameter("@Image",model.Image),
            };
            string mes = await SQLHelper.ExecuteNonQueryAsync(conectionString, "sp_ItemUpdateSingleItemByIDWithImageIsNull001", parameters);
            return result;
        }
        public async Task<int> AsyncUpdateItemsURLCodeByConectionString001(string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            List<Item> list = await AsyncGetByConectionStringWithURLCodeIsNull001ToList(conectionString);
            foreach (Item item in list)
            {
                await AsyncUpdateBySQLAndConectionString001(item, conectionString);
            }
            return result;
        }
        public async Task<int> AsyncUpdateItemsDescriptionByConectionString001(string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            List<Item> list = await AsyncGetByConectionStringWithDescriptionIsNull001ToList(conectionString);
            foreach (Item item in list)
            {
                await AsyncUpdateBySQLAndConectionString001(item, conectionString);
            }
            return result;
        }
        public async Task<int> AsyncUpdateItemsImageCountByConectionString001(string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            List<Item> list = await AsyncGetConectionStringWithImageCountIsNull001ToList(conectionString);
            foreach (Item item in list)
            {
                await AsyncUpdateBySQLAndConectionString001(item, conectionString);
            }
            return result;
        }
        public async Task<int> AsyncUpdateItemsImageByConectionString001(string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            List<Item> list = await AsyncGetByConectionStringWithImageIsNull001ToList(conectionString);
            foreach (Item item in list)
            {
                await AsyncUpdateBySQLAndConectionString001(item, conectionString);
            }
            return result;
        }
        public async Task<List<Item>> AsyncGetByConectionStringWithURLCodeIsNull001ToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = await SQLHelper.FillAsync(conectionString, "sp_ItemSelectItemsWithURLCodeIsNull001");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public async Task<List<Item>> AsyncGetByConectionStringWithDescriptionIsNull001ToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = await SQLHelper.FillAsync(conectionString, "sp_ItemSelectItemsWithDescriptionIsNull001");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public async Task<List<Item>> AsyncGetConectionStringWithImageCountIsNull001ToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = await SQLHelper.FillAsync(conectionString, "sp_ItemSelectItemsWithImageCountIsNull001");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public async Task<List<Item>> AsyncGetByConectionStringWithImageIsNull001ToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = await SQLHelper.FillAsync(conectionString, "sp_ItemSelectItemsWithImageIsNull001");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        private SqlParameter[] InsertItemDataTransferSingleItemByIDSqlParameter(ItemDataTransfer model)
        {
            SqlParameter[] parameters =
            {
               new SqlParameter("@SKU",model.SKU),
               new SqlParameter("@ProductName",model.ProductName),
               new SqlParameter("@Price",model.Price),
               new SqlParameter("@Story",model.Story),
               new SqlParameter("@VariationDescription",model.VariationDescription),
               new SqlParameter("@ExtendedDescription",model.ExtendedDescription),
               new SqlParameter("@AdditionalFeatures",model.AdditionalFeatures),
               new SqlParameter("@ParentCode",model.ParentCode),
               new SqlParameter("@DefaultCode",model.DefaultCode),
               new SqlParameter("@Keywords",model.Keywords),
               new SqlParameter("@HasOtherSizes",model.HasOtherSizes),
               new SqlParameter("@CBM",model.CBM),
               new SqlParameter("@Depth",model.Depth),
               new SqlParameter("@Width",model.Width),
               new SqlParameter("@Height",model.Height),
               new SqlParameter("@ChairSeatHeight",model.ChairSeatHeight),
               new SqlParameter("@ChairArmHeight",model.ChairArmHeight),
               new SqlParameter("@ChairInsideSeatDepth",model.ChairInsideSeatDepth),
               new SqlParameter("@ChairInsideSeatWidth",model.ChairInsideSeatWidth),               
               new SqlParameter("@TableClearance",model.TableClearance),
               new SqlParameter("@TableClosedDepth",model.TableClosedDepth),
               new SqlParameter("@TableClosedWidth",model.TableClosedWidth),
               new SqlParameter("@TableClosedHeight",model.TableClosedHeight),
               new SqlParameter("@TableLeavesCount",model.TableLeavesCount),
               new SqlParameter("@TableLeavesWidth",model.TableLeavesWidth),
               new SqlParameter("@TablesSeatsCountClosed",model.TablesSeatsCountClosed),
               new SqlParameter("@TablesSeatsCountOpen",model.TablesSeatsCountOpen),
               new SqlParameter("@IsBestSeller",model.IsBestSeller),
               new SqlParameter("@IsUpholsteredBack_WoodBack",model.IsUpholsteredBack_WoodBack),
               new SqlParameter("@Extending",model.Extending),
               new SqlParameter("@Nail",model.Nail),
               new SqlParameter("@UPHFinish",model.UPHFinish),
               new SqlParameter("@IsNew",model.IsNew),
               new SqlParameter("@QuantityMultiplier",model.QuantityMultiplier),
               new SqlParameter("@IntroductionDate",model.IntroductionDate),
               new SqlParameter("@IsActive",model.IsActive),
               new SqlParameter("@Shipping",model.Shipping),
               new SqlParameter("@URLCode",model.URLCode),
               new SqlParameter("@Image",model.Image),
               new SqlParameter("@ImageSirv",model.ImageSirv),
               new SqlParameter("@Description",model.Description),
               new SqlParameter("@METAKeyword",model.METAKeyword),
               new SqlParameter("@IsDownloadImageSirv",model.IsDownloadImageSirv),
               new SqlParameter("@ImageCount",model.ImageCount),
               new SqlParameter("@SketchImage",model.SketchImage),
               new SqlParameter("@SeatingPlanImage",model.SeatingPlanImage),
               new SqlParameter("@SeatingPlanPdf",model.SeatingPlanPdf),
               new SqlParameter("@CMSideAndFrontRailApronClearance",model.CMSideAndFrontRailApronClearance),
               new SqlParameter("@CMSlatToTopOfSideRailClearance",model.CMSlatToTopOfSideRailClearance),
               new SqlParameter("@CMSlatToTopOfFootRailClearance",model.CMSlatToTopOfFootRailClearance),
               new SqlParameter("@RoomAndUsageName",model.RoomAndUsageName),
               new SqlParameter("@TypeName",model.TypeName),
               new SqlParameter("@BrandName",model.BrandName),
               new SqlParameter("@DesignerName",model.DesignerName),
               new SqlParameter("@CollectionName",model.CollectionName),
               new SqlParameter("@LifeStyleName",model.LifeStyleName),
               new SqlParameter("@StyleName",model.StyleName),
               new SqlParameter("@PrimaryMaterialName",model.PrimaryMaterialName),
               new SqlParameter("@SecondaryMaterialName",model.SecondaryMaterialName),
               new SqlParameter("@TertiaryMaterialName",model.TertiaryMaterialName),
               new SqlParameter("@OptionGroupName",model.OptionGroupName),
               new SqlParameter("@OptionGroup2Name",model.OptionGroup2Name),
               new SqlParameter("@OptionGroup3Name",model.OptionGroup3Name),
               new SqlParameter("@MatchingArmOrSideName",model.MatchingArmOrSideName),               
            };
            return parameters;
        }
        private SqlParameter[] UpdateSingleItemByIDSqlParameter(Item model)
        {
            SqlParameter[] parameters =
            {
               new SqlParameter("@ID",model.ID),
               new SqlParameter("@SKU",model.SKU),
               new SqlParameter("@ProductName",model.ProductName),
               new SqlParameter("@Price",model.Price),
               new SqlParameter("@Story",model.Story),
               new SqlParameter("@VariationDescription",model.VariationDescription),
               new SqlParameter("@ExtendedDescription",model.ExtendedDescription),
               new SqlParameter("@AdditionalFeatures",model.AdditionalFeatures),
               new SqlParameter("@ParentCode",model.ParentCode),
               new SqlParameter("@DefaultCode",model.DefaultCode),
               new SqlParameter("@Designer_ID",model.Designer_ID),
               new SqlParameter("@LifeStyle_ID",model.LifeStyle_ID),
               new SqlParameter("@Style_ID",model.Style_ID),
               new SqlParameter("@Type_ID",model.Type_ID),
               new SqlParameter("@RoomAndUsage_ID",model.RoomAndUsage_ID),
               new SqlParameter("@Brand_ID",model.Brand_ID),
               new SqlParameter("@Collection_ID",model.Collection_ID),
               new SqlParameter("@PrimaryMaterial_ID",model.PrimaryMaterial_ID),
               new SqlParameter("@SecondaryMaterial_ID",model.SecondaryMaterial_ID),
               new SqlParameter("@TertiaryMaterial_ID",model.TertiaryMaterial_ID),
               new SqlParameter("@Keywords",model.Keywords),
               new SqlParameter("@OptionGroup_ID",model.OptionGroup_ID),
               new SqlParameter("@OptionGroup2_ID",model.OptionGroup2_ID),
               new SqlParameter("@OptionGroup3_ID",model.OptionGroup3_ID),
               new SqlParameter("@HasOtherSizes",model.HasOtherSizes),
               new SqlParameter("@CBM",model.CBM),
               new SqlParameter("@Depth",model.Depth),
               new SqlParameter("@Width",model.Width),
               new SqlParameter("@Height",model.Height),
               new SqlParameter("@ChairSeatHeight",model.ChairSeatHeight),
               new SqlParameter("@ChairArmHeight",model.ChairArmHeight),
               new SqlParameter("@ChairInsideSeatDepth",model.ChairInsideSeatDepth),
               new SqlParameter("@ChairInsideSeatWidth",model.ChairInsideSeatWidth),
               new SqlParameter("@MatchingArmOrSide",model.MatchingArmOrSide),
               new SqlParameter("@TableClearance",model.TableClearance),
               new SqlParameter("@TableClosedDepth",model.TableClosedDepth),
               new SqlParameter("@TableClosedWidth",model.TableClosedWidth),
               new SqlParameter("@TableClosedHeight",model.TableClosedHeight),
               new SqlParameter("@TableLeavesCount",model.TableLeavesCount),
               new SqlParameter("@TableLeavesWidth",model.TableLeavesWidth),
               new SqlParameter("@TablesSeatsCountClosed",model.TablesSeatsCountClosed),
               new SqlParameter("@TablesSeatsCountOpen",model.TablesSeatsCountOpen),
               new SqlParameter("@IsBestSeller",model.IsBestSeller),
               new SqlParameter("@IsUpholsteredBack_WoodBack",model.IsUpholsteredBack_WoodBack),
               new SqlParameter("@Extending",model.Extending),
               new SqlParameter("@Nail",model.Nail),
               new SqlParameter("@UPHFinish",model.UPHFinish),
               new SqlParameter("@IsNew",model.IsNew),
               new SqlParameter("@QuantityMultiplier",model.QuantityMultiplier),
               new SqlParameter("@DateCreated",model.DateCreated),
               new SqlParameter("@IntroductionDate",model.IntroductionDate),
               new SqlParameter("@IsActive",model.IsActive),
               new SqlParameter("@Shipping",model.Shipping),
               new SqlParameter("@URLCode",model.URLCode),
               new SqlParameter("@Image",model.Image),
               new SqlParameter("@ImageSirv",model.ImageSirv),
               new SqlParameter("@Description",model.Description),
               new SqlParameter("@METAKeyword",model.METAKeyword),
               new SqlParameter("@IsDownloadImageSirv",model.IsDownloadImageSirv),
               new SqlParameter("@ImageCount",model.ImageCount),
               new SqlParameter("@SketchImage",model.SketchImage),
               new SqlParameter("@SeatingPlanImage",model.SeatingPlanImage),
               new SqlParameter("@SeatingPlanPdf",model.SeatingPlanPdf),
               new SqlParameter("@CMSideAndFrontRailApronClearance",model.CMSideAndFrontRailApronClearance),
               new SqlParameter("@CMSlatToTopOfSideRailClearance",model.CMSlatToTopOfSideRailClearance),
               new SqlParameter("@CMSlatToTopOfFootRailClearance",model.CMSlatToTopOfFootRailClearance),
            };
            return parameters;
        }
        private SqlParameter[] UpdateSingleItemByIDSqlParameter001(Item model)
        {
            SqlParameter[] parameters =
            {
               new SqlParameter("@ID",model.ID),
                new SqlParameter("@URLCode",model.URLCode),
                new SqlParameter("@Image",model.Image),
                new SqlParameter("@ImageSirv",model.ImageSirv),
                new SqlParameter("@Description",model.Description),
                new SqlParameter("@METAKeyword",model.METAKeyword),
                new SqlParameter("@METADescription",model.METADescription),
                new SqlParameter("@ImageCount",model.ImageCount),
                new SqlParameter("@SketchImage",model.SketchImage),
                new SqlParameter("@SeatingPlanImage",model.SeatingPlanImage),
                new SqlParameter("@SeatingPlanPdf",model.SeatingPlanPdf),
            };
            return parameters;
        }
        private SqlParameter[] SqlParameterByIDWithImageIsNull(Item model)
        {
            SqlParameter[] parameters =
            {
               new SqlParameter("@ID",model.ID),
                new SqlParameter("@URLCode",model.URLCode),
                new SqlParameter("@Image",model.Image),
                new SqlParameter("@ImageSirv",model.ImageSirv),
                new SqlParameter("@Description",model.Description),
                new SqlParameter("@METAKeyword",model.METAKeyword),
                new SqlParameter("@METADescription",model.METADescription),
                new SqlParameter("@IsDownloadImageSirv",model.IsDownloadImageSirv),
                new SqlParameter("@ImageCount",model.ImageCount),
                new SqlParameter("@SketchImage",model.SketchImage),
                new SqlParameter("@SeatingPlanImage",model.SeatingPlanImage),
                new SqlParameter("@SeatingPlanPdf",model.SeatingPlanPdf),
            };
            return parameters;
        }
        public int UpdateItemsURLCode()
        {
            int result = AppGlobal.InitializationNumber;
            List<Item> list = GetWithURLCodeIsNullToList();
            foreach (Item item in list)
            {
                UpdateBySQL(item);
            }
            return result;
        }
        public int UpdateItemsURLCodeByConectionString(string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            List<Item> list = GetByConectionStringWithURLCodeIsNullToList(conectionString);
            foreach (Item item in list)
            {
                UpdateBySQLAndConectionString(item, conectionString);
            }
            return result;
        }
        public int UpdateItemsDescription()
        {
            int result = AppGlobal.InitializationNumber;
            List<Item> list = GetWithDescriptionIsNullToList();
            foreach (Item item in list)
            {
                UpdateBySQL(item);
            }
            return result;
        }
        public int UpdateItemsDescriptionByConectionString(string conectionString)
        {
            int result = AppGlobal.InitializationNumber;
            List<Item> list = GetByConectionStringWithDescriptionIsNullToList(conectionString);
            foreach (Item item in list)
            {
                UpdateBySQLAndConectionString(item, conectionString);
            }
            return result;
        }
        public int UpdateItemsImageCount()
        {
            int result = AppGlobal.InitializationNumber;
            List<Item> list = GetWithImageCountIsNullToList();
            foreach (Item item in list)
            {
                UpdateBySQL(item);
            }
            return result;
        }
        public Item GetByID(Guid ID)
        {
            Item result = new Item();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",ID),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectByID", parameters);
            List<Item> list = SQLHelper.ToList<Item>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            if (result == null)
            {
                result = new Item();
                result.ID = ID;
            }
            return result;
        }
        public Item GetBySKU(string SKU)
        {
            Item result = new Item();
            SKU = SKU.Trim();
            SqlParameter[] parameters =
            {
                new SqlParameter("@SKU",SKU),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectBySKU", parameters);
            List<Item> list = SQLHelper.ToList<Item>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            if (result == null)
            {
                result = new Item();
                result.SKU = SKU;
            }
            return result;
        }
        public Item GetByURLCode(string URLCode)
        {
            Item result = new Item();
            SqlParameter[] parameters =
            {
                new SqlParameter("@URLCode",URLCode),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectByURLCode", parameters);
            List<Item> list = SQLHelper.ToList<Item>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            if (result == null)
            {
                result = new Item();
                result.URLCode = URLCode;
            }
            return result;
        }
        public override List<Item> GetAllToList()
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectAllItems");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetWithURLCodeIsNullToList()
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsWithURLCodeIsNull");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetByConectionStringWithURLCodeIsNullToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(conectionString, "sp_ItemSelectItemsWithURLCodeIsNull");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetByConectionStringWithURLCodeIsNull001ToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(conectionString, "sp_ItemSelectItemsWithURLCodeIsNull001");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }

        public List<Item> GetWithDescriptionIsNullToList()
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsWithDescriptionIsNull");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetByConectionStringWithDescriptionIsNullToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(conectionString, "sp_ItemSelectItemsWithDescriptionIsNull");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetByConectionStringWithDescriptionIsNull001ToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(conectionString, "sp_ItemSelectItemsWithDescriptionIsNull001");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetWithImageIsNullToList()
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsWithImageIsNull");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetWithImageCountIsNullToList()
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsWithImageCountIsNull");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetConectionStringWithImageCountIsNull001ToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(conectionString, "sp_ItemSelectItemsWithImageCountIsNull001");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetConectionStringByIsActiveWithImageCountIsNullToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(conectionString, "sp_ItemSelectItemsByIsActiveWithImageIsNull");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }

        public List<Item> GetByConectionStringWithImageIsNullToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(conectionString, "sp_ItemSelectItemsWithImageIsNull");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetByConectionStringWithImageIsNull001ToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(conectionString, "sp_ItemSelectItemsWithImageIsNull001");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }

        public List<Item> GetByActiveToList()
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActive");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }

        public List<Item> GetByTypeIDAndIDToList(string typeID, string ID)
        {
            List<Item> result = new List<Item>();
            if ((!string.IsNullOrEmpty(typeID)) && (!string.IsNullOrEmpty(ID)))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@TypeID",typeID),
                    new SqlParameter("@ID",ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByTypeIDAndID", parameters);
                result = SQLHelper.ToList<Item>(dt);
            }
            return result;
        }
        public List<Item> GetByTypeIDAndIDAndRowCountToList(string typeID, string ID, int rowCount)
        {
            List<Item> result = new List<Item>();
            if ((!string.IsNullOrEmpty(typeID)) && (!string.IsNullOrEmpty(ID)))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@TypeID",typeID),
                    new SqlParameter("@ID",ID),
                    new SqlParameter("@RowCount",rowCount),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByTypeIDAndIDAndRowCount", parameters);
                result = SQLHelper.ToList<Item>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetItemDataTransferByActiveToList()
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemDataTransferSelectItemsByIsActive");
            result = SQLHelper.ToList<ItemDataTransfer>(dt);
            return result;
        }
        public async Task<List<Item>> AsyncGetByActiveToList()
        {
            List<Item> result = new List<Item>();
            DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActive");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetByActiveAndConectionStringToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = SQLHelper.Fill(conectionString, "sp_ItemSelectItemsByIsActive");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public async Task<List<Item>> AsyncGetByActiveAndConectionStringToList(string conectionString)
        {
            List<Item> result = new List<Item>();
            DataTable dt = await SQLHelper.FillAsync(conectionString, "sp_ItemSelectItemsByIsActive");
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetByIsActiveToList(bool isActive)
        {
            List<Item> result = new List<Item>();
            SqlParameter[] parameters =
               {
                new SqlParameter("@IsActive",isActive),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActive", parameters);
            result = SQLHelper.ToList<Item>(dt);
            return result;
        }
        public List<Item> GetByIDListToList(string IDList)
        {
            List<Item> result = new List<Item>();
            if (!string.IsNullOrEmpty(IDList))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@IDList",IDList),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIDList", parameters);
                result = SQLHelper.ToList<Item>(dt);
            }
            return result;
        }
        public List<Item> GetBySKUListToList(string SKUList)
        {
            List<Item> result = new List<Item>();
            if (!string.IsNullOrEmpty(SKUList))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SKUList",SKUList),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsBySKUList", parameters);
                result = SQLHelper.ToList<Item>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferBySearchStringToList(string searchString)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
                searchString = searchString.Replace(@",", @";");
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SearchString",searchString),
                };
                string spName = "sp_ItemSelectItemsBySearchString";
                if (searchString.Contains(@";") == true)
                {
                    spName = "sp_ItemDataTransferSelectItemsBySKUList";
                }
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, spName, parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            else
            {
                result = GetDataTransferByRowNumberToList(20);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByRowNumberToList(int rowNumber)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@RowNumber",rowNumber),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByRowNumber", parameters);
            result = SQLHelper.ToList<ItemDataTransfer>(dt);
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndExtendingToList(bool isActiveTAUS, bool extending)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndExtending", parameters);
            result = SQLHelper.ToList<ItemDataTransfer>(dt);
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndExtendingAndInStockProgramToList(bool isActiveTAUS, bool extending, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@InStockProgram",inStockProgram),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndExtendingAndInStockProgram", parameters);
            result = SQLHelper.ToList<ItemDataTransfer>(dt);
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndExtendingAndIsStockedToList(bool isActiveTAUS, bool extending, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@IsStocked",isStocked),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndExtendingAndIsStocked", parameters);
            result = SQLHelper.ToList<ItemDataTransfer>(dt);
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(bool isActiveTAUS, bool extending, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((inStockProgram == false) && (isStocked == false))
            {
                result = GetDataTransferByIsActiveTAUSAndExtendingToList(isActiveTAUS, extending);
            }
            else
            {
                if (inStockProgram == true)
                {
                    result = GetDataTransferByIsActiveTAUSAndExtendingAndInStockProgramToList(isActiveTAUS, extending, inStockProgram);
                }
                if (isStocked == true)
                {
                    result = GetDataTransferByIsActiveTAUSAndExtendingAndIsStockedToList(isActiveTAUS, extending, isStocked);
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndCollection_IDToList(bool isActiveTAUS, string collection_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(collection_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Collection_ID",collection_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndCollection_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndCollection_IDAndInStockProgramToList(bool isActiveTAUS, string collection_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(collection_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Collection_ID",collection_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndCollection_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndCollection_IDAndIsStockedToList(bool isActiveTAUS, string collection_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(collection_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Collection_ID",collection_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndCollection_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(bool isActiveTAUS, string collection_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(collection_ID))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByIsActiveTAUSAndCollection_IDToList(isActiveTAUS, collection_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndCollection_IDAndInStockProgramToList(isActiveTAUS, collection_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndCollection_IDAndIsStockedToList(isActiveTAUS, collection_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndShape_IDToList(bool isActiveTAUS, string shape_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(shape_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Shape_ID",shape_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndShape_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndShape_IDAndInStockProgramToList(bool isActiveTAUS, string shape_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(shape_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Shape_ID",shape_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndShape_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndShape_IDAndIsStockedToList(bool isActiveTAUS, string shape_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(shape_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Shape_ID",shape_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndShape_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(bool isActiveTAUS, string shape_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(shape_ID))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByIsActiveTAUSAndShape_IDToList(isActiveTAUS, shape_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndShape_IDAndInStockProgramToList(isActiveTAUS, shape_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndShape_IDAndIsStockedToList(isActiveTAUS, shape_ID, isStocked);
                    }
                }
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndLifeStyle_IDToList(bool isActiveTAUS, string lifeStyle_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(lifeStyle_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@LifeStyle_ID",lifeStyle_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndLifeStyle_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndLifeStyle_IDAndInStockProgramToList(bool isActiveTAUS, string lifeStyle_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(lifeStyle_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@LifeStyle_ID",lifeStyle_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndLifeStyle_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndLifeStyle_IDAndIsStockedToList(bool isActiveTAUS, string lifeStyle_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(lifeStyle_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@LifeStyle_ID",lifeStyle_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndLifeStyle_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(bool isActiveTAUS, string lifeStyle_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(lifeStyle_ID))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByIsActiveTAUSAndLifeStyle_IDToList(isActiveTAUS, lifeStyle_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndLifeStyle_IDAndInStockProgramToList(isActiveTAUS, lifeStyle_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndLifeStyle_IDAndIsStockedToList(isActiveTAUS, lifeStyle_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndType_IDToList(bool isActiveTAUS, string type_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(type_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Type_ID",type_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndType_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndType_IDAndInStockProgramToList(bool isActiveTAUS, string type_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(type_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Type_ID",type_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndType_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndType_IDAndIsStockedToList(bool isActiveTAUS, string type_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(type_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Type_ID",type_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndType_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(bool isActiveTAUS, string type_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(type_ID))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByIsActiveTAUSAndType_IDToList(isActiveTAUS, type_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndType_IDAndInStockProgramToList(isActiveTAUS, type_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndType_IDAndIsStockedToList(isActiveTAUS, type_ID, isStocked);
                    }
                }
            }
            return result;
        }



        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndRoomAndUsage_IDToList(bool isActiveTAUS, string roomAndUsage_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(roomAndUsage_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@RoomAndUsage_ID",roomAndUsage_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndRoomAndUsage_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramToList(bool isActiveTAUS, string roomAndUsage_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(roomAndUsage_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@RoomAndUsage_ID",roomAndUsage_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndRoomAndUsage_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndRoomAndUsage_IDAndIsStockedToList(bool isActiveTAUS, string roomAndUsage_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(roomAndUsage_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@RoomAndUsage_ID",roomAndUsage_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndRoomAndUsage_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(bool isActiveTAUS, string roomAndUsage_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(roomAndUsage_ID))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByIsActiveTAUSAndRoomAndUsage_IDToList(isActiveTAUS, roomAndUsage_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramToList(isActiveTAUS, roomAndUsage_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndRoomAndUsage_IDAndIsStockedToList(isActiveTAUS, roomAndUsage_ID, isStocked);
                    }
                }
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndBrand_IDToList(bool isActiveTAUS, string brand_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(brand_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Brand_ID",brand_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndBrand_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndBrand_IDAndInStockProgramToList(bool isActiveTAUS, string brand_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(brand_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Brand_ID",brand_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndBrand_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndBrand_IDAndIsStockedToList(bool isActiveTAUS, string brand_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(brand_ID))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Brand_ID",brand_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndBrand_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(bool isActiveTAUS, string brand_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(brand_ID))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByIsActiveTAUSAndBrand_IDToList(isActiveTAUS, brand_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndBrand_IDAndInStockProgramToList(isActiveTAUS, brand_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndBrand_IDAndIsStockedToList(isActiveTAUS, brand_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndSearchStringToList(bool isActiveTAUS, string searchString)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(searchString))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndSearchString", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndSearchStringAndInStockProgramToList(bool isActiveTAUS, string searchString, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(searchString))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@SearchString",searchString),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndSearchStringAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndSearchStringAndIsStockedToList(bool isActiveTAUS, string searchString, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(searchString))
            {

                SqlParameter[] parameters =
                {
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@SearchString",searchString),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndSearchStringAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(bool isActiveTAUS, string searchString, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(searchString))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByIsActiveTAUSAndSearchStringToList(isActiveTAUS, searchString);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndSearchStringAndInStockProgramToList(isActiveTAUS, searchString, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByIsActiveTAUSAndSearchStringAndIsStockedToList(isActiveTAUS, searchString, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDToList(string user_ID, bool isActiveTAUS, string type_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(type_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Type_ID",type_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndType_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string type_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(type_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Type_ID",type_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string type_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(type_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Type_ID",type_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndType_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string type_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(type_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDToList(user_ID, isActiveTAUS, type_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramToList(user_ID, isActiveTAUS, type_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndIsStockedToList(user_ID, isActiveTAUS, type_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDToList(string user_ID, bool isActiveTAUS, string brand_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(brand_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Brand_ID",brand_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndBrand_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string brand_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(brand_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Brand_ID",brand_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string brand_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(brand_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Brand_ID",brand_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndBrand_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string brand_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(brand_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDToList(user_ID, isActiveTAUS, brand_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramToList(user_ID, isActiveTAUS, brand_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndIsStockedToList(user_ID, isActiveTAUS, brand_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDToList(string user_ID, bool isActiveTAUS, string collection_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(collection_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Collection_ID",collection_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCollection_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string collection_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(collection_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Collection_ID",collection_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string collection_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(collection_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Collection_ID",collection_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCollection_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string collection_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(collection_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDToList(user_ID, isActiveTAUS, collection_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramToList(user_ID, isActiveTAUS, collection_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndIsStockedToList(user_ID, isActiveTAUS, collection_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingToList(string user_ID, bool isActiveTAUS, bool extending)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndExtending", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramToList(string user_ID, bool isActiveTAUS, bool extending, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndIsStockedToList(string user_ID, bool isActiveTAUS, bool extending, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndExtendingAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool extending, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingToList(user_ID, isActiveTAUS, extending);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramToList(user_ID, isActiveTAUS, extending, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndIsStockedToList(user_ID, isActiveTAUS, extending, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(lifeStyle_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@LifeStyle_ID",lifeStyle_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndLifeStyle_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(lifeStyle_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@LifeStyle_ID",lifeStyle_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(lifeStyle_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@LifeStyle_ID",lifeStyle_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(lifeStyle_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDToList(user_ID, isActiveTAUS, lifeStyle_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramToList(user_ID, isActiveTAUS, lifeStyle_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndIsStockedToList(user_ID, isActiveTAUS, lifeStyle_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(roomAndUsage_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@RoomAndUsage_ID",roomAndUsage_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndRoomAndUsage_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(roomAndUsage_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@RoomAndUsage_ID",roomAndUsage_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(roomAndUsage_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@RoomAndUsage_ID",roomAndUsage_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(roomAndUsage_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDToList(user_ID, isActiveTAUS, roomAndUsage_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramToList(user_ID, isActiveTAUS, roomAndUsage_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndIsStockedToList(user_ID, isActiveTAUS, roomAndUsage_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDToList(string user_ID, bool isActiveTAUS, string shape_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(shape_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Shape_ID",shape_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndShape_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string shape_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(shape_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Shape_ID",shape_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string shape_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(shape_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Shape_ID",shape_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndShape_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string shape_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(shape_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDToList(user_ID, isActiveTAUS, shape_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramToList(user_ID, isActiveTAUS, shape_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndIsStockedToList(user_ID, isActiveTAUS, shape_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringToList(string user_ID, bool isActiveTAUS, string searchString)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(searchString)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndSearchString", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramToList(string user_ID, bool isActiveTAUS, string searchString, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(searchString)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@SearchString",searchString),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndIsStockedToList(string user_ID, bool isActiveTAUS, string searchString, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(searchString)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@SearchString",searchString),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndSearchStringAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string searchString, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(searchString)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringToList(user_ID, isActiveTAUS, searchString);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramToList(user_ID, isActiveTAUS, searchString, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndIsStockedToList(user_ID, isActiveTAUS, searchString, isStocked);
                    }
                }
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingToList(string user_ID, bool isActiveTAUS)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCasualLiving", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingAndIsStockedToList(string user_ID, bool isActiveTAUS, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCasualLivingAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (isStocked == false)
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingToList(user_ID, isActiveTAUS);
                }
                else
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingAndIsStockedToList(user_ID, isActiveTAUS, isStocked);
                }
            }
            return result;
        }


        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndType_IDToList(string user_ID, bool isActiveTAUS, string type_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(type_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Type_ID",type_ID),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndType_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string type_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(type_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Type_ID",type_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string type_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(type_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Type_ID",type_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndType_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string type_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(type_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndType_IDToList(user_ID, isActiveTAUS, type_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramToList(user_ID, isActiveTAUS, type_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndIsStockedToList(user_ID, isActiveTAUS, type_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDToList(string user_ID, bool isActiveTAUS, string brand_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(brand_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Brand_ID",brand_ID),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndBrand_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string brand_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(brand_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Brand_ID",brand_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string brand_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(brand_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Brand_ID",brand_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndBrand_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string brand_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(brand_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDToList(user_ID, isActiveTAUS, brand_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramToList(user_ID, isActiveTAUS, brand_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndIsStockedToList(user_ID, isActiveTAUS, brand_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDToList(string user_ID, bool isActiveTAUS, string collection_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(collection_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Collection_ID",collection_ID),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCollection_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string collection_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(collection_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Collection_ID",collection_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string collection_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(collection_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Collection_ID",collection_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCollection_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string collection_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(collection_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDToList(user_ID, isActiveTAUS, collection_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramToList(user_ID, isActiveTAUS, collection_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndIsStockedToList(user_ID, isActiveTAUS, collection_ID, isStocked);
                    }
                }
            }
            return result;
        }
        public async Task<int> AsyncGetByIsActiveTAUSAndExtendingToItemCount(bool isActiveTAUS, bool extending)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {

                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                };
            DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByIsActiveTAUSAndExtendingWithCount", parameters);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    result = int.Parse(dt.Rows[0][0].ToString());
                }
                catch
                {

                }
            }
            return result;
        }


        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndExtendingToList(string user_ID, bool isActiveTAUS, bool extending)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndExtending", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramToList(string user_ID, bool isActiveTAUS, bool extending, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndIsStockedToList(string user_ID, bool isActiveTAUS, bool extending, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndExtendingAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool extending, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndExtendingToList(user_ID, isActiveTAUS, extending);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramToList(user_ID, isActiveTAUS, extending, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndIsStockedToList(user_ID, isActiveTAUS, extending, isStocked);
                    }
                }
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(lifeStyle_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@LifeStyle_ID",lifeStyle_ID),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndLifeStyle_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(lifeStyle_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@LifeStyle_ID",lifeStyle_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(lifeStyle_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@LifeStyle_ID",lifeStyle_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(lifeStyle_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDToList(user_ID, isActiveTAUS, lifeStyle_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramToList(user_ID, isActiveTAUS, lifeStyle_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndIsStockedToList(user_ID, isActiveTAUS, lifeStyle_ID, isStocked);
                    }
                }
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDToList(string user_ID, bool isActiveTAUS, string style_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(style_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Style_ID",style_ID),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndStyle_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string style_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(style_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Style_ID",style_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndStyle_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string style_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(style_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDToList(user_ID, isActiveTAUS, style_ID);
                }
                else
                {
                    if (isStocked == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDAndIsStockedToList(user_ID, isActiveTAUS, style_ID, isStocked);
                    }
                }
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDToList(string user_ID, bool isActiveTAUS, string style_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(style_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Style_ID",style_ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndStyle_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string style_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(style_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Style_ID",style_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndStyle_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string style_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(style_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDToList(user_ID, isActiveTAUS, style_ID);
                }
                else
                {
                    if (isStocked == true)
                    {
                        result = GetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDAndIsStockedToList(user_ID, isActiveTAUS, style_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(roomAndUsage_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@RoomAndUsage_ID",roomAndUsage_ID),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndRoomAndUsage_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(roomAndUsage_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@RoomAndUsage_ID",roomAndUsage_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(roomAndUsage_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@RoomAndUsage_ID",roomAndUsage_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(roomAndUsage_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDToList(user_ID, isActiveTAUS, roomAndUsage_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramToList(user_ID, isActiveTAUS, roomAndUsage_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndIsStockedToList(user_ID, isActiveTAUS, roomAndUsage_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDToList(string user_ID, bool isActiveTAUS, string shape_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(shape_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Shape_ID",shape_ID),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndShape_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramToList(string user_ID, bool isActiveTAUS, string shape_ID, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(shape_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Shape_ID",shape_ID),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string shape_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(shape_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Shape_ID",shape_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndShape_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string shape_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(shape_ID)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDToList(user_ID, isActiveTAUS, shape_ID);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramToList(user_ID, isActiveTAUS, shape_ID, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndIsStockedToList(user_ID, isActiveTAUS, shape_ID, isStocked);
                    }
                }
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringToList(string user_ID, bool isActiveTAUS, string searchString)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(searchString)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndSearchString", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramToList(string user_ID, bool isActiveTAUS, string searchString, bool inStockProgram)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(searchString)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@SearchString",searchString),
                new SqlParameter("@inStockProgram",inStockProgram),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgram", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndIsStockedToList(string user_ID, bool isActiveTAUS, string searchString, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(searchString)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@SearchString",searchString),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndSearchStringAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string searchString, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(searchString)))
            {
                if ((inStockProgram == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringToList(user_ID, isActiveTAUS, searchString);
                }
                else
                {
                    if (inStockProgram == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramToList(user_ID, isActiveTAUS, searchString, inStockProgram);
                    }
                    if (isStocked == true)
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndIsStockedToList(user_ID, isActiveTAUS, searchString, isStocked);
                    }
                }
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSToList(string user_ID, bool isActiveTAUS)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUS", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndIsStockedToList(string user_ID, bool isActiveTAUS, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (isStocked == true)
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndIsStockedToList(user_ID, isActiveTAUS, isStocked);
                }
                else
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSToList(user_ID, isActiveTAUS);
                }
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSToList(string user_ID, bool isActiveTAUS)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUS", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndIsStockedToList(string user_ID, bool isActiveTAUS, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (isStocked == true)
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndIsStockedToList(user_ID, isActiveTAUS, isStocked);
                }
                else
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSToList(user_ID, isActiveTAUS);
                }
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingToList(string user_ID, bool isActiveTAUS)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCasualLiving", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingAndIsStockedToList(string user_ID, bool isActiveTAUS, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndCasualLivingAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (isStocked == true)
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingAndIsStockedToList(user_ID, isActiveTAUS, isStocked);
                }
                else
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingToList(user_ID, isActiveTAUS);
                }
            }
            return result;
        }

        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndOptionGroup2_IDToList(string user_ID, bool isActiveTAUS, string optionGroup2_ID)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(optionGroup2_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@OptionGroup2_ID",optionGroup2_ID),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndOptionGroup2_ID", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndOptionGroup2_IDAndIsStockedToList(string user_ID, bool isActiveTAUS, string optionGroup2_ID, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if ((!string.IsNullOrEmpty(user_ID)) && (!string.IsNullOrEmpty(optionGroup2_ID)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@OptionGroup2_ID",optionGroup2_ID),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndOptionGroup2_IDAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndOptionGroup2_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string optionGroup2_ID, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (isStocked == true)
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndOptionGroup2_IDAndIsStockedToList(user_ID, isActiveTAUS, optionGroup2_ID, isStocked);
                }
                else
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndOptionGroup2_IDToList(user_ID, isActiveTAUS, optionGroup2_ID);
                }
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemToList(string user_ID, bool isActiveTAUS, bool isCFPItem)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@IsCFPItem",isCFPItem),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndIsCFPItem", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemAndIsStockedToList(string user_ID, bool isActiveTAUS, bool isCFPItem, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@IsCFPItem",isCFPItem),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndIsCFPItemAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool isCFPItem, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (isStocked == true)
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemAndIsStockedToList(user_ID, isActiveTAUS, isCFPItem, isStocked);
                }
                else
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemToList(user_ID, isActiveTAUS, isCFPItem);
                }
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemToList(string user_ID, bool isActiveTAUS, bool isCFPItem)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@IsCFPItem",isCFPItem),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndIsCFPItem", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemAndIsStockedToList(string user_ID, bool isActiveTAUS, bool isCFPItem, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@IsCFPItem",isCFPItem),
                new SqlParameter("@IsStocked",isStocked),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndIsCFPItemAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool isCFPItem, bool inStockProgram, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (isStocked == true)
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemAndIsStockedToList(user_ID, isActiveTAUS, isCFPItem, isStocked);
                }
                else
                {
                    result = GetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemToList(user_ID, isActiveTAUS, isCFPItem);
                }
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Room_IDList",room_IDList),
                new SqlParameter("@Brand_IDList",brand_IDList),
                new SqlParameter("@Type_IDList",type_IDList),
                new SqlParameter("@Shape_IDList",shape_IDList),
                new SqlParameter("@Style_IDList",style_IDList),
                new SqlParameter("@LifeStyle_IDList",lifeStyle_IDList),
                new SqlParameter("@Collection_IDList",collection_IDList),
                new SqlParameter("@Designer_IDList",designer_IDList),
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndFilters", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersAndExtendingToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@Room_IDList",room_IDList),
                new SqlParameter("@Brand_IDList",brand_IDList),
                new SqlParameter("@Type_IDList",type_IDList),
                new SqlParameter("@Shape_IDList",shape_IDList),
                new SqlParameter("@Style_IDList",style_IDList),
                new SqlParameter("@LifeStyle_IDList",lifeStyle_IDList),
                new SqlParameter("@Collection_IDList",collection_IDList),
                new SqlParameter("@Designer_IDList",designer_IDList),
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndFiltersAndExtending", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersAndIsStockedToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@IsStocked",isStocked),
                new SqlParameter("@Room_IDList",room_IDList),
                new SqlParameter("@Brand_IDList",brand_IDList),
                new SqlParameter("@Type_IDList",type_IDList),
                new SqlParameter("@Shape_IDList",shape_IDList),
                new SqlParameter("@Style_IDList",style_IDList),
                new SqlParameter("@LifeStyle_IDList",lifeStyle_IDList),
                new SqlParameter("@Collection_IDList",collection_IDList),
                new SqlParameter("@Designer_IDList",designer_IDList),
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndFiltersAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersAndExtendingAndIsStockedSubToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@IsStocked",isStocked),
                new SqlParameter("@Room_IDList",room_IDList),
                new SqlParameter("@Brand_IDList",brand_IDList),
                new SqlParameter("@Type_IDList",type_IDList),
                new SqlParameter("@Shape_IDList",shape_IDList),
                new SqlParameter("@Style_IDList",style_IDList),
                new SqlParameter("@LifeStyle_IDList",lifeStyle_IDList),
                new SqlParameter("@Collection_IDList",collection_IDList),
                new SqlParameter("@Designer_IDList",designer_IDList),
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndFiltersAndExtendingAndIsStocked", parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public async Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersAndExtendingAndIsStockedToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if ((extending == false) && (isStocked == false))
                {
                    result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(user_ID, isActiveTAUS, room_IDList, brand_IDList, type_IDList, shape_IDList, style_IDList, lifeStyle_IDList, collection_IDList, designer_IDList, searchString);
                }
                else
                {
                    if ((extending == true) && (isStocked == true))
                    {
                        result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersAndExtendingAndIsStockedSubToList(user_ID, isActiveTAUS, room_IDList, brand_IDList, type_IDList, shape_IDList, style_IDList, lifeStyle_IDList, collection_IDList, designer_IDList, searchString, extending, isStocked);
                    }
                    else
                    {
                        if (isStocked == true)
                        {
                            result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersAndIsStockedToList(user_ID, isActiveTAUS, room_IDList, brand_IDList, type_IDList, shape_IDList, style_IDList, lifeStyle_IDList, collection_IDList, designer_IDList, searchString, isStocked);
                        }
                        if (extending == true)
                        {
                            result = await AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersAndExtendingToList(user_ID, isActiveTAUS, room_IDList, brand_IDList, type_IDList, shape_IDList, style_IDList, lifeStyle_IDList, collection_IDList, designer_IDList, searchString, extending);
                        }
                    }
                }
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked, bool isCFPItem, bool isNew)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (!string.IsNullOrEmpty(room_IDList))
                {
                    room_IDList = room_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(brand_IDList))
                {
                    brand_IDList = brand_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(type_IDList))
                {
                    type_IDList = type_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(shape_IDList))
                {
                    shape_IDList = shape_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(style_IDList))
                {
                    style_IDList = style_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(lifeStyle_IDList))
                {
                    lifeStyle_IDList = lifeStyle_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(collection_IDList))
                {
                    collection_IDList = collection_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(designer_IDList))
                {
                    designer_IDList = designer_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.Trim();
                }
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@IsStocked",isStocked),
                new SqlParameter("@IsCFPItem",isCFPItem),
                new SqlParameter("@IsNew",isNew),
                new SqlParameter("@Room_IDList",room_IDList),
                new SqlParameter("@Brand_IDList",brand_IDList),
                new SqlParameter("@Type_IDList",type_IDList),
                new SqlParameter("@Shape_IDList",shape_IDList),
                new SqlParameter("@Style_IDList",style_IDList),
                new SqlParameter("@LifeStyle_IDList",lifeStyle_IDList),
                new SqlParameter("@Collection_IDList",collection_IDList),
                new SqlParameter("@Designer_IDList",designer_IDList),
                new SqlParameter("@SearchString",searchString),
                };
                string spName = "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndFilters001";
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, spName, parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndTailorFitProgramToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked, bool isCFPItem, bool isNew)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (!string.IsNullOrEmpty(room_IDList))
                {
                    room_IDList = room_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(brand_IDList))
                {
                    brand_IDList = brand_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(type_IDList))
                {
                    type_IDList = type_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(shape_IDList))
                {
                    shape_IDList = shape_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(style_IDList))
                {
                    style_IDList = style_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(lifeStyle_IDList))
                {
                    lifeStyle_IDList = lifeStyle_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(collection_IDList))
                {
                    collection_IDList = collection_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(designer_IDList))
                {
                    designer_IDList = designer_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.Trim();
                }
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@IsStocked",isStocked),
                new SqlParameter("@IsCFPItem",isCFPItem),
                new SqlParameter("@IsNew",isNew),
                new SqlParameter("@Room_IDList",room_IDList),
                new SqlParameter("@Brand_IDList",brand_IDList),
                new SqlParameter("@Type_IDList",type_IDList),
                new SqlParameter("@Shape_IDList",shape_IDList),
                new SqlParameter("@Style_IDList",style_IDList),
                new SqlParameter("@LifeStyle_IDList",lifeStyle_IDList),
                new SqlParameter("@Collection_IDList",collection_IDList),
                new SqlParameter("@Designer_IDList",designer_IDList),
                new SqlParameter("@SearchString",searchString),
                };
                string spName = "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndTailorFitProgram";
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, spName, parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndFilters002ToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked, bool isCFPItem, bool isNew, bool isBestSeller)
        {
            List<ItemDataTransfer> result = new List<ItemDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                if (!string.IsNullOrEmpty(room_IDList))
                {
                    room_IDList = room_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(brand_IDList))
                {
                    brand_IDList = brand_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(type_IDList))
                {
                    type_IDList = type_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(shape_IDList))
                {
                    shape_IDList = shape_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(style_IDList))
                {
                    style_IDList = style_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(lifeStyle_IDList))
                {
                    lifeStyle_IDList = lifeStyle_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(collection_IDList))
                {
                    collection_IDList = collection_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(designer_IDList))
                {
                    designer_IDList = designer_IDList.Trim();
                }
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.Trim();
                }
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@IsStocked",isStocked),
                new SqlParameter("@IsCFPItem",isCFPItem),
                new SqlParameter("@IsNew",isNew),
                new SqlParameter("@IsBestSeller",isBestSeller),
                new SqlParameter("@Room_IDList",room_IDList),
                new SqlParameter("@Brand_IDList",brand_IDList),
                new SqlParameter("@Type_IDList",type_IDList),
                new SqlParameter("@Shape_IDList",shape_IDList),
                new SqlParameter("@Style_IDList",style_IDList),
                new SqlParameter("@LifeStyle_IDList",lifeStyle_IDList),
                new SqlParameter("@Collection_IDList",collection_IDList),
                new SqlParameter("@Designer_IDList",designer_IDList),
                new SqlParameter("@SearchString",searchString),
                };
                string spName = "sp_ItemSelectItemsByUser_IDAndIsActiveTAUSAndFilters002";
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, spName, parameters);
                result = SQLHelper.ToList<ItemDataTransfer>(dt);
            }
            return result;
        }
        public List<ItemMenuLeftDataTransfer> GetItemMenuLeftDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked, bool isCFPItem, bool isNew)
        {
            List<ItemMenuLeftDataTransfer> result = new List<ItemMenuLeftDataTransfer>();
            if (string.IsNullOrEmpty(user_ID))
            {
                user_ID = AppGlobal.InitializationGUICodeEmpty;
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Replace(@"%20", @" ");
            }
            if (!string.IsNullOrEmpty(user_ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@User_ID",user_ID),
                new SqlParameter("@IsActiveTAUS",isActiveTAUS),
                new SqlParameter("@Extending",extending),
                new SqlParameter("@IsStocked",isStocked),
                new SqlParameter("@IsCFPItem",isCFPItem),
                new SqlParameter("@IsNew",isNew),
                new SqlParameter("@Room_IDList",room_IDList),
                new SqlParameter("@Brand_IDList",brand_IDList),
                new SqlParameter("@Type_IDList",type_IDList),
                new SqlParameter("@Shape_IDList",shape_IDList),
                new SqlParameter("@Style_IDList",style_IDList),
                new SqlParameter("@LifeStyle_IDList",lifeStyle_IDList),
                new SqlParameter("@Collection_IDList",collection_IDList),
                new SqlParameter("@Designer_IDList",designer_IDList),
                new SqlParameter("@SearchString",searchString),
                };
                string spName = "sp_ItemSelectMenuLeftByUser_IDAndIsActiveTAUSAndFilters001";
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, spName, parameters);
                result = SQLHelper.ToList<ItemMenuLeftDataTransfer>(dt);
            }
            return result;
        }
    }
}
