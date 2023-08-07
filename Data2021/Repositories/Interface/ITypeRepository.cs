using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface ITypeRepository : IRepository<TA.Data2021.Models.Type>
    {
        TA.Data2021.Models.Type GetByID(string ID);
        TA.Data2021.Models.Type GetByURLCode(string URLCode);
        List<TA.Data2021.Models.Type> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        List<TA.Data2021.Models.Type> GetByIsActiveToList(bool isActive);
    }
}

