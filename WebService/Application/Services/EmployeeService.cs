using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;

namespace Application.Services;

public class EmployeeService : BaseCrudService<Employee, EmployeeDto>
{
    public EmployeeService(IBaseRepository<Employee> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : base(repository, mapper, unitOfWork) { }
}