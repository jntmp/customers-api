using Customers.Data.Interface;
using Customers.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FastCrud;
using Microsoft.Extensions.Options;

namespace Customers.Data.Repository
{
    public class CustomerNoteRepository<T> : GenericRepository<T>, ICustomerNoteRepository<T> where T : CustomerNoteDto
    {
        public CustomerNoteRepository(IOptions<ConfigOptions> config) : base(config)
        {
            if (config.Value == null || String.IsNullOrWhiteSpace(config.Value.ConnectionString))
                throw new InvalidOperationException();
        }

        public IEnumerable<T> GetCustomerNotes(int customerId)
        {
            var selectParams = new
            {
                CustomerId = customerId
            };

            var notes = Database().Find<T>(q => q
                .Where($"{nameof(CustomerNoteDto.CustomerId):C} = {nameof(selectParams.CustomerId):P}")
                .WithParameters(selectParams));

            return notes;
        }
    }
}
