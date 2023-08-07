using System.Collections.Generic;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ISystem_AuthenticationApplicationRepository : IRepositoryERP<System_AuthenticationApplication>
    {
        public List<System_AuthenticationApplicationDataTransfer> GetDataTransferBySearchStringToList(string searchString);
    }
}

