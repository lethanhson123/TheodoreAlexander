using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using DAL.ViewModels;
using BL.Extensions;
using BL.EntityService;
using System.Configuration;
using System.Transactions;
using System.Text;
using BL.DTO;
using BL.BusinessService;
//using System.Data.Linq.SqlClient;

namespace BL.BUServices
{
    public interface IProductDetailItemService : IDisposable
    {
        Task<ItemDto> GetItem(JWTIdentityViewModel jwtModel, string sku, Guid? Id, string URLCode);
        Task<ItemDto> GetItemByID(JWTIdentityViewModel jwtModel, Guid? Id);
        Task<ItemDto> GetItemBySKU(JWTIdentityViewModel jwtModel, string sku);
        Task<ItemDto> GetItemByURLCode(JWTIdentityViewModel jwtModel, string URLCode);

    }

    public class ProductDetailItemService : IProductDetailItemService
    {
        private readonly ItemBusinessService _itemService;
        private bool disposed = false;
        public ProductDetailItemService(ItemBusinessService itemService)
        {
            _itemService = itemService;
        }

        #region Implement interface
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _itemService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<ItemDto> GetItem(JWTIdentityViewModel jwtModel, string sku, Guid? Id, string URLCode)
        {
            try
            {
                ItemDto itemViewModel = await _itemService.GetItemData(jwtModel, sku, Id, URLCode);
                if (itemViewModel != null)
                {
                    _itemService.SetupPrices(itemViewModel, jwtModel);
                    await _itemService.SetupItemOption(itemViewModel, jwtModel);
                    await _itemService.SetupDownloadInfoAndFlagAsync(itemViewModel, jwtModel);
                    _itemService.SetupRelatedItems(itemViewModel, jwtModel);
                }
                else
                {
                    return null;
                }
                return itemViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ItemDto> GetItemByID(JWTIdentityViewModel jwtModel, Guid? Id)
        {
            try
            {
                ItemDto itemViewModel = await _itemService.GetItemDataByID(jwtModel, Id);
                if (itemViewModel != null)
                {
                    _itemService.SetupPrices(itemViewModel, jwtModel);
                    await _itemService.SetupItemOption(itemViewModel, jwtModel);
                    await _itemService.SetupDownloadInfoAndFlagAsync(itemViewModel, jwtModel);
                    _itemService.SetupRelatedItems(itemViewModel, jwtModel);
                }
                else
                {
                    return null;
                }
                return itemViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ItemDto> GetItemBySKU(JWTIdentityViewModel jwtModel, string sku)
        {
            try
            {
                ItemDto itemViewModel = await _itemService.GetItemDataBySKU(jwtModel, sku);
                if (itemViewModel != null)
                {
                    _itemService.SetupPrices(itemViewModel, jwtModel);
                    await _itemService.SetupItemOption(itemViewModel, jwtModel);
                    await _itemService.SetupDownloadInfoAndFlagAsync(itemViewModel, jwtModel);
                    _itemService.SetupRelatedItems(itemViewModel, jwtModel);
                }
                else
                {
                    return null;
                }
                return itemViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ItemDto> GetItemByURLCode(JWTIdentityViewModel jwtModel, string URLCode)
        {
            try
            {
                ItemDto itemViewModel = await _itemService.GetItemDataByURLCode(jwtModel, URLCode);
                if (itemViewModel != null)
                {
                    _itemService.SetupPrices(itemViewModel, jwtModel);
                    await _itemService.SetupItemOption(itemViewModel, jwtModel);
                    await _itemService.SetupDownloadInfoAndFlagAsync(itemViewModel, jwtModel);
                    _itemService.SetupRelatedItems(itemViewModel, jwtModel);
                }
                else
                {
                    return null;
                }
                return itemViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Private method
        #endregion

        #region Public method
        #endregion
    }
}
