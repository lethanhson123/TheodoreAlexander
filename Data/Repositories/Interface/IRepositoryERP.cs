using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TA.Data.Models;

namespace TA.Data.Repositories
{
    public interface IRepositoryERP<T> where T : BaseModelERP
    {
        public int Add(T model);
        public Task<int> AsyncAdd(T model);
        public int Update(T model);
        public Task<int> AsyncUpdate(T model);
        public int Remove(int ID);
        public Task<int> AsyncRemove(int ID);
        public int AddRange(List<T> list);
        public Task<int> AsyncAddRange(List<T> list);
        public int RemoveRange(List<T> list);
        public Task<int> AsyncRemoveRange(List<T> list);
        public T GetByID(int ID);
        public Task<T> AsyncGetByID(int ID);
        public List<T> GetAllToList();
        public Task<List<T>> AsyncGetAllToList();
        public List<T> GetByActiveToList(bool active);
        public Task<List<T>> AsyncGetByActiveToList(bool active);
        public List<T> GetByParentIDToList(int parentID);
        public List<T> GetByParentIDAndActiveToList(int parentID, bool active);
        public Task<List<T>> AsyncGetByParentIDToList(int parentID);
        public Task<List<T>> AsyncGetByParentIDAndActiveToList(int parentID, bool active);
        public List<T> GetByPageAndPageSizeToList(int page, int pageSize);
        public Task<List<T>> AsyncGetByPageAndPageSizeToList(int page, int pageSize);
    }
}
