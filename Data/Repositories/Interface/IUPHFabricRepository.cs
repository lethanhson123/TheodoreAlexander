using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IUPHFabricRepository : IRepository<UPHFabric>
    {
        public List<UPHFabric> GetByIsFabricAndIsLeatherAndIsTrimsAndSearchStringToList(bool isFabric, bool isLeather, bool isTrims, string searchString);
    }
}

