using AutoMapper;
using BankingManagementSystem.API.ApiModels.InputModel;
using BankingManagementSystem.API.ApiModels.OutputModel;
using BankingManagementSystem.Data.Models;

namespace BankingManagementSystem.API.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<CustomerInputModel, Customer>()
                .ForMember(dest => dest.Loans, opt => opt.Ignore());

            CreateMap<Customer, CustomerModel>();
        }
    }
}
