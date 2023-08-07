using TA.Data.Models;
namespace TA.Data.Repositories
{
public class ContinentRepository : Repository<Continent>, IContinentRepository
{
private readonly TheodoreAlexander_NewContext _context;
public ContinentRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

