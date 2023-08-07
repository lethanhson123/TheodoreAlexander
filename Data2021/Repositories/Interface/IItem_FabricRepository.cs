using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IItem_FabricRepository : IRepository<TA.Data2021.Models.Item_Fabric>
    {
        List<TA.Data2021.Models.Item_Fabric> GetByItemIDAndIsActiveToList(string ItemID, bool isActive);
    }
}

