using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Data.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T entity);
    }
}
