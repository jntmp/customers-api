using Customers.Data.Dto;
using System;
using System.Collections.Generic;

namespace Customers.Data.Interface
{
    public interface ICustomerRepository<T> : IGenericRepository<T> where T : CustomerDto
    {
        T GetCustomerDetail(int customerId);
        IEnumerable<T> GetWhere(string name, int statusId);
    }
}
