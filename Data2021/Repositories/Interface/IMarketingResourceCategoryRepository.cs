using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IMarketingResourceCategoryRepository : IRepositoryERP<TA.Data2021.Models.MarketingResourceCategory>
    {
        List<TA.Data2021.Models.MarketingResourceCategory> GetByActiveToList(bool active);
        List<TA.Data2021.Models.MarketingResourceCategory> GetByActiveAndIsUSShowToList(bool active, bool isUSShow);
        List<TA.Data2021.Models.MarketingResourceCategory> GetByActiveAndIsInternationalShowToList(bool active, bool isInternationalShow);
        int UpdateBySQL(MarketingResourceCategory model);
    }
}

