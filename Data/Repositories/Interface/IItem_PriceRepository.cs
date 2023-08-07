using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_PriceRepository : IRepository<Item_Price>
    {
        public List<Item_Price> GetBySKUToList(string SKU);
        public int InsertBySQL(Item_Price model);
        public int UpdateBySQL(Item_Price model);
    }
}

