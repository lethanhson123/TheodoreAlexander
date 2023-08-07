using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_ProvinceRepository : Repository<HR_Province>, IHR_ProvinceRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_ProvinceRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

