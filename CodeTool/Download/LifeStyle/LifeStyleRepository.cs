using TA.Data.Models;
namespace TA.Data.Repositories
{
public class LifeStyleRepository : Repository<LifeStyle>, ILifeStyleRepository
{
private readonly TheodoreAlexander_NewContext _context;
public LifeStyleRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

