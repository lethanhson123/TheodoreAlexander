using TA.Data.Models;
namespace TA.Data.Repositories
{
public class System_MembershipRepository : Repository<System_Membership>, ISystem_MembershipRepository
{
private readonly TheodoreAlexander_ERPContext _context;
public System_MembershipRepository(TheodoreAlexander_ERPContext context) : base(context)
{
_context = context;
}
}
}

