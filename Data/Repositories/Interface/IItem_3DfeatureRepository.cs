using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_3DfeatureRepository : IRepository<Item_3Dfeature>
    {
        public List<Item_3Dfeature> GetByItem_IDToList(string Item_ID);
        public string InsertBySQL(Item_3Dfeature model);
        public string Insert001BySQL(string sKU, string featureName);
        public string DeleteBySQL(string Item_ID, string Feature_ID3D);
    }
}

