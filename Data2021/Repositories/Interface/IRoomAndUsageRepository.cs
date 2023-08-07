using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IRoomAndUsageRepository : IRepository<TA.Data2021.Models.RoomAndUsage>
    {
        TA.Data2021.Models.RoomAndUsage GetByID(string ID);
        TA.Data2021.Models.RoomAndUsage GetByURLCode(string URLCode);
        List<TA.Data2021.Models.RoomAndUsage> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        List<TA.Data2021.Models.RoomAndUsage> GetByIsActiveToList(bool isActive);
    }
}

