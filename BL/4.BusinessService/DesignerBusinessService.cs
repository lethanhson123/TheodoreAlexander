using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class DesignerBusinessService : ITABusinessService<DesignerDto, Designer, Guid>
    {
        private readonly DesignerEntityService _designerModelService;

        public DesignerBusinessService(DesignerEntityService designerModelService): base(designerModelService)
        {
            _designerModelService = designerModelService;
        }
        
        public override IQueryable<DesignerDto> Get()
        {
            try
            {
                var designers = _designerModelService.Get().OrderBy(i => i.Name).Select(DesignerDto.Entity2DtoSelector);
                return designers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public override IQueryable<DesignerDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(DesignerDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(DesignerDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}