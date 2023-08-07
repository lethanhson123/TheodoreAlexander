using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IDesignerRepository : IRepository<TA.Data2021.Models.Designer>
    {
        TA.Data2021.Models.Designer GetByURLCode(string URLCode);
        List<TA.Data2021.Models.Designer> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        List<TA.Data2021.Models.Designer> GetByIsActiveToList(bool isActive);
    }
}

