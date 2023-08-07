using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        public int UpdateBySQL(Brand model);
        public int UpdateItemsURLCode();
        public Brand GetByURLCode(string URLCode);
        public Brand GetByID(Guid ID);
        public List<Brand> GetByIsActiveToList(bool isActive);
        public List<Brand> GetBySearchStringToList(string searchString);
    }
}

