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
    public class RoomAndUsageBusinessService : ITABusinessService<RoomAndUsageDto, RoomAndUsage, Guid>
    {
        private readonly RoomEntityService _modelService;

        public RoomAndUsageBusinessService(RoomEntityService modelService) : base (modelService)
        {
            _modelService = modelService;
        }

        public override bool Add(RoomAndUsageDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<RoomAndUsageDto> Get()
        {
            try
            {
                var dtos = _modelService.Get().OrderBy(i => i.Name).Select(RoomAndUsageDto.Entity2DtoSelector);
                return dtos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IQueryable<RoomAndUsageDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(RoomAndUsageDto t)
        {
            throw new NotImplementedException();
        }
    }
}