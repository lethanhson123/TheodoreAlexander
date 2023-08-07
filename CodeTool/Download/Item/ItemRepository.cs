using TA.Data.Models;
namespace TA.Data.Repositories
{
public class ItemRepository : Repository<Item>, IItemRepository
{
private readonly TheodoreAlexander_NewContext _context;
public ItemRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

