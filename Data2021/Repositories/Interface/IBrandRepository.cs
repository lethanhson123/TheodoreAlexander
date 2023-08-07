using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IBrandRepository : IRepository<TA.Data2021.Models.Brand>
    {
        TA.Data2021.Models.Brand GetByURLCode(string URLCode);
        List<TA.Data2021.Models.Brand> GetByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        List<TA.Data2021.Models.Brand> GetByIsActiveToList(bool isActive);
    }
}

