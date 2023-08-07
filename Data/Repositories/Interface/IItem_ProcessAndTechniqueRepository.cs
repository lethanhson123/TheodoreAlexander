using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_ProcessAndTechniqueRepository : IRepository<Item_ProcessAndTechnique>
    {
        public List<Item_ProcessAndTechnique> GetByItem_IDToList(string Item_ID);
        public string InsertBySQL(Item_ProcessAndTechnique model);
        public string Insert001BySQL(string sKU, string processAndTechniqueName);
        public string DeleteBySQL(string Item_ID, string ProcessAndTechnique_ID);
    }
}

