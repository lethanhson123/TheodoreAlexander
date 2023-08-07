using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_DistrictRepository : Repository<HR_District>, IHR_DistrictRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_DistrictRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

