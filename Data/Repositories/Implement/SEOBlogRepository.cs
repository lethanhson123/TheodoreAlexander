using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class SEOBlogRepository : RepositoryERP<SEOBlog>, ISEOBlogRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        private readonly TheodoreAlexander_NewContext _contextNew;
        public SEOBlogRepository(TheodoreAlexander_NewContext contextNew, TheodoreAlexander_ERPContext context) : base(context)
        {
            _contextNew = contextNew;
            _context = context;
        }
        public override void Initialization(SEOBlog model)
        {

            model.DateUpdated = AppGlobal.InitializationDateTime;
            if (model.DateCreated == null)
            {
                model.DateCreated = AppGlobal.InitializationDateTime;
            }
            SEOKeyword sEOKeyword = _context.Set<SEOKeyword>().AsNoTracking().FirstOrDefault(item => item.ID == model.KeywordID);
            SEOBlogTemplate sEOBlogTemplate = _context.Set<SEOBlogTemplate>().AsNoTracking().FirstOrDefault(item => item.ID == model.SEOBlogTemplateID);
            Designer designer = new Designer();
            Country country = new Country();
            Region region = new Region();
            City city = new City();
            try
            {
                if (!string.IsNullOrEmpty(model.DesignerID))
                {
                    designer = _contextNew.Set<Designer>().AsNoTracking().FirstOrDefault(item => item.ID == System.Guid.Parse(model.DesignerID));
                }
            }
            catch
            {
            }
            try
            {
                if (!string.IsNullOrEmpty(model.CountryID))
                {
                    country = _contextNew.Set<Country>().AsNoTracking().FirstOrDefault(item => item.ID == System.Guid.Parse(model.CountryID));
                }
            }
            catch
            {
            }
            try
            {
                if (!string.IsNullOrEmpty(model.RegionID))
                {
                    region = _contextNew.Set<Region>().AsNoTracking().FirstOrDefault(item => item.ID == System.Guid.Parse(model.RegionID));
                }
            }
            catch
            {
            }
            try
            {
                if (!string.IsNullOrEmpty(model.CityID))
                {
                    city = _contextNew.Set<City>().AsNoTracking().FirstOrDefault(item => item.ID == System.Guid.Parse(model.CityID));
                }
            }
            catch
            {
            }

            if (sEOKeyword != null)
            {
                if (!string.IsNullOrEmpty(sEOKeyword.Title))
                {
                    model.Keyword = sEOKeyword.Title;
                    model.Title = sEOKeyword.Title + " at";
                }
            }
            if (sEOBlogTemplate != null)
            {
                if (!string.IsNullOrEmpty(sEOBlogTemplate.Description))
                {
                    model.SEOBlogTemplateContent = sEOBlogTemplate.Description;
                    model.SEOBlogTemplateImage = sEOBlogTemplate.Image;
                    model.URLSEOBlogTemplateImage = sEOBlogTemplate.URLImage;
                }
            }
            if (designer != null)
            {
                if (!string.IsNullOrEmpty(designer.DescriptionLong))
                {
                    model.DesignerName = designer.Name;
                    model.DesignerContent = designer.DescriptionLong;
                    model.DesignerImage = designer.ImageMain;
                    model.URLDesignerImage = designer.URLImageMain;
                }
            }
            if (city != null)
            {
                if (!string.IsNullOrEmpty(city.Name))
                {
                    model.Title = model.Title + " " + city.Name + " - ";
                    model.CityName = city.Name;
                }
            }
            if (region != null)
            {
                if (!string.IsNullOrEmpty(region.Name))
                {
                    model.Title = model.Title + " " + region.Name + " - ";
                    model.RegionName = region.Name;
                }
            }
            if (country != null)
            {
                if (!string.IsNullOrEmpty(country.Name))
                {
                    model.Title = model.Title + " " + country.Name;
                    model.CountryName = country.Name;
                }
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = model.Title;
            }
            if (string.IsNullOrEmpty(model.METAKeyword))
            {
                model.METAKeyword = model.Title;
            }
            if (string.IsNullOrEmpty(model.METADescription))
            {
                model.METADescription = model.Title;
            }
            model.Title = model.Title.Trim();
            model.Title = model.Title.Replace(@"   ", " ");
            if (string.IsNullOrEmpty(model.URLCode))
            {
                model.URLCode = AppGlobal.SetName(model.Title);
                model.URLCode = model.URLCode.Replace(@" ", @"");
                model.URLCode = model.URLCode.Replace(@"  ", @"");
            }
            model.Image = model.SEOBlogTemplateImage;
            model.URLImage = model.URLSEOBlogTemplateImage;
        }
        public SEOBlog GetByURLCode(string URLCode)
        {
            var result = _context.Set<SEOBlog>().AsNoTracking().FirstOrDefault(model => model.URLCode == URLCode);
            return result;
        }
        public List<SEOBlog> GetByKeywordIDAndSearchStringToList(int keywordID, string searchString)
        {
            List<SEOBlog> result = new List<SEOBlog>();
            result = _context.Set<SEOBlog>().Where(model => model.KeywordID == keywordID && (model.Keyword.Contains(searchString) == true || model.Title.Contains(searchString) == true || model.URLCode.Contains(searchString) == true)).OrderBy(model => model.Title).ToList();
            return result;
        }
        public List<SEOBlog> GetByKeywordIDToList(int keywordID)
        {
            List<SEOBlog> result = new List<SEOBlog>();
            result = _context.Set<SEOBlog>().Where(model => model.KeywordID == keywordID).OrderBy(model => model.Title).ToList();
            return result;
        }
        public List<SEOBlog> GetByKeywordIDAndActiveToList(int keywordID, bool active)
        {
            List<SEOBlog> result = new List<SEOBlog>();
            result = _context.Set<SEOBlog>().Where(model => model.KeywordID == keywordID && model.Active == active).OrderBy(model => model.Title).ToList();
            return result;
        }
        public List<SEOBlog> GetByCountryIDAndActiveToList(string countryID, bool active)
        {
            List<SEOBlog> result = new List<SEOBlog>();
            result = _context.Set<SEOBlog>().Where(model => model.CountryID == countryID && model.Active == active).OrderBy(model => model.Title).ToList();
            return result;
        }
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndActiveToList(int keywordID, string countryID, bool active)
        {
            List<SEOBlog> result = new List<SEOBlog>();
            result = _context.Set<SEOBlog>().Where(model => model.KeywordID == keywordID && model.CountryID == countryID && model.Active == active).OrderBy(model => model.Title).ToList();
            return result;
        }
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndActiveAndRowBeginAndRowEndToList(int keywordID, string countryID, bool active,int rowBegin, int rowEnd)
        {
            List<SEOBlog> result = new List<SEOBlog>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@KeywordID",keywordID),
                new SqlParameter("@CountryID",countryID),
                new SqlParameter("@Active",active),
                new SqlParameter("@RowBegin",rowBegin),
                new SqlParameter("@RowEnd",rowEnd),                
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogSelectByKeywordIDAndCountryIDAndActiveAndRowBeginAndRowEnd", parameters);
            result = SQLHelper.ToList<SEOBlog>(dt);
            return result;            
        }
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndSearchStringToList(int keywordID, string countryID, string searchString)
        {
            List<SEOBlog> result = new List<SEOBlog>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = _context.Set<SEOBlog>().Where(model => model.KeywordID == keywordID && model.CountryID == countryID).OrderBy(model => model.Title).ToList();
            }
            else
            {
                result = GetByKeywordIDAndSearchStringToList(keywordID, searchString);
            }
            return result;
        }
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndRegionIDAndSearchStringToList(int keywordID, string countryID, string regionID, string searchString)
        {
            List<SEOBlog> result = new List<SEOBlog>();
            if (string.IsNullOrEmpty(searchString))
            {
                if (string.IsNullOrEmpty(regionID))
                {
                    result = GetByKeywordIDAndCountryIDAndSearchStringToList(keywordID, countryID, searchString);
                }
                else
                {
                    result = _context.Set<SEOBlog>().Where(model => model.KeywordID == keywordID && model.CountryID == countryID && model.RegionID == regionID).OrderBy(model => model.Title).ToList();
                }
            }
            else
            {
                result = GetByKeywordIDAndSearchStringToList(keywordID, searchString);
            }

            return result;
        }
        public List<SEOBlogDataTransfer> GetDataTransferSelectCountByCountryIDToList(string countryID)
        {
            List<SEOBlogDataTransfer> result = new List<SEOBlogDataTransfer>();
            SqlParameter[] parameters =
               {
                new SqlParameter("@CountryID",countryID),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogDataTransferSelectCountByCountryID", parameters);
            result = SQLHelper.ToList<SEOBlogDataTransfer>(dt);
            return result;
        }
        public int DeleteByCountryIDAndKeywordID(string countryID, int keywordID)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
                new SqlParameter("@CountryID",countryID),
                new SqlParameter("@KeywordID",keywordID),
            };
            string mes = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_SEOBlogDeleteByCountryIDAndKeywordID", parameters);
            return result;
        }
    }
}

