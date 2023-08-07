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
    public class Feature3DRepository : Repository<Feature3D>, IFeature3DRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Feature3DRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public override List<Feature3D> GetAllToList()
        {
            List<Feature3D> result = new List<Feature3D>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_3DfeatureSelectAllItems");
            result = SQLHelper.ToList<Feature3D>(dt);
            return result;
        }

    }
}