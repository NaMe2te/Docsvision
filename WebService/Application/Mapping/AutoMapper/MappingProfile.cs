using Application.Dtos;
using Application.Utilities;
using AutoMapper;
using Castle.Core.Resource;
using DataAccess.CodeForms.Enums;
using DataAccess.Entities;

namespace Application.Mapping.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMessageMap();
        CreateEmployeeMap();
        CreateAccountMap();
    }

    private void CreateMessageMap()
    {
        CreateMap<Message, MessageDto>()
            .ForMember(dest => dest.Addressee, 
                opt => opt.MapFrom(src => src.Addressee))
            .ReverseMap();
    }

    private void CreateEmployeeMap()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => src.Department.ToString("G")))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(stc => stc.Account.Email))
        .ReverseMap()
            .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => ParseUtility.ParseEnum<Department>(src.Department)));

        CreateMap<Employee, EmployeeProfileDto>();
    }

    private void CreateAccountMap()
    {
        CreateMap<AccountDto, Account>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    } 
}