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
using Newtonsoft.Json;
using BL.CustomExceptions;
using BL.Dto;
using System.IO;
using System.Web;
using BL.BusinessService;
using RestSharp;
using Castle.DynamicLinqQueryBuilder;
using TAUtility;
using TA_Web_2020_API.TAService;
using TA_Web_2020_API._3.TAService.AdminTAService;

namespace TA_Web_2020_API._2.APIService
{
    public interface IAdminAPIService : IDisposable
    {
        string ping();
        Task<CheckMissingImageResult> CheckMissingImageProduct(string sendEmailTo);
        Task<CheckMissingImageResult> CheckMissingImageFabric(string sendEmailTo);
        bool SetItemActiveStatus(string sku, bool? isActiveTAUS, bool? isActiveINTL);
    }


    public class AdminAPIService : IAdminAPIService
    {
        private readonly AdminTAService _adminTAService;

        private bool disposed = false;
        public AdminAPIService(TheodoreAlexanderEntities ctx)
        {
            _adminTAService = new AdminTAService(ctx);
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _adminTAService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string ping() {
            return "AdminService";
        }

        public async Task<CheckMissingImageResult> CheckMissingImageProduct(string sendEmailTo)//sendEmailTo separated by ;
        {
            try
            {
                return await _adminTAService.CheckMissingImageProduct(sendEmailTo);
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
                return await _adminTAService.CheckMissingImageFabric(sendEmailTo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SetItemActiveStatus(string sku, bool? isActiveTAUS, bool? isActiveINTL)
        {
            return _adminTAService.SetItemActiveStatus(sku, isActiveTAUS, isActiveINTL);
        }
    }
}