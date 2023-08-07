using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IBannerRepository : IRepositoryERP<TA.Data2021.Models.Banner>
    {
        TA.Data2021.Models.Banner GetByID(int ID);
    }
}

