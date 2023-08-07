using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_StatusRepository : IRepository<Item_Status>
    {
        public List<Item_Status> GetBySKUToList(string SKU);
        public int InsertBySQL(Item_Status model);
        public int UpdateBySQL(Item_Status model);
    }
}

