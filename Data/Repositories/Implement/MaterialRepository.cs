using TA.Data.Models;
namespace TA.Data.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public MaterialRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
    }
}

