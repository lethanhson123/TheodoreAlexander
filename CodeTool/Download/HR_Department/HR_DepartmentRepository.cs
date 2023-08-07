using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_DepartmentRepository : Repository<HR_Department>, IHR_DepartmentRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_DepartmentRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

