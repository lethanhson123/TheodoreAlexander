using TA.Data.Models;
namespace TA.Data.Repositories
{
public class CityRepository : Repository<City>, ICityRepository
{
private readonly TheodoreAlexander_NewContext _context;
public CityRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

