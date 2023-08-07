using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface ICollectionRepository : IRepository<TA.Data2021.Models.Collection>
    {
        TA.Data2021.Models.Collection GetByID(string ID);
        TA.Data2021.Models.Collection GetByURLCode(string URLCode);
        List<TA.Data2021.Models.Collection> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        List<TA.Data2021.Models.Collection> GetByIsActiveToList(bool isActive);
        List<Collection> GetByBrand_IDAndIsActiveToList(string brand_ID, bool isActive);
        List<Collection> GetByBrand_IDAndIsActiveAndIsActiveTAUSToList(string brand_ID, bool isActive, bool isActiveTAUS);
        List<Collection> GetByBrand_IDAndIsActiveAndIsActiveTAUSAndItemCountToList(string brand_ID, bool isActive, bool isActiveTAUS, int itemCount);
        List<TA.Data2021.Models.Collection> GetByIsActiveAndIsActiveTAUSCovertMenuToList(bool isActive, bool isActiveTAUS);
    }
}

