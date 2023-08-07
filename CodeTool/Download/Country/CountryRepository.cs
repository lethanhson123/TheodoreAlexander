using TA.Data.Models;
namespace TA.Data.Repositories
{
public class CountryRepository : Repository<Country>, ICountryRepository
{
private readonly TheodoreAlexander_NewContext _context;
public CountryRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

