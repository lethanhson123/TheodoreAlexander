using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IDesignerRepository : IRepository<Designer>
    {
        public int UpdateItemsURLCode();
        public int UpdateBySQL(Designer model);
        public Designer GetByID(Guid ID);
        public Designer GetByRandom();
        public List<Designer> GetByIsActiveToList(bool isActive);
        public List<Designer> GetByIsActive001ToList(bool isActive);
        public List<Designer> GetBySearchStringToList(string searchString);
    }
}

