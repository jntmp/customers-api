using Customers.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper.FastCrud;
using Microsoft.Extensions.Options;

namespace Customers.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private string ConnectionString { get; }

        public GenericRepository(IOptions<ConfigOptions> config)
        {
            ConnectionString = config.Value.ConnectionString;

            if (config.Value == null || String.IsNullOrWhiteSpace(config.Value.ConnectionString))
                throw new InvalidOperationException();
        }

        protected IDbConnection Database()
        {
            return new SqlConnection(ConnectionString);
        }

        public IEnumerable<T> GetAll()
        {
            return Database().Find<T>();
        }

        public T Get(int id)
        {
            return Database().Get(new { id } as T);
        }

        public void Update(T entity)
        {
            Database().Update(entity);
        }
    }
}
