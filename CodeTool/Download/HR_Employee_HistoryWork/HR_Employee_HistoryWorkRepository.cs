using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_Employee_HistoryWorkRepository : Repository<HR_Employee_HistoryWork>, IHR_Employee_HistoryWorkRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_Employee_HistoryWorkRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

