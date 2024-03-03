using Application.Dtos;
using DataAccess.Entities;

namespace Application.Services.Abstractions;

public interface IEmployeeService : IBaseCrudService<Employee, EmployeeDto>
{
    Task<EmployeeDto> GetById(Guid id);
}