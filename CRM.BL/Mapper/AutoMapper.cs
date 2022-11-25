using AutoMapper;
using CRM.Core.DTOs;
using CRM.Core.Entities;
namespace CRM.BL.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, EditCustomerDto>().ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressDTO>().ReverseMap();
        }
    }
}
