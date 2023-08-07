using System;
using DAL;

namespace BL.DTO
{
    public class SubCollectionDto
    {
        public System.Guid Collection_ID { get; set; }

        public Nullable<System.Guid> Brand_ID { get; set; }

        public Nullable<System.Guid> ParentCollection_ID { get; set; }

        public CollectionDto Collection { get; set; }
    }
}