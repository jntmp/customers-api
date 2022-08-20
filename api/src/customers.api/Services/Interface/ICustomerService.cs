using Customers.Api.Models;
using Customers.Data.Dto;
using System.Collections.Generic;

namespace Customers.Api.Services.Interface
{
    public interface ICustomerService : IGenericService<CustomerModel, CustomerDto>
    {
        CustomerModel GetCustomerDetail(int id);
        IEnumerable<CustomerModel> GetCustomersWhere(string filters);
    }
}
