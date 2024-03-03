using Application.Mapping.AutoMapper;
using Application.Services;
using Application.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddAutoMapper(typeof(MappingProfile));
        collection.AddScoped<IMessageService, MessageService>();
        collection.AddScoped<IEmployeeService, EmployeeService>();
        return collection;
    }
}