using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_Recruitment_IntroduceRepository : Repository<HR_Recruitment_Introduce>, IHR_Recruitment_IntroduceRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_Recruitment_IntroduceRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

