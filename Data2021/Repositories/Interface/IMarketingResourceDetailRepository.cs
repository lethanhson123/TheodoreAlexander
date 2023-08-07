using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IMarketingResourceDetailRepository : IRepositoryERP<TA.Data2021.Models.MarketingResourceDetail>
    {
        List<TA.Data2021.Models.MarketingResourceDetail> GetByParentIDAndActiveToList(int parentID, bool active);
        List<TA.Data2021.Models.MarketingResourceDetail> GetByActiveToList(bool active);
        List<TA.Data2021.Models.MarketingResourceDetail> GetByActiveAndIsUSShowToList(bool active, bool isUSShow);
        List<TA.Data2021.Models.MarketingResourceDetail> GetByActiveAndIsInternationalShowToList(bool active, bool isInternationalShow);
    }
}

