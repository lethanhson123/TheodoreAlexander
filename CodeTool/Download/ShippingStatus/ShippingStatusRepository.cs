using TA.Data.Models;
namespace TA.Data.Repositories
{
public class ShippingStatusRepository : Repository<ShippingStatus>, IShippingStatusRepository
{
private readonly TheodoreAlexander_NewContext _context;
public ShippingStatusRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

