using BL.BusinessService;
using BL.Dto;
using BL.DTO;
using Castle.DynamicLinqQueryBuilder;
using DAL;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TA_Web_2020_API._3.TAService.AdminTAService;
using static TA_Web_2020_API.TAService.AdminTAService;

namespace TA_Web_2020_API.TAService
{
    public class AdminTAService : IDisposable
    {
        private readonly FabricBusinessService _fabricBUService;
        private readonly ItemBusinessService _itemBUService;
        private readonly AdminCheckMissingImageService _adminCheckMissingImageService;
        private readonly TheodoreAlexanderEntities _ctx;
        private bool disposed = false;

        public AdminTAService(TheodoreAlexanderEntities ctx)
        {
            _ctx = ctx;
            _itemBUService = new ItemBusinessService(_ctx);
            _fabricBUService = new FabricBusinessService(_ctx);
            _adminCheckMissingImageService = new AdminCheckMissingImageService(_itemBUService, _fabricBUService);
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _itemBUService.Dispose();
                _adminCheckMissingImageService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        

        public async Task<CheckMissingImageResult> CheckMissingImageProduct(string sendEmailTo)//sendEmailTo separated by ;
        {
            try
            {
                return await _adminCheckMissingImageService.CheckMissingImageProduct(sendEmailTo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<CheckMissingImageResult> CheckMissingImageFabric(string sendEmailTo)//sendEmailTo separated by ;
        {
            try
            {
                return await _adminCheckMissingImageService.CheckMissingImageFabric(sendEmailTo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SetItemActiveStatus(string sku, bool? isActiveTAUS, bool? isActiveINTL)
        {
            return _itemBUService.SetItemActiveStatus(sku, isActiveTAUS, isActiveINTL);
        }
    }
}