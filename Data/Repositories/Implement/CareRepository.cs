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
    public class CareRepository : Repository<Care>, ICareRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public CareRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override List<Care> GetAllToList()
        {
            List<Care> result = new List<Care>();
            result = _context.Set<Care>().OrderBy(model => model.Name).ToList();
            return result;
        }

    }
}