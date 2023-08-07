using TA.Data.Models;
namespace TA.Data.Repositories
{
public class SEOKeywordRepository : Repository<SEOKeyword>, ISEOKeywordRepository
{
private readonly TheodoreAlexander_NewContext _context;
public SEOKeywordRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

