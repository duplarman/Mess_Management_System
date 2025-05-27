using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Mess_Management_System.Models;

namespace Mess_Management_System.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public BaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual DataTable GetDataTable()
        {
            var dataTable = new DataTable();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, property.PropertyType);
            }

            var entities = GetAll();
            foreach (var entity in entities)
            {
                var row = dataTable.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(entity) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
} 