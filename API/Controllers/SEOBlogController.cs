using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Data.Repositories;
using TA.Helpers;

namespace TA.API.Controllers
{
    public class SEOBlogController : BaseController
    {
        private readonly IDesignerRepository _designerRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ISEOBlogItemRepository _sEOBlogItemRepository;
        private readonly ISEOBlogTypeRepository _sEOBlogTypeRepository;
        private readonly ISEOBlogStoreRepository _sEOBlogStoreRepository;
        private readonly ISEOBlogTemplateRepository _sEOBlogTemplateRepository;
        private readonly ISEOKeywordRepository _sEOKeywordRepository;
        private readonly ISEOBlogRepository _sEOBlogRepository;
        public SEOBlogController(IDesignerRepository designerRepository
            , ICityRepository cityRepository
            , IRegionRepository regionRepository
            , ICountryRepository countryRepository
            , ISEOBlogItemRepository sEOBlogItemRepository
            , ISEOBlogTypeRepository sEOBlogTypeRepository
            , ISEOBlogStoreRepository sEOBlogStoreRepository
            , ISEOBlogTemplateRepository sEOBlogTemplateRepository
            , ISEOKeywordRepository sEOKeywordRepository
            , ISEOBlogRepository sEOBlogRepository) : base()
        {
            _designerRepository = designerRepository;
            _cityRepository = cityRepository;
            _regionRepository = regionRepository;
            _countryRepository = countryRepository;
            _sEOBlogItemRepository = sEOBlogItemRepository;
            _sEOBlogTypeRepository = sEOBlogTypeRepository;
            _sEOBlogStoreRepository = sEOBlogStoreRepository;
            _sEOBlogTemplateRepository = sEOBlogTemplateRepository;
            _sEOKeywordRepository = sEOKeywordRepository;
            _sEOBlogRepository = sEOBlogRepository;
        }
        [HttpPost]
        public int Add(SEOBlog sEOBlog)
        {
            var result = AppGlobal.InitializationNumber;
            if (sEOBlog.ID > 0)
            {
                result = _sEOBlogRepository.Update(sEOBlog);
            }
            else
            {
                result = _sEOBlogRepository.Add(sEOBlog);
            }
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAdd(SEOBlog sEOBlog)
        {
            var result = await _sEOBlogRepository.AsyncAdd(sEOBlog);
            return result;
        }
        [HttpPost]
        public int AddRange(List<SEOBlog> list)
        {
            var result = _sEOBlogRepository.AddRange(list);
            return result;
        }
        [HttpPost]
        public async Task<int> AsyncAddRange(List<SEOBlog> list)
        {
            var result = await _sEOBlogRepository.AsyncAddRange(list);
            return result;
        }
        [HttpPut]
        public int Update(SEOBlog sEOBlog)
        {
            var result = _sEOBlogRepository.Update(sEOBlog);
            return result;
        }
        [HttpPut]
        public async Task<int> AsyncUpdate(SEOBlog sEOBlog)
        {
            var result = await _sEOBlogRepository.AsyncUpdate(sEOBlog);
            return result;
        }
        [HttpDelete]
        public int RemoveRange(List<SEOBlog> list)
        {
            var result = _sEOBlogRepository.RemoveRange(list);
            return result;
        }
        [HttpDelete]
        public async Task<int> AsyncRemoveRange(List<SEOBlog> list)
        {
            var result = await _sEOBlogRepository.AsyncRemoveRange(list);
            return result;
        }
        
        [HttpGet]
        public List<SEOBlog> GetAllToList()
        {
            var result = _sEOBlogRepository.GetAllToList();
            return result;
        }
        [HttpGet]
        public async Task<List<SEOBlog>> AsyncGetAllToList()
        {
            var result = await _sEOBlogRepository.AsyncGetAllToList();
            return result;
        }
        [HttpGet]
        public List<SEOBlog> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _sEOBlogRepository.GetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public async Task<List<SEOBlog>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _sEOBlogRepository.AsyncGetByPageAndPageSizeToList(page, pageSize);
            return result;
        }
        [HttpGet]
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndSearchStringToList(int keywordID, string countryID, string searchString)
        {
            var result = _sEOBlogRepository.GetByKeywordIDAndCountryIDAndSearchStringToList(keywordID, countryID, searchString);
            return result;
        }
        [HttpGet]
        public List<SEOBlog> GetByKeywordIDAndCountryIDAndRegionIDAndSearchStringToList(int keywordID, string countryID, string regionID, string searchString)
        {
            var result = _sEOBlogRepository.GetByKeywordIDAndCountryIDAndRegionIDAndSearchStringToList(keywordID, countryID, regionID, searchString);
            return result;
        }
        [HttpGet]
        public List<SEOBlogDataTransfer> GetDataTransferSelectCountByCountryIDToList(string countryID)
        {
            var result = _sEOBlogRepository.GetDataTransferSelectCountByCountryIDToList(countryID);
            return result;
        }
        [HttpGet]
        public int DeleteByCountryIDAndKeywordID(string countryID, int keywordID)
        {
            var result = _sEOBlogRepository.DeleteByCountryIDAndKeywordID(countryID, keywordID);
            return result;
        }
        [HttpGet]
        public string InitializationInUS()
        {
            List<SEOKeyword> listSEOKeyword = _sEOKeywordRepository.GetByActiveToList(true);
            List<Designer> listDesigner = _designerRepository.GetByIsActive001ToList(true);
            List<SEOBlogTemplate> listSEOBlogTemplate = _sEOBlogTemplateRepository.GetByActiveToList(true);
            Country country = _countryRepository.GetByID(Guid.Parse(AppGlobal.CountryIDUS));
            Designer designer = new Designer();
            SEOBlogTemplate sEOBlogTemplate = new SEOBlogTemplate();
            SEOBlog sEOBlog = new SEOBlog();
            int result = AppGlobal.InitializationNumber;
            int listDesignerItem = AppGlobal.InitializationNumber;
            int listSEOBlogTemplateItem = AppGlobal.InitializationNumber;
            Random listDesignerRandom = new Random();
            Random listSEOBlogTemplateRandom = new Random();

            int listDesignerCount = listDesigner.Count;
            int listSEOBlogTemplateCount = listSEOBlogTemplate.Count;
            if ((listDesignerCount > 0) && (listSEOBlogTemplateCount > 0))
            {
                foreach (SEOKeyword itemSEOKeyword in listSEOKeyword)
                {
                    listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                    listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                    sEOBlog = new SEOBlog();
                    sEOBlog.CountryID = country.ID.ToString();
                    sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                    sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                    sEOBlog.KeywordID = itemSEOKeyword.ID;
                    sEOBlog.Active = true;
                    result = _sEOBlogRepository.Add(sEOBlog);
                    if (sEOBlog.ID > 0)
                    {
                        _sEOBlogTypeRepository.InitializationByParentID(sEOBlog.ID);
                        _sEOBlogStoreRepository.InitializationByParentID(sEOBlog.ID);
                        _sEOBlogItemRepository.InitializationByParentID(sEOBlog.ID);
                    }
                    List<Region> listRegion = _regionRepository.GetByCountryIDToList(country.ID.Value);
                    foreach (Region itemRegion in listRegion)
                    {
                        listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                        listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                        sEOBlog = new SEOBlog();
                        sEOBlog.CountryID = country.ID.ToString();
                        sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                        sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                        sEOBlog.KeywordID = itemSEOKeyword.ID;
                        sEOBlog.RegionID = itemRegion.ID.ToString();
                        sEOBlog.Active = true;
                        result = _sEOBlogRepository.Add(sEOBlog);
                        if (sEOBlog.ID > 0)
                        {
                            _sEOBlogTypeRepository.InitializationByParentID(sEOBlog.ID);
                            _sEOBlogStoreRepository.InitializationByParentID(sEOBlog.ID);
                            _sEOBlogItemRepository.InitializationByParentID(sEOBlog.ID);
                        }
                        List<City> listCity = _cityRepository.GetByRegionIDToList(itemRegion.ID.Value);
                        foreach (City itemCity in listCity)
                        {
                            listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                            listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                            sEOBlog = new SEOBlog();
                            sEOBlog.CountryID = country.ID.ToString();
                            sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                            sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                            sEOBlog.KeywordID = itemSEOKeyword.ID;
                            sEOBlog.RegionID = itemRegion.ID.ToString();
                            sEOBlog.CityID = itemCity.ID.ToString();
                            sEOBlog.Active = true;
                            result = _sEOBlogRepository.Add(sEOBlog);
                            if (sEOBlog.ID > 0)
                            {
                                _sEOBlogTypeRepository.InitializationByParentID(sEOBlog.ID);
                                _sEOBlogStoreRepository.InitializationByParentID(sEOBlog.ID);
                                _sEOBlogItemRepository.InitializationByParentID(sEOBlog.ID);
                            }
                        }
                    }
                }
            }
            return AppGlobal.InitializationDateTimeCode;
        }
        [HttpGet]
        public string InitializationByCountryID(string countryID)
        {
            string region = AppGlobal.InitializationString;
            if (countryID.ToLower() == AppGlobal.CountryIDUS.ToLower())
            {
                region = "taus";
            }
            else
            {
                region = "international";
            }
            List<SEOKeyword> listSEOKeyword = _sEOKeywordRepository.GetByActiveToList(true);
            List<Designer> listDesigner = _designerRepository.GetByIsActive001ToList(true);
            List<SEOBlogTemplate> listSEOBlogTemplate = _sEOBlogTemplateRepository.GetByActiveToList(true);
            Country country = _countryRepository.GetByID(Guid.Parse(countryID));
            Designer designer = new Designer();
            SEOBlogTemplate sEOBlogTemplate = new SEOBlogTemplate();
            SEOBlog sEOBlog = new SEOBlog();
            int result = AppGlobal.InitializationNumber;
            int listDesignerItem = AppGlobal.InitializationNumber;
            int listSEOBlogTemplateItem = AppGlobal.InitializationNumber;
            Random listDesignerRandom = new Random();
            Random listSEOBlogTemplateRandom = new Random();

            int listDesignerCount = listDesigner.Count;
            int listSEOBlogTemplateCount = listSEOBlogTemplate.Count;
            if ((listDesignerCount > 0) && (listSEOBlogTemplateCount > 0))
            {
                foreach (SEOKeyword itemSEOKeyword in listSEOKeyword)
                {
                    listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                    listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                    sEOBlog = new SEOBlog();
                    sEOBlog.CountryID = country.ID.ToString();
                    sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                    sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                    sEOBlog.KeywordID = itemSEOKeyword.ID;
                    sEOBlog.Active = true;
                    result = _sEOBlogRepository.Add(sEOBlog);
                    if (sEOBlog.ID > 0)
                    {
                        _sEOBlogTypeRepository.InitializationByParentID(sEOBlog.ID);
                        _sEOBlogStoreRepository.InitializationByParentID(sEOBlog.ID);
                        _sEOBlogItemRepository.InitializationByParentIDAndRegion(sEOBlog.ID, region);
                    }
                    List<Region> listRegion = _regionRepository.GetByCountryIDToList(country.ID.Value);
                    foreach (Region itemRegion in listRegion)
                    {
                        listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                        listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                        sEOBlog = new SEOBlog();
                        sEOBlog.CountryID = country.ID.ToString();
                        sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                        sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                        sEOBlog.KeywordID = itemSEOKeyword.ID;
                        sEOBlog.RegionID = itemRegion.ID.ToString();
                        sEOBlog.Active = true;
                        result = _sEOBlogRepository.Add(sEOBlog);
                        if (sEOBlog.ID > 0)
                        {
                            _sEOBlogTypeRepository.InitializationByParentID(sEOBlog.ID);
                            _sEOBlogStoreRepository.InitializationByParentID(sEOBlog.ID);
                            _sEOBlogItemRepository.InitializationByParentIDAndRegion(sEOBlog.ID, region);
                        }
                        List<City> listCity = _cityRepository.GetByRegionIDToList(itemRegion.ID.Value);
                        foreach (City itemCity in listCity)
                        {
                            listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                            listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                            sEOBlog = new SEOBlog();
                            sEOBlog.CountryID = country.ID.ToString();
                            sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                            sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                            sEOBlog.KeywordID = itemSEOKeyword.ID;
                            sEOBlog.RegionID = itemRegion.ID.ToString();
                            sEOBlog.CityID = itemCity.ID.ToString();
                            sEOBlog.Active = true;
                            result = _sEOBlogRepository.Add(sEOBlog);
                            if (sEOBlog.ID > 0)
                            {
                                _sEOBlogTypeRepository.InitializationByParentID(sEOBlog.ID);
                                _sEOBlogStoreRepository.InitializationByParentID(sEOBlog.ID);
                                _sEOBlogItemRepository.InitializationByParentIDAndRegion(sEOBlog.ID, region);
                            }
                        }
                    }
                }
            }
            return AppGlobal.InitializationDateTimeCode;
        }
        [HttpGet]
        public string InitializationBySEOKeywordIDAndCountryID(int sEOKeywordID, string countryID)
        {
            string region = AppGlobal.InitializationString;
            if (countryID.ToLower() == AppGlobal.CountryIDUS.ToLower())
            {
                region = "taus";
            }
            else
            {
                region = "international";
            }
            SEOKeyword itemSEOKeyword = _sEOKeywordRepository.GetByID(sEOKeywordID);
            List<Designer> listDesigner = _designerRepository.GetByIsActive001ToList(true);
            List<SEOBlogTemplate> listSEOBlogTemplate = _sEOBlogTemplateRepository.GetByActiveToList(true);
            Country country = _countryRepository.GetByID(Guid.Parse(countryID));
            Designer designer = new Designer();
            SEOBlogTemplate sEOBlogTemplate = new SEOBlogTemplate();
            SEOBlog sEOBlog = new SEOBlog();
            int result = AppGlobal.InitializationNumber;
            int listDesignerItem = AppGlobal.InitializationNumber;
            int listSEOBlogTemplateItem = AppGlobal.InitializationNumber;
            Random listDesignerRandom = new Random();
            Random listSEOBlogTemplateRandom = new Random();

            int listDesignerCount = listDesigner.Count;
            int listSEOBlogTemplateCount = listSEOBlogTemplate.Count;
            if ((listDesignerCount > 0) && (listSEOBlogTemplateCount > 0))
            {
                listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                sEOBlog = new SEOBlog();
                sEOBlog.CountryID = country.ID.ToString();
                sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                sEOBlog.KeywordID = itemSEOKeyword.ID;
                sEOBlog.Active = true;
                result = _sEOBlogRepository.Add(sEOBlog);
                if (sEOBlog.ID > 0)
                {
                    _sEOBlogTypeRepository.InitializationByParentID(sEOBlog.ID);
                    _sEOBlogStoreRepository.InitializationByParentID(sEOBlog.ID);
                    _sEOBlogItemRepository.InitializationByParentIDAndRegion(sEOBlog.ID, region);
                }
                List<Region> listRegion = _regionRepository.GetByCountryIDToList(country.ID.Value);
                foreach (Region itemRegion in listRegion)
                {
                    listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                    listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                    sEOBlog = new SEOBlog();
                    sEOBlog.CountryID = country.ID.ToString();
                    sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                    sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                    sEOBlog.KeywordID = itemSEOKeyword.ID;
                    sEOBlog.RegionID = itemRegion.ID.ToString();
                    sEOBlog.Active = true;
                    result = _sEOBlogRepository.Add(sEOBlog);
                    if (sEOBlog.ID > 0)
                    {
                        _sEOBlogTypeRepository.InitializationByParentID(sEOBlog.ID);
                        _sEOBlogStoreRepository.InitializationByParentID(sEOBlog.ID);
                        _sEOBlogItemRepository.InitializationByParentIDAndRegion(sEOBlog.ID, region);
                    }
                    List<City> listCity = _cityRepository.GetByRegionIDToList(itemRegion.ID.Value);
                    foreach (City itemCity in listCity)
                    {
                        listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                        listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                        sEOBlog = new SEOBlog();
                        sEOBlog.CountryID = country.ID.ToString();
                        sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                        sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                        sEOBlog.KeywordID = itemSEOKeyword.ID;
                        sEOBlog.RegionID = itemRegion.ID.ToString();
                        sEOBlog.CityID = itemCity.ID.ToString();
                        sEOBlog.Active = true;
                        result = _sEOBlogRepository.Add(sEOBlog);
                        if (sEOBlog.ID > 0)
                        {
                            _sEOBlogTypeRepository.InitializationByParentID(sEOBlog.ID);
                            _sEOBlogStoreRepository.InitializationByParentID(sEOBlog.ID);
                            _sEOBlogItemRepository.InitializationByParentIDAndRegion(sEOBlog.ID, region);
                        }
                    }
                }
            }
            return AppGlobal.InitializationDateTimeCode;
        }
        [HttpGet]
        public async Task<string> AsyncInitializationInUS()
        {
            List<SEOKeyword> listSEOKeyword = _sEOKeywordRepository.GetByActiveToList(true);
            List<Designer> listDesigner = _designerRepository.GetByIsActive001ToList(true);
            List<SEOBlogTemplate> listSEOBlogTemplate = _sEOBlogTemplateRepository.GetByActiveToList(true);
            Country country = _countryRepository.GetByID(Guid.Parse(AppGlobal.CountryIDUS));
            Designer designer = new Designer();
            SEOBlogTemplate sEOBlogTemplate = new SEOBlogTemplate();
            SEOBlog sEOBlog = new SEOBlog();
            int result = AppGlobal.InitializationNumber;
            int listDesignerItem = AppGlobal.InitializationNumber;
            int listSEOBlogTemplateItem = AppGlobal.InitializationNumber;
            Random listDesignerRandom = new Random();
            Random listSEOBlogTemplateRandom = new Random();

            int listDesignerCount = listDesigner.Count;
            int listSEOBlogTemplateCount = listSEOBlogTemplate.Count;
            if ((listDesignerCount > 0) && (listSEOBlogTemplateCount > 0))
            {
                foreach (SEOKeyword itemSEOKeyword in listSEOKeyword)
                {
                    listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                    listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                    sEOBlog = new SEOBlog();
                    sEOBlog.CountryID = country.ID.ToString();
                    sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                    sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                    sEOBlog.KeywordID = itemSEOKeyword.ID;
                    sEOBlog.Active = true;
                    result = _sEOBlogRepository.Add(sEOBlog);
                    if (sEOBlog.ID > 0)
                    {
                        await _sEOBlogTypeRepository.AsyncInitializationByParentID(sEOBlog.ID);
                        await _sEOBlogStoreRepository.AsyncInitializationByParentID(sEOBlog.ID);
                        await _sEOBlogItemRepository.AsyncInitializationByParentID(sEOBlog.ID);
                    }
                    List<Region> listRegion = _regionRepository.GetByCountryIDToList(country.ID.Value);
                    foreach (Region itemRegion in listRegion)
                    {
                        listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                        listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                        sEOBlog = new SEOBlog();
                        sEOBlog.CountryID = country.ID.ToString();
                        sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                        sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                        sEOBlog.KeywordID = itemSEOKeyword.ID;
                        sEOBlog.RegionID = itemRegion.ID.ToString();
                        sEOBlog.Active = true;
                        result = _sEOBlogRepository.Add(sEOBlog);
                        if (sEOBlog.ID > 0)
                        {
                            await _sEOBlogTypeRepository.AsyncInitializationByParentID(sEOBlog.ID);
                            await _sEOBlogStoreRepository.AsyncInitializationByParentID(sEOBlog.ID);
                            await _sEOBlogItemRepository.AsyncInitializationByParentID(sEOBlog.ID);
                        }
                        List<City> listCity = _cityRepository.GetByRegionIDToList(itemRegion.ID.Value);
                        foreach (City itemCity in listCity)
                        {
                            listDesignerItem = listDesignerRandom.Next(listDesignerCount);
                            listSEOBlogTemplateItem = listSEOBlogTemplateRandom.Next(listSEOBlogTemplateCount);
                            sEOBlog = new SEOBlog();
                            sEOBlog.CountryID = country.ID.ToString();
                            sEOBlog.DesignerID = listDesigner[listDesignerItem].ID.ToString();
                            sEOBlog.SEOBlogTemplateID = listSEOBlogTemplate[listSEOBlogTemplateItem].ID;
                            sEOBlog.KeywordID = itemSEOKeyword.ID;
                            sEOBlog.RegionID = itemRegion.ID.ToString();
                            sEOBlog.CityID = itemCity.ID.ToString();
                            sEOBlog.Active = true;
                            result = _sEOBlogRepository.Add(sEOBlog);
                            if (sEOBlog.ID > 0)
                            {
                                await _sEOBlogTypeRepository.AsyncInitializationByParentID(sEOBlog.ID);
                                await _sEOBlogStoreRepository.AsyncInitializationByParentID(sEOBlog.ID);
                                await _sEOBlogItemRepository.AsyncInitializationByParentID(sEOBlog.ID);
                            }
                        }
                    }
                }
            }
            return AppGlobal.InitializationDateTimeCode;
        }
        [HttpGet]
        public async Task<string> AsyncInitializationSEOBlogItemBySEOKeywordIDAndCountryID(int sEOKeywordID, string countryID)
        {
            string region = AppGlobal.InitializationString;
            if (countryID.ToLower() == AppGlobal.CountryIDUS.ToLower())
            {
                region = "taus";
            }
            else
            {
                region = "international";
            }
            List<SEOBlog> listSEOBlog = _sEOBlogRepository.GetByKeywordIDAndCountryIDAndActiveToList(sEOKeywordID, countryID, true);
            foreach (SEOBlog sEOBlog in listSEOBlog)
            {
                await _sEOBlogItemRepository.AsyncInitializationByParentIDAndRegion(sEOBlog.ID, region);
            }
            return AppGlobal.InitializationDateTimeCode;
        }
        [HttpGet]
        public SEOBlog GetByID(int ID)
        {
            SEOBlog result = _sEOBlogRepository.GetByID(ID);
            if (result == null)
            {
                result = new SEOBlog();
                result.Active = true;
            }
            return result;
        }
        [HttpGet]
        public SEOBlog GetByIDString(string ID)
        {
            SEOBlog result = new SEOBlog();
            try
            {
                ID = ID.Split('.')[0];
                ID = ID.Split('/')[ID.Split('/').Length - 1];
                result = _sEOBlogRepository.GetByID(int.Parse(ID));
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            if (result == null)
            {
                result = new SEOBlog();
                result.Active = true;
            }
            return result;
        }
    }
}

