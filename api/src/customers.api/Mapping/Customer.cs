using AutoMapper;
using Customers.Api.Models;
using Customers.Data.Dto;
using System;

namespace Customers.Api.Mapping
{
    public class Customer : Profile
    {
        public Customer()
        {
            CreateMap<CustomerDto, CustomerModel>()
                .ForMember(dest => dest.Status,
                            opt => opt.MapFrom(src => Enum.Parse<StatusEnum>(src.StatusId.ToString()))
                            );

            CreateMap<CustomerModel, CustomerDto>()
                .ForMember(dest => dest.StatusId,
                            opt => opt.MapFrom(src => src.Status.ToString())
                            );
        }
    }
}
