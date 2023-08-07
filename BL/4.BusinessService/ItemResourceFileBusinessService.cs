using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class ItemResourceFileBusinessService
    {
        private bool disposed = false;
        private readonly ItemResourceFileEntityService _itemResourceFileModelService;

        public ItemResourceFileBusinessService(ItemResourceFileEntityService itemResourceFileModelService)
        {
            _itemResourceFileModelService = itemResourceFileModelService;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _itemResourceFileModelService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<ItemResourceFileDto> GetAll()
        {
            try
            {
                var ret = _itemResourceFileModelService.Get().Select(e => new ItemResourceFileDto() {
                    ID = e.ID,
                    Name = e.Name,
                    Category = e.Category,
                    IsEnabled = e.IsEnabled,
                    Title = e.Title,
                    URL = e.URL,
                    ModifiedBy = e.ModifiedBy,
                    ModifiedDate = e.ModifiedDate,
                    Property = e.Property
                }).OrderByDescending(e => e.ModifiedDate).ToList();
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ItemResourceFileDto GetByID(Guid id)
        {
            try
            {
                ItemResourceFileDto dto = _itemResourceFileModelService.Get(id).Select(ItemResourceFileDto.DTOFromEntityConverter).FirstOrDefault();
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(ItemResourceFileDto dto)
        {
            try
            {
                ItemResourceFile item = _itemResourceFileModelService.Get(dto.ID).FirstOrDefault();
                if (item != null)
                {
                    item.Name = dto.Name;
                    item.IsEnabled = dto.IsEnabled;
                    item.Title = dto.Title;
                    item.URL = dto.URL;
                    item.Category = dto.Category;
                    item.ModifiedBy = dto.ModifiedBy;
                    item.ModifiedDate = dto.ModifiedDate;
                    item.Property = dto.Property;
                    return _itemResourceFileModelService.Update(item);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Guid? Add(ItemResourceFileDto dto)
        {
            try
            {
                ItemResourceFile item = new ItemResourceFile()
                {
                    ID = Guid.NewGuid(),
                    Name = dto.Name,
                    IsEnabled = dto.IsEnabled,
                    Title = dto.Title,
                    URL = dto.URL,
                    Category = dto.Category,
                    ModifiedBy = dto.ModifiedBy,
                    Property = dto.Property,
                    ModifiedDate = dto.ModifiedDate
            };
                if (_itemResourceFileModelService.Add(item))
                {
                    return item.ID;
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

        public bool Delete(Guid id)
        {
            try
            {
                return _itemResourceFileModelService.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}