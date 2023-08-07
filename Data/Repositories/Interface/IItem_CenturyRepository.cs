using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_CenturyRepository : IRepository<Item_Century>
    {
        public List<Item_Century> GetByItem_IDToList(string Item_ID);
        public string InsertBySQL(Item_Century model);
        public string Insert001BySQL(string sKU, string centuryName);
        public string DeleteBySQL(string Item_ID, string Century_ID);
    }
}

