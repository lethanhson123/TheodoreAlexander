using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IDealer_TausRepository : IRepository<TA.Data2021.Models.Dealer_Taus>
    {
        List<TA.Data2021.DataTransfer.Dealer_TausDataTransfer> GetByUserIDToList(string userID);
        Task<List<TA.Data2021.DataTransfer.Dealer_TausDataTransfer>> AsyncGetByUserIDToList(string userID);
    }
}

