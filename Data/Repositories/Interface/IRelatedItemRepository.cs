using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IRelatedItemRepository : IRepository<RelatedItem>
    {
        public List<RelatedItem> GetByItem_IDToList(Guid Item_ID);
        public string InsertBySQL(RelatedItem model);
        public string Insert001BySQL(string item01SKU, string item02SKU);
        public string DeleteBySQL(RelatedItem model);
    }
}

