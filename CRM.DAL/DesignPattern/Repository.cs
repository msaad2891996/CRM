using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.DesignPattern
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly CRMDBContext _dbContext;
        readonly DbSet<T> _dbSet;
        public Repository(CRMDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public bool Add(T entity)
        {
            _dbSet.Add(entity);

            _dbContext.Entry<T>(entity).State = EntityState.Added;

            return SaveChange();
        }

        public bool AddRange(List<T> entity)
        {
           _dbSet.AddRange(entity);
            return SaveChange();
        }

        public bool Delete(T entity)
        {
           _dbSet.Remove(entity);
            return SaveChange();
        }

        public bool DeleteRange(List<T> entity)
        {
           _dbSet.RemoveRange(entity);
            return SaveChange();
        }
        public void DeleteRangeWithoutSaveChange(List<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public bool Edit(T entity)
        {
            _dbContext.Entry<T>(entity).State = EntityState.Modified;

            return SaveChange();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public IQueryable<T> GetAllAsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }
        
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }


        public T GetByIdDetched(int id)
        {
            var entity= _dbSet.Find(id);
            _dbContext.Entry<T>(entity).State = EntityState.Detached;
            return entity;

        }


        private bool SaveChange()
        {
            try
            {
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                // i will add log here
                return false;
            }
        }
    }
}
