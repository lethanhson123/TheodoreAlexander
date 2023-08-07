using TA.Data.Models;
namespace TA.Data.Repositories
{
public class CollectionRepository : Repository<Collection>, ICollectionRepository
{
private readonly TheodoreAlexander_NewContext _context;
public CollectionRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

