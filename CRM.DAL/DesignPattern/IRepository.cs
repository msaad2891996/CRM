using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.DesignPattern
{
    public interface IRepository<T> where T : class
    {
        public bool Add(T entity);
        public bool AddRange(List<T> entity);
        public T GetById(int id);
        public T GetByIdDetched(int id);

        public bool Edit(T entity);

        public IQueryable<T> GetAll();
        public IQueryable<T> GetAllAsNoTracking();
        public bool Delete(T entity);
        public bool DeleteRange(List<T> entity);
        public void DeleteRangeWithoutSaveChange(List<T> entity);

    }
}
