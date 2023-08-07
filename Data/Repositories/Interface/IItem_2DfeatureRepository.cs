using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_2DfeatureRepository : IRepository<Item_2Dfeature>
    {
        public List<Item_2Dfeature> GetByItem_IDToList(string Item_ID);
        public string InsertBySQL(Item_2Dfeature model);
        public string Insert001BySQL(string sKU, string featureName);
        public string DeleteBySQL(string Item_ID, string Feature_ID2D);
    }
}

