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
    }
}
