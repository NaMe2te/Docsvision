using Application.Dtos;
using Application.Mapping.AutoMapper;
using Application.Services;
using Application.Services.Abstractions;
using DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddAutoMapper(typeof(MappingProfile));
        collection.AddScoped<IBaseCrudService<Employee, EmployeeDto>, EmployeeService>();
        collection.AddScoped<IMessageService, MessageService>();
        collection.AddScoped<IAuthenticationService, AuthenticationService>();
        return collection;
    }
}