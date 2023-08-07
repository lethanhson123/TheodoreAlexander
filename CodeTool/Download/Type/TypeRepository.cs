using TA.Data.Models;
namespace TA.Data.Repositories
{
public class TypeRepository : Repository<Type>, ITypeRepository
{
private readonly TheodoreAlexander_NewContext _context;
public TypeRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

