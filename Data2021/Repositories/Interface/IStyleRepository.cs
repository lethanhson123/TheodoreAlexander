using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IStyleRepository : IRepository<TA.Data2021.Models.Style>
    {
        TA.Data2021.Models.Style GetByURLCode(string URLCode);
        List<TA.Data2021.Models.Style> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        List<TA.Data2021.Models.Style> GetByIsActiveToList(bool isActive);
    }
}

