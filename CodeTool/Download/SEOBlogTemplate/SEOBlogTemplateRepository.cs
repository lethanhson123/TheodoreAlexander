using TA.Data.Models;
namespace TA.Data.Repositories
{
public class SEOBlogTemplateRepository : Repository<SEOBlogTemplate>, ISEOBlogTemplateRepository
{
private readonly TheodoreAlexander_NewContext _context;
public SEOBlogTemplateRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

