using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_DutyRepository : Repository<HR_Duty>, IHR_DutyRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_DutyRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

