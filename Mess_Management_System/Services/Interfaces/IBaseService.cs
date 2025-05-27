using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Mess_Management_System.Services
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
        DataTable GetDataTable();
    }
} 