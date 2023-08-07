using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IStyleRepository : IRepository<Style>
    {
        public int UpdateItemsURLCode();
        public int UpdateBySQL(Style model);
        public Style GetByID(Guid ID);
        public Style GetByURLCode(string URLCode);       
        public List<Style> GetByIsActiveToList(bool isActive);
        public List<Style> GetBySearchStringToList(string searchString);
        public List<Style> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
    }
}

