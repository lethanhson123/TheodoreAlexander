using API.BusinessService;
using BL.BusinessService;
using BL.DTO;
using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using TA_Web_2020_API.ViewModel;

namespace TA_Web_2020_API.TAService
{
    public class AddressTAService : ITAService<AddressViewModel, AddressDto, Address, Guid>
    {
        private readonly AddressBusinessService addressBusinessService;

        public AddressTAService(AddressBusinessService iAddressEntityService) : base(iAddressEntityService)
        {
            addressBusinessService = iAddressEntityService;
        }

        public List<AddressViewModel> GetAddressOfUser(Guid userId)
        {
            try
            {
                return addressBusinessService.GetAddressOfUser(userId).Select(AddressViewModel.Dto2ViewModelSelector).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AddressViewModel GetAddressOfUser(Guid userId, Guid addressId)
        {
            try
            {
                return addressBusinessService.Get(addressId).Where(add => add.User_ID == userId).Select(AddressViewModel.Dto2ViewModelSelector).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AddressViewModel> GetActiveAddressOfUser(Guid userId)
        {
            try
            {
                return addressBusinessService.GetActiveAddressOfUser(userId).Select(AddressViewModel.Dto2ViewModelSelector).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AddressViewModel AddUserAddress(JWTIdentityViewModel jwtModel, AddressViewModel t)
        {
            try
            {
                if (t.UserId == null || t.UserId == Guid.Empty)
                {
                    if (jwtModel != null && jwtModel.UserId.HasValue)
                    {
                        t.UserId = jwtModel.UserId.Value;
                    }
                    else
                    {
                        return null;
                    }
                }
                t.ID = Guid.NewGuid();
                AddressDto dto = new List<AddressViewModel> { t }.AsQueryable().Select(AddressViewModel.ViewModel2DtoSelector).FirstOrDefault();
                if (addressBusinessService.Add(dto))
                {
                    AddressViewModel newAddress = addressBusinessService.Get(dto.ID).Select(AddressViewModel.Dto2ViewModelSelector).FirstOrDefault();
                    return newAddress;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AddressViewModel UpdateUserAddress(JWTIdentityViewModel jwtModel, AddressViewModel t)
        {
            try
            {
                //check owner
                AddressDto dto = addressBusinessService.Get(t.ID).FirstOrDefault();
                if (dto.User_ID != Guid.Empty && dto.User_ID == jwtModel.UserId.Value)
                {
                    AddressDto updatedDto = new List<AddressViewModel> { t }.AsQueryable().Select(AddressViewModel.ViewModel2DtoSelector).FirstOrDefault();
                    if (addressBusinessService.Update(updatedDto))
                    {
                        AddressViewModel updatedAddress = addressBusinessService.Get(dto.ID).Select(AddressViewModel.Dto2ViewModelSelector).FirstOrDefault();
                        return updatedAddress;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUserAddress(JWTIdentityViewModel jwtModel, Guid addressId)
        {
            try
            {
                //check the owner before delete
                AddressDto dto = addressBusinessService.Get(addressId).FirstOrDefault();
                if (dto.User_ID != Guid.Empty && dto.User_ID == jwtModel.UserId.Value) {
                    return addressBusinessService.Delete(addressId);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}