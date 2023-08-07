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
    public class CenturyRepository : Repository<Century>, ICenturyRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public CenturyRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override List<Century> GetAllToList()
        {
            List<Century> result = new List<Century>();
            result = _context.Set<Century>().OrderBy(model => model.Name).ToList();
            return result;
        }

    }
}