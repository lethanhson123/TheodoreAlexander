using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IRelatedSkuForSpecialGroupRepository : IRepository<RelatedSkuForSpecialGroup>
    {
        public List<RelatedSkuForSpecialGroup> GetByItem_IDToList(Guid Item_ID);
        public string InsertBySQL(RelatedSkuForSpecialGroup model);
        public string Insert001BySQL(string itemSKU, string sKU);
        public string DeleteBySQL(RelatedSkuForSpecialGroup model);
    }
}

