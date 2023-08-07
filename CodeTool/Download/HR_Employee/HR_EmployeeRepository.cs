using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_EmployeeRepository : Repository<HR_Employee>, IHR_EmployeeRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_EmployeeRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

