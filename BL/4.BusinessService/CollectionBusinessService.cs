using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class CollectionBusinessService : ITABusinessService<CollectionDto, Collection, Guid>
    {
        private readonly CollectionEntityService _collectionModelService;
        public CollectionBusinessService(CollectionEntityService collectionModelService) : base(collectionModelService)
        {
            _collectionModelService = collectionModelService;
        }

        public override bool Add(CollectionDto t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<CollectionDto> Get()
        {
            return itaModelService.Get().OrderBy(i => i.Name).Select(CollectionDto.Entity2DtoSelector);
        }

        public override IQueryable<CollectionDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(CollectionDto t)
        {
            throw new NotImplementedException();
        }
    }
}