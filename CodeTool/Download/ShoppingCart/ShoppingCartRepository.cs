using TA.Data.Models;
namespace TA.Data.Repositories
{
public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
private readonly TheodoreAlexander_NewContext _context;
public ShoppingCartRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

