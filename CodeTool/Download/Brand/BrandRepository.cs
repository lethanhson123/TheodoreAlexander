using TA.Data.Models;
namespace TA.Data.Repositories
{
public class BrandRepository : Repository<Brand>, IBrandRepository
{
private readonly TheodoreAlexander_NewContext _context;
public BrandRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

