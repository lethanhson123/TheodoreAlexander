using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class BrandBusinessService : ITABusinessService<BrandDto, Brand, Guid>
    {
        private readonly BrandEntityService _brandModelService;

        public BrandBusinessService(BrandEntityService brandModelService) : base (brandModelService)
        {
            _brandModelService = brandModelService;
        }

        public override IQueryable<BrandDto> Get()
        {
            try
            {
                var brands = _brandModelService.Get().OrderBy(i => i.Name).Select(BrandDto.Entity2DtoSelector);
                return brands;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IQueryable<BrandDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(BrandDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(BrandDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}