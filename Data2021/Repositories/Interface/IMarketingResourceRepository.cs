using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IMarketingResourceRepository : IRepositoryERP<TA.Data2021.Models.MarketingResource>
    {
        List<TA.Data2021.Models.MarketingResource> GetByParentIDAndActiveToList(int parentID, bool active);
        List<TA.Data2021.Models.MarketingResource> GetByActiveToList(bool active);
        List<TA.Data2021.Models.MarketingResource> GetByActiveAndIsUSShowToList(bool active, bool isUSShow);
        List<TA.Data2021.Models.MarketingResource> GetByActiveAndIsInternationalShowToList(bool active, bool isInternationalShow);
    }
}

