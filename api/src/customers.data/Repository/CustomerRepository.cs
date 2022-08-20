using Customers.Data.Interface;
using Customers.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FastCrud;
using Microsoft.Extensions.Options;

namespace Customers.Data.Repository
{
    public class CustomerRepository<T> : GenericRepository<T>, ICustomerRepository<T> where T : CustomerDto
    {
        public CustomerRepository(IOptions<ConfigOptions> config) : base(config)
        {
            if (config.Value == null || String.IsNullOrWhiteSpace(config.Value.ConnectionString))
                throw new InvalidOperationException();
        }

        public T GetCustomerDetail(int customerId)
        {
            return Database().Get(new { customerId } as T);
        }

        public IEnumerable<T> GetWhere(string name, int statusId)
        {
            var selectParams = new { Name = name, StatusId = statusId };
            
            FormattableString whereName = null;
            FormattableString whereStatusId = null;
            if (!string.IsNullOrWhiteSpace(name))
            {
                whereName = $"{nameof(CustomerDto.Name):C}={nameof(selectParams.Name):P}";
            }
            if (statusId >= 0)
            {
                whereStatusId = $"{nameof(CustomerDto.StatusId):C}={nameof(selectParams.StatusId):P}";
            }

            return Database().Find<T>(statement => statement
                .Where(whereName)
                .Where(whereStatusId)
                .WithParameters(selectParams)
            );
        }
    }
}
