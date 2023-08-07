using System;
using System.Collections.Generic;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ICollectionRepository : IRepository<Collection>
    {
        public int UpdateItemsURLCode();
        public int UpdateBySQL(Collection model);
        public Collection GetByID(Guid ID);
        public Collection GetByURLCode(string URLCode);        
        public List<Collection> GetBySearchStringToList(string searchString);
        public List<CollectionDataTransfer> GetDataTransferBySearchStringToList(string searchString);
        public List<Collection> GetWithItemCountToList();
        public List<Collection> GetByIsActiveToList(bool isActive);
        public List<Collection> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        public List<Collection> GetByBrand_IDAndIsActiveToList(string brand_ID, bool isActive);
    }
}

