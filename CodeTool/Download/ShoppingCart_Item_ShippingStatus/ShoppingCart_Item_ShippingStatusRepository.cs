using TA.Data.Models;
namespace TA.Data.Repositories
{
public class ShoppingCart_Item_ShippingStatusRepository : Repository<ShoppingCart_Item_ShippingStatus>, IShoppingCart_Item_ShippingStatusRepository
{
private readonly TheodoreAlexander_NewContext _context;
public ShoppingCart_Item_ShippingStatusRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

