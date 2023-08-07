using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface ILifeStyleRepository : IRepository<TA.Data2021.Models.LifeStyle>
    {
        TA.Data2021.Models.LifeStyle GetByURLCode(string URLCode);
        List<TA.Data2021.Models.LifeStyle> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        List<TA.Data2021.Models.LifeStyle> GetByIsActiveToList(bool isActive);
    }
}

