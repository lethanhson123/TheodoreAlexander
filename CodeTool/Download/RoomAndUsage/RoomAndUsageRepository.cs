using TA.Data.Models;
namespace TA.Data.Repositories
{
public class RoomAndUsageRepository : Repository<RoomAndUsage>, IRoomAndUsageRepository
{
private readonly TheodoreAlexander_NewContext _context;
public RoomAndUsageRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

