using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly TheodoreAlexander_NewContext _context;

        public Repository(TheodoreAlexander_NewContext context)
        {
            _context = context;
        }
        public virtual void Initialization(T model)
        {
        }
        public virtual int Add(T model)
        {
            Initialization(model);
            _context.Set<T>().Add(model);
            return _context.SaveChanges();
        }
        public async Task<int> AsyncAdd(T model)
        {
            Initialization(model);
            _context.Set<T>().Add(model);
            return await _context.SaveChangesAsync();
        }
        public virtual int Update(T model)
        {
            int result = AppGlobal.InitializationNumber;
            if (model != null)
            {
                _context.Set<T>().Update(model);
                result = _context.SaveChanges();
            }
            return result;
        }
        public async Task<int> AsyncUpdate(T model)
        {
            int result = AppGlobal.InitializationNumber;
            if (model != null)
            {
                _context.Set<T>().Update(model);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        public int AddRange(List<T> list)
        {
            _context.Set<T>().AddRange(list);
            return _context.SaveChanges();
        }
        public async Task<int> AsyncAddRange(List<T> list)
        {
            _context.Set<T>().AddRange(list);
            return await _context.SaveChangesAsync();
        }
        public int RemoveRange(List<T> list)
        {
            _context.Set<T>().RemoveRange(list);
            return _context.SaveChanges();
        }
        public async Task<int> AsyncRemoveRange(List<T> list)
        {
            _context.Set<T>().RemoveRange(list);
            return await _context.SaveChangesAsync();
        }       
        public virtual List<T> GetAllToList()
        {
            var result = _context.Set<T>().ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> AsyncGetAllToList()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result ?? new List<T>();
        }
        public List<T> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _context.Set<T>().Skip(page * pageSize).Take(pageSize).ToList();
            return result;
        }
        public async Task<List<T>> AsyncGetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = await _context.Set<T>().Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result;
        }
    }
}
