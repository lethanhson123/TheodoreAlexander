using BL.BusinessService;
using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TA_Web_2020_API._3.TAService;
using TA_Web_2020_API.ViewModel;

namespace TA_Web_2020_API._2.APIService
{
    public interface ICommonAPIService : IDisposable
    {
    }

    public class CommonAPIService : ICommonAPIService
    {
        private bool disposed = false;
        public CommonAPIService()
        {
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}