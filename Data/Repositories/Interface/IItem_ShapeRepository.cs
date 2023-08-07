using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_ShapeRepository : IRepository<Item_Shape>
    {
        public List<Item_Shape> GetByItem_IDToList(string Item_ID);
        public string InsertBySQL(Item_Shape item_Shape);
        public string Insert001BySQL(string sKU, string shapeName);
        public string DeleteBySQL(string Item_ID, string Shape_ID);
    }
}

