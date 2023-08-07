using System.Collections.Generic;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ISEOBlogRepository : IRepositoryERP<SEOBlog>
    {
        public SEOBlog GetByURLCode(string URLCode);
        public List<SEOBlog> GetByKeywordIDToList(int keywordID);
        public List<SEOBlog> GetByKeywordIDAndActiveToList(int keywordID, bool active);
        public List<SEOBlog> GetByCountryIDAndActiveToList(string countryID, bool active);
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndSearchStringToList(int keywordID, string countryID, string searchString);
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndRegionIDAndSearchStringToList(int keywordID, string countryID, string regionID, string searchString);
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndActiveToList(int keywordID, string countryID, bool active);
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndActiveAndRowBeginAndRowEndToList(int keywordID, string countryID, bool active, int rowBegin, int rowEnd);
        public List<SEOBlogDataTransfer> GetDataTransferSelectCountByCountryIDToList(string countryID);
        public int DeleteByCountryIDAndKeywordID(string countryID, int keywordID);
    }
}

