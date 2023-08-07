using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IRoomAndUsageRepository : IRepository<RoomAndUsage>
    {
        public int UpdateItemsURLCode();
        public int UpdateBySQL(RoomAndUsage model);
        public RoomAndUsage GetByID(Guid ID);
        public RoomAndUsage GetByURLCode(string URLCode);        
        public List<RoomAndUsage> GetBySearchStringToList(string searchString);
        public List<RoomAndUsage> GetByIsActiveToList(bool isActive);
        public List<RoomAndUsage> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
    }
}

