using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.CustomExceptions;
using BL.EntityService;
using DAL;
using DAL.ViewModels;
using BL.Extensions;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class LocatorBusinessService
    {
        private bool disposed = false;
        private readonly StoreEntityService _storeServices;
        private readonly CountryEntityService _countryServices;
        private readonly RegionEntityService _regionServices;
        private readonly CityEntityServices _cityServices;
        private readonly DealerEntityService _dealerServices;

        public LocatorBusinessService(StoreEntityService storeServices, 
            CountryEntityService countryServices, 
            RegionEntityService regionServices, 
            CityEntityServices cityServices,
            DealerEntityService dealerServices)
        {
            _storeServices = storeServices;
            _countryServices = countryServices;
            _regionServices = regionServices;
            _cityServices = cityServices;
            _dealerServices = dealerServices;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _storeServices.Dispose();
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<PageResult<LocatorViewModel>> PaginationLocaton(PaginationRequestStoreObj paginationRequestStore)
        {
            if (String.IsNullOrEmpty(paginationRequestStore.KeySearch))
            {
                throw new BadRequestException(ConstClass.ConstException.BadRequestMess);
            }
            try
            {
                var lstStore = _storeServices.GetStores();
                //Setup pagination properties
                int count = await lstStore.CountAsync();
                int currentPage = paginationRequestStore.PageNum;
                int pageSize = paginationRequestStore.PageSize;
                int totalCount = count;
                int totalPages = (int)Math.Ceiling(count / (double)pageSize);
                int skip = (currentPage - 1) * pageSize;
                var previousPage = currentPage > 1 ? true : false;
                var nextPage = currentPage < totalPages ? true : false;

                var pagingItems = await lstStore
                    .OrderByPropertyOrField(paginationRequestStore.OrderBy, paginationRequestStore.Ascending)
                    .OrderBy(o => o.Name)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToListAsync();
                try
                {
                    List<LocatorViewModel> lstViewModel = new List<LocatorViewModel>();
                    lstViewModel = SelectLocation(pagingItems);
                    PageResult<LocatorViewModel> result = new PageResult<LocatorViewModel>()
                    {
                        Items = lstViewModel,
                        TotalCount = totalCount,
                        TotalPage = totalPages,
                        CurrentPage = currentPage,
                        PreviousPage = previousPage,
                        NextPage = nextPage,
                        PageSize = pageSize
                    };
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LocatorViewModel GetStore(Guid storeId)
        {
            try
            {
                var lstStore = _storeServices.GetStores().Where(s => s.ID == storeId).ToList();
                List<LocatorViewModel> lstViewModel = SelectLocation(lstStore);
                return lstViewModel.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<LocatorViewModel>> GetLocation()
        {
            try
            {
                var lstStore = await _storeServices.GetStores().OrderBy(o => o.Name).ToListAsync();
                List<LocatorViewModel> lstViewModel = SelectLocation(lstStore);
                return lstViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LocatorViewModel> SelectLocation(List<Store> stores)
        {
            List<LocatorViewModel> lstViewModel = new List<LocatorViewModel>();
            lstViewModel = stores.Select(o => new LocatorViewModel
            {
                ID = o.ID,
                Email = o.Email,
                Website = o.Website,
                Phone = o.Phone,
                Fax = o.Fax,
                PostalCode = o.PostalCode,
                StoreName = o.Name,
                Address1 = o.Address1,
                Address2 = o.Address2,
                StoreCoordinate = o.StoreCoordinates.Select(s => new StoreCoordinateViewModel
                {
                    Longitude = s.Longitude,
                    Latitude = s.Latitude,
                    Address = s.Address,
                    GoogleAddress = s.GoogleAddress,
                    GoogleURL = s.GoogleUrl
                }).FirstOrDefault(),
                CityId = o.City_ID,
                CityLongitude = o.City.Longitude,
                CityLatitude = o.City.Latitude,
                CityName = o.City.Name,
                RegionName = o.City.Region.Name,
                CountryName = o.City.Region.Country.Name,
                ContinentName = o.City.Region.Country.Continent1.Name,
                IsPreferred = o.IsPreferred,
                IsAlexaHampton = o.IsAlexaHampton,
                IsAlthorpLivingHistory = o.IsAlthorpLivingHistory,
                IsSalone = o.IsSalone,
                IsTAStudio = o.IsTAStudio,
                IsUpholstery = o.IsUpholstery,
                IsRalphLauren = o.IsRalphLauren
            })
                .Where(s => s.StoreCoordinate != null && s.StoreCoordinate.Latitude != 0 && s.StoreCoordinate.Longitude != 0)
                .ToList();
            return lstViewModel;
        }

        public IQueryable<CountrySelectBoxModel> GetSelectBoxCountries()
        {
            var result = _countryServices.GetCountries().Where(c => c.Regions.Count > 0).Select(o => new CountrySelectBoxModel { ID = o.ID, Name = o.Name });
            return result;
        }

        public async Task<IList<RegionSelectBoxModel>> GetSelectBoxRegionsByCountryId(Guid countryId)
        {
            var result = await _regionServices.GetRegions().Where(o => o.Country_ID == countryId && o.Cities.Count > 0).Select(c => new RegionSelectBoxModel { ID = c.ID, Name = c.Name }).ToListAsync();
            return result;
        }

        public async Task<IList<CitySelectBoxModel>> GetSelectBoxCitiesByRegionId(Guid regionId)
        {
            var result = await _cityServices.GetCities().Where(o => o.Region_ID == regionId).Select(c => new CitySelectBoxModel { ID = c.ID, Name = c.Name }).ToListAsync();
            return result;
        }

        public List<CityRegionCountryModel> GetCityRegionCountry(String cityName)
        {
            var result = _cityServices.GetCities().Where(o => o.Name.Contains(cityName)).Select(o => new CityRegionCountryModel
            {
                City = new CitySelectBoxModel { ID = o.ID, Name = o.Name },
                Region = new RegionSelectBoxModel { ID = o.Region.ID, Name = o.Region.Name },
                Country = new CountrySelectBoxModel { ID = o.Region.Country.ID, Name = o.Region.Country.Name }
            }
            ).ToList();
            return result;
        }

        public async Task<StoreViewModel> GetMainStoreByUserId(Guid? userId)
        {
            var store = await _dealerServices.GetDealerByUserId_Queryable(userId).Select(o => o.Stores.FirstOrDefault()).FirstOrDefaultAsync();
            StoreViewModel result = new StoreViewModel();
            if(store != null)
            {
                result.ID = store.ID;
                result.Name = store.Name;
                result.Phone = store.Phone;
                result.Email = store.Email;
                result.Website = store.Website;
                result.PostalCode = store.PostalCode;
                result.DateModified = store.DateModified;
                result.Address1 = store.Address1;
                result.Address2 = store.Address2;
                result.CityName = store.City.Name;
                result.RegionName = store.City.Region.Name;
                result.CountryName = store.City.Region.Country.Name;
            }
            return result;
        }
    }
}
