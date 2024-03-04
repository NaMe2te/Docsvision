using Application.Dtos;
using Application.Utilities;
using AutoMapper;
using DataAccess.CodeForms.Enums;
using DataAccess.Entities;

namespace Application.Mapping.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMessageMap();
        CreateEmployeeMap();
    }

    private void CreateMessageMap()
    {
        CreateMap<Message, MessageDto>().ReverseMap();
    }

    private void CreateEmployeeMap()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => src.Department.ToString("G")))
        .ReverseMap()
            .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => ParseUtility.ParseEnum<Department>(src.Department)));
    }
}