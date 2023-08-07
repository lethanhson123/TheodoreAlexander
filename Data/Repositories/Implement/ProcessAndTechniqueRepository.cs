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
    public class ProcessAndTechniqueRepository : Repository<ProcessAndTechnique>, IProcessAndTechniqueRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public ProcessAndTechniqueRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override List<ProcessAndTechnique> GetAllToList()
        {
            List<ProcessAndTechnique> result = new List<ProcessAndTechnique>();
            result = _context.Set<ProcessAndTechnique>().OrderBy(model => model.Name).ToList();
            return result;
        }

    }
}