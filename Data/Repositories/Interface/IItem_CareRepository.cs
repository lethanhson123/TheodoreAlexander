using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_CareRepository : IRepository<Item_Care>
    {
        public List<Item_Care> GetByItem_IDToList(string Item_ID);
        public string InsertBySQL(Item_Care model);
        public string Insert001BySQL(string sKU, string careName);
        public string DeleteBySQL(string Item_ID, string Care_ID);
    }
}

