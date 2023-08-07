using System;
using System.Collections.Generic;
using TA.Data2021.DataTransfer;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IStoreRepository : IRepository<TA.Data2021.Models.Store>
    {
        List<TA.Data2021.Models.Store> GetByUserIDToList(string userID);
        List<Store> GetByIsActiveAndSearchStringToList(bool isActive, string searchString);
        List<Store> GetByFilterToList(bool isActive, string searchString, string countryISO, string regionName, decimal latitude, decimal longitude, bool isDealerNearYou);
        List<Store> GetByFilter2022ToList(bool isActive, string searchString, decimal latitude, decimal longitude, decimal radius);
    }
}

