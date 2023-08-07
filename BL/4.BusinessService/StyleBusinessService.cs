using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class StyleBusinessService : ITABusinessService<StyleDto, Style, Guid>
    {
        private readonly StyleEntityService _modelService;

        public StyleBusinessService(StyleEntityService modelService) : base (modelService)
        {
            _modelService = modelService;
        }

        public override bool Add(StyleDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<StyleDto> Get()
        {
            try
            {
                var dtos = _modelService.Get().OrderBy(i => i.Name).Select(StyleDto.Entity2DtoSelector);
                return dtos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IQueryable<StyleDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(StyleDto t)
        {
            throw new NotImplementedException();
        }
    }
}