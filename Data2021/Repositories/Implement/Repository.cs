using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly TheodoreAlexander_NewContext _context;

        public Repository(TheodoreAlexander_NewContext context)
        {
            _context = context;
        }      
    }
}
