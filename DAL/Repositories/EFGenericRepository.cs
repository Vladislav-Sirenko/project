using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Interfaces;
using DAL.EF;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class EFGenericRepository<T> : IRepository<T> where T : class
    {
        Final_ProjectContext _context;
        DbSet<T> _dbSet;

        public EFGenericRepository(Final_ProjectContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int? id)
        {
            var item = _dbSet.Find(id.Value);
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}