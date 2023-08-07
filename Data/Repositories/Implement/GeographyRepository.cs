using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class GeographyRepository : Repository<Geography>, IGeographyRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public GeographyRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override List<Geography> GetAllToList()
        {
            List<Geography> result = new List<Geography>();
            result = _context.Set<Geography>().OrderBy(model => model.Name).ToList();
            return result;
        }

    }
}