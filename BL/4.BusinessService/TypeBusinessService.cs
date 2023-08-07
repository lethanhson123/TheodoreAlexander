using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using BL.Dto;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class TypeBusinessService : ITABusinessService<TypeDto, DAL.Type, Guid>
    {
        private readonly TypeEntityService _modelService;

        public TypeBusinessService(TypeEntityService modelService) : base (modelService)
        {
            _modelService = modelService;
        }

        public override bool Add(TypeDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<TypeDto> Get()
        {
            try
            {
                var dtos = _modelService.Get().OrderBy(i => i.Name).Select(TypeDto.Entity2DtoSelector);
                return dtos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IQueryable<TypeDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(TypeDto t)
        {
            throw new NotImplementedException();
        }
    }
}