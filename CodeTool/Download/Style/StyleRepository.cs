using TA.Data.Models;
namespace TA.Data.Repositories
{
public class StyleRepository : Repository<Style>, IStyleRepository
{
private readonly TheodoreAlexander_NewContext _context;
public StyleRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

