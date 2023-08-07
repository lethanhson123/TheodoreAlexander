using TA.Data.Models;
namespace TA.Data.Repositories
{
public class UPHFabricRepository : Repository<UPHFabric>, IUPHFabricRepository
{
private readonly TheodoreAlexander_NewContext _context;
public UPHFabricRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

