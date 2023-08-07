using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_Recruitment_CareerRepository : Repository<HR_Recruitment_Career>, IHR_Recruitment_CareerRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_Recruitment_CareerRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

