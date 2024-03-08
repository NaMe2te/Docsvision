using Application.Dtos;

namespace Application.Services.Abstractions;

public interface IAuthenticationService
{
    Task<EmployeeDto> Login(AccountDto account);
    Task<EmployeeDto> Register(AccountDto accountDto, EmployeeDto employeeDto);
}