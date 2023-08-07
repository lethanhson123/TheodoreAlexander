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
    public class HistoricalStyleRepository : Repository<HistoricalStyle>, IHistoricalStyleRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public HistoricalStyleRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override List<HistoricalStyle> GetAllToList()
        {
            List<HistoricalStyle> result = new List<HistoricalStyle>();
            result = _context.Set<HistoricalStyle>().OrderBy(model => model.Name).ToList();
            return result;
        }

    }
}