using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class LifeStyleBusinessService : ITABusinessService<LifeStyleDto, LifeStyle, Guid>
    {
        private readonly LifeStyleEntityService _modelService;

        public LifeStyleBusinessService(LifeStyleEntityService modelService) : base (modelService)
        {
            _modelService = modelService;
        }

        public override bool Add(LifeStyleDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<LifeStyleDto> Get()
        {
            try
            {
                var dtos = _modelService.Get().OrderBy(i => i.Name).Select(LifeStyleDto.Entity2DtoSelector);
                return dtos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IQueryable<LifeStyleDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(LifeStyleDto t)
        {
            throw new NotImplementedException();
        }
    }
}