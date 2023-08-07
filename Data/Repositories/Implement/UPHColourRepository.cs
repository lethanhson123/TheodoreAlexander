using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class UPHColourRepository : Repository<UPHColour>, IUPHColourRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public UPHColourRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }               
    }
}

