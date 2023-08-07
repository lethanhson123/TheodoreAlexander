using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_FabricRepository : IRepository<Item_Fabric>
    {
        public List<Item_Fabric> GetByItemIDToList(string ItemID);
        public string InsertBySQL(Item_Fabric model);
        public string Insert001BySQL(string sKU, string fabricCode);
        public string UpdateBySQL(Item_Fabric model);
        public string DeleteBySQL(string ID);
    }
}

