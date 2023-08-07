using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IShapeRepository : IRepository<Shape>
    {
        public int UpdateItemsURLCode();
        public int UpdateBySQL(Shape model);
        public Shape GetByID(Guid ID);
        public Shape GetByURLCode(string URLCode);        
        public List<Shape> GetBySearchStringToList(string searchString);
        public List<Shape> GetByIsActiveToList(bool isActive);
        public List<Shape> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);

    }
}

