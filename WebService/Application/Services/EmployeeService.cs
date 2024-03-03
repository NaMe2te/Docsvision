using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;

namespace Application.Services;

public class EmployeeService : BaseCrudService<Employee, EmployeeDto>,
    IEmployeeService
{
    public EmployeeService(IBaseRepository<Employee> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : base(repository, mapper, unitOfWork) { }
    
    public async Task<EmployeeDto> GetById(Guid id)
    {
        var employee = await _repository.Get(m => m.Id == id);
        return _mapper.Map<EmployeeDto>(employee);
    }
}