using System;
using System.Collections.Generic;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ITypeRepository : IRepository<TA.Data.Models.Type>
    {
        public int UpdateItemsURLCode();
        public int UpdateBySQL(TA.Data.Models.Type model);
        public TA.Data.Models.Type GetByID(Guid ID);
        public TA.Data.Models.Type GetByURLCode(string URLCode);        
        public List<TA.Data.Models.Type> GetByIsEnabledOnWebToList(bool isEnabledOnWeb);
        public List<TA.Data.Models.Type> GetByIsActiveToList(bool isActive);
        public List<TA.Data.Models.Type> GetBySearchStringToList(string searchString);
        public List<TypeDataTransfer> GetDataTransferBySearchStringToList(string searchString);
        public List<TA.Data.Models.Type> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
    }
}

