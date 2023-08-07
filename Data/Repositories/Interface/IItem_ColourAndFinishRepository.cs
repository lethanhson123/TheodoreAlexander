using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IItem_ColourAndFinishRepository : IRepository<Item_ColourAndFinish>
    {
        public List<Item_ColourAndFinish> GetByItem_IDToList(string Item_ID);
        public string InsertBySQL(Item_ColourAndFinish model);
        public string Insert001BySQL(string sKU, string colourAndFinishName);
        public string DeleteBySQL(string Item_ID, string ColourAndFinish_ID);
    }
}

