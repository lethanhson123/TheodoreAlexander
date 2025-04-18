﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TA.Data.Models;

namespace TA.Data.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        public int Add(T model);
        public Task<int> AsyncAdd(T model);
        public int Update(T model);
        public Task<int> AsyncUpdate(T model);
        public int AddRange(List<T> list);
        public Task<int> AsyncAddRange(List<T> list);
        public int RemoveRange(List<T> list);
        public Task<int> AsyncRemoveRange(List<T> list);
        public List<T> GetAllToList();
        public Task<List<T>> AsyncGetAllToList();
        public List<T> GetByPageAndPageSizeToList(int page, int pageSize);
        public Task<List<T>> AsyncGetByPageAndPageSizeToList(int page, int pageSize);
    }
}
