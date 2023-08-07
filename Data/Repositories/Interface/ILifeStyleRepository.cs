using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ILifeStyleRepository : IRepository<LifeStyle>
    {
        public int UpdateItemsURLCode();
        public int UpdateBySQL(LifeStyle model);
        public LifeStyle GetByID(Guid ID);
        public LifeStyle GetByURLCode(string URLCode);       
        public List<LifeStyle> GetByIsActiveToList(bool isActive);
        public List<LifeStyle> GetBySearchStringToList(string searchString);
        public List<LifeStyle> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
    }
}

