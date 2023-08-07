using TA.Data.Models;
namespace TA.Data.Repositories
{
public class OptionGroupRepository : Repository<OptionGroup>, IOptionGroupRepository
{
private readonly TheodoreAlexander_NewContext _context;
public OptionGroupRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

