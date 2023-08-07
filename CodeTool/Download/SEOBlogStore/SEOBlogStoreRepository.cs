using TA.Data.Models;
namespace TA.Data.Repositories
{
public class SEOBlogStoreRepository : Repository<SEOBlogStore>, ISEOBlogStoreRepository
{
private readonly TheodoreAlexander_NewContext _context;
public SEOBlogStoreRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

