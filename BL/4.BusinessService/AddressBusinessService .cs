using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class AddressBusinessService : ITABusinessService<AddressDto, Address, Guid>
    {
        private readonly AddressEntityService _addressEntityService;

        public AddressBusinessService(AddressEntityService addressEntityService) : base (addressEntityService)
        {
            _addressEntityService = addressEntityService;
        }

        public IQueryable<AddressDto> GetAddressOfUser(Guid userId) {
            try
            {
                return _addressEntityService.Get().Where(add => add.User_ID == userId).OrderByDescending(add => add.IsShipping).ThenByDescending(add=>add.IsBilling).ThenByDescending(add => add.IsActive).ToList().AsQueryable().Select(AddressDto.Entity2DtoSelector);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<AddressDto> GetActiveAddressOfUser(Guid userId)
        {
            try
            {
                return _addressEntityService.Get().Where(add => add.User_ID == userId && add.IsActive == true).OrderByDescending(add => add.IsShipping).ThenByDescending(add => add.IsBilling).ToList().AsQueryable().Select(AddressDto.Entity2DtoSelector);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IQueryable<AddressDto> Get()
        {
            try
            {
                var ret = _addressEntityService.Get().OrderBy(i => i.Name).Select(AddressDto.Entity2DtoSelector);
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IQueryable<AddressDto> Get(Guid id)
        {
            try
            {
                var ret = _addressEntityService.Get(id).OrderBy(i => i.Name).Select(AddressDto.Entity2DtoSelector);
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override bool Add(AddressDto t)
        {
            try
            {
                Address entity = new List<AddressDto>{t}.AsQueryable().Select(AddressDto.Dto2EntitySelector).FirstOrDefault();
                return _addressEntityService.Add(entity);

            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public override bool Update(AddressDto t)
        {
            try
            {
                Address entity = new List<AddressDto> { t }.AsQueryable().Select(AddressDto.Dto2EntitySelector).FirstOrDefault();
                return _addressEntityService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Delete(Guid id)
        {
            try
            {
                return _addressEntityService.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}