using System.Collections.Generic;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IStoreRepository : IRepository<Store>
    {
        public List<Store> GetBySearchStringToList(string searchString);
        public List<StoreDataTransfer> GetDataTransferBySearchStringToList(string searchString);
    }
}

