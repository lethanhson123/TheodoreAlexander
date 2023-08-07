using TA.Data.Models;
namespace TA.Data.Repositories
{
public class ShoppingCart_ItemRepository : Repository<ShoppingCart_Item>, IShoppingCart_ItemRepository
{
private readonly TheodoreAlexander_NewContext _context;
public ShoppingCart_ItemRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

