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
    public class ColourAndFinishRepository : Repository<ColourAndFinish>, IColourAndFinishRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public ColourAndFinishRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override List<ColourAndFinish> GetAllToList()
        {
            List<ColourAndFinish> result = new List<ColourAndFinish>();
            result = _context.Set<ColourAndFinish>().OrderBy(model => model.Name).ToList();
            return result;
        }

    }
}