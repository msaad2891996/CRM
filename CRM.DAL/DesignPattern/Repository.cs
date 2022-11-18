using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.DesignPattern
{
    public class Repository<T>:IRepository<T> where T : class
    {
        readonly CRMDBContext _dbContext;
        readonly DbSet<T> _dbSet;
        public Repository(CRMDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet=dbContext.Set<T>();
        }
        public bool Add(T entity)
        {
            _dbSet.Add(entity);

            _dbContext.Entry<T>(entity).State = EntityState.Added;

            return SaveChange();
        }


        private bool SaveChange()
        {
            try
            {
                return _dbContext.SaveChanges()>0;
            }
            catch (Exception ex)
            {

                // i will add log here
                return false;
            }
        }
    }
}
