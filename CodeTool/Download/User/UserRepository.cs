using TA.Data.Models;
namespace TA.Data.Repositories
{
public class UserRepository : Repository<User>, IUserRepository
{
private readonly TheodoreAlexander_NewContext _context;
public UserRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

