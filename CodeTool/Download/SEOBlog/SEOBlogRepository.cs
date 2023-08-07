using TA.Data.Models;
namespace TA.Data.Repositories
{
public class SEOBlogRepository : Repository<SEOBlog>, ISEOBlogRepository
{
private readonly TheodoreAlexander_NewContext _context;
public SEOBlogRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

