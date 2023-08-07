using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_HistoricalStyleRepository : IRepository<Item_HistoricalStyle>
    {
        public List<Item_HistoricalStyle> GetByItem_IDToList(string Item_ID);
        public string InsertBySQL(Item_HistoricalStyle model);
        public string Insert001BySQL(string sKU, string historicalStyleName);
        public string DeleteBySQL(string Item_ID, string HistoricalStyle_ID);
    }
}

