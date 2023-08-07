using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class OptionGroupBusinessService : ITABusinessService<OptionGroupDto, OptionGroup, Guid>
    {
        private readonly OptionGroupEntityService _optionGroupModelService;

        public OptionGroupBusinessService(OptionGroupEntityService optionGroupModelService) : base (optionGroupModelService)
        {
            _optionGroupModelService = optionGroupModelService;
        }

        public override IQueryable<OptionGroupDto> Get()
        {
            try
            {
                var optionGroups = _optionGroupModelService.Get().OrderBy(o => o.Name).ThenBy(o => o.GroupName).Select(OptionGroupDto.Entity2DtoSelector);
                return optionGroups;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IQueryable<OptionGroupDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(OptionGroupDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(OptionGroupDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}