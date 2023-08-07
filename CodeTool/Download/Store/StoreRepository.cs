using TA.Data.Models;
namespace TA.Data.Repositories
{
public class StoreRepository : Repository<Store>, IStoreRepository
{
private readonly TheodoreAlexander_NewContext _context;
public StoreRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

