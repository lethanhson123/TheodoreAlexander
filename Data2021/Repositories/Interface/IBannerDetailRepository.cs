using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IBannerDetailRepository : IRepositoryERP<TA.Data2021.Models.BannerDetail>
    {
        List<TA.Data2021.Models.BannerDetail> GetByParentIDAndActiveAndIsUSShowToList(int parentID, bool active, bool isUSShow);
        List<TA.Data2021.Models.BannerDetail> GetByParentIDAndActiveAndIsInternationalShowToList(int parentID, bool active, bool isInternationalShow);
    }
}

