using TA.Data.Models;
namespace TA.Data.Repositories
{
public class RegionRepository : Repository<Region>, IRegionRepository
{
private readonly TheodoreAlexander_NewContext _context;
public RegionRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

