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
    public class Feature2DRepository : Repository<Feature2D>, IFeature2DRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Feature2DRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override List<Feature2D> GetAllToList()
        {
            List<Feature2D> result = new List<Feature2D>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_2DfeatureSelectAllItems");
            result = SQLHelper.ToList<Feature2D>(dt);
            return result;
        }

    }
}