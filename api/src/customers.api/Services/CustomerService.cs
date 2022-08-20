using Customers.Api.Models;
using Customers.Api.Services.Interface;
using Customers.Data.Dto;
using Customers.Data.Interface;
using AutoMapper;
using System.Collections.Generic;
using System;
using Customers.Api.Util;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Web;

namespace Customers.Api.Services
{
    public class CustomerService : GenericService<CustomerModel, CustomerDto>, ICustomerService
    {
        protected readonly ICustomerRepository<CustomerDto> _customerRepository;

        public CustomerService(
            IMapper mapper,
            IGenericRepository<CustomerDto> repository,
            ICustomerRepository<CustomerDto> customerRepository) : base(mapper, repository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerModel GetCustomerDetail(int id) =>
            _mapper.Map<CustomerDto, CustomerModel>(_customerRepository.GetCustomerDetail(id));

        public IEnumerable<CustomerModel> GetCustomersWhere(string filters)
        {
            if (string.IsNullOrWhiteSpace(filters))
                return GetAll();

            var (name, statusId) = FilterHelper.BuildFilters(HttpUtility.UrlDecode(filters));

            var results = _customerRepository.GetWhere(name, statusId);

            return _mapper.Map<IEnumerable<CustomerDto>, IEnumerable<CustomerModel>>(results);
        }

        
    }
}
