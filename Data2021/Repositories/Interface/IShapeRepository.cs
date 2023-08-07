using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IShapeRepository : IRepository<TA.Data2021.Models.Shape>
    {
        TA.Data2021.Models.Shape GetByURLCode(string URLCode);
        List<TA.Data2021.Models.Shape> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        List<TA.Data2021.Models.Shape> GetByIsActiveToList(bool isActive);
    }
}

