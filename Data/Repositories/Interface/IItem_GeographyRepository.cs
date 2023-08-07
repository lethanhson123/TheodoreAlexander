using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_GeographyRepository : IRepository<Item_Geography>
    {
        public List<Item_Geography> GetByItem_IDToList(string Item_ID);
        public string InsertBySQL(Item_Geography model);
        public string Insert001BySQL(string sKU, string geographyName);
        public string DeleteBySQL(string Item_ID, string Geography_ID);
    }
}

