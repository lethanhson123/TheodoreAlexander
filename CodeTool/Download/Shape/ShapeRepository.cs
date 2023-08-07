using TA.Data.Models;
namespace TA.Data.Repositories
{
public class ShapeRepository : Repository<Shape>, IShapeRepository
{
private readonly TheodoreAlexander_NewContext _context;
public ShapeRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

