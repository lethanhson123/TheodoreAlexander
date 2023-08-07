using TA.Data.Models;
namespace TA.Data.Repositories
{
public class SEOBlogItemRepository : Repository<SEOBlogItem>, ISEOBlogItemRepository
{
private readonly TheodoreAlexander_NewContext _context;
public SEOBlogItemRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

