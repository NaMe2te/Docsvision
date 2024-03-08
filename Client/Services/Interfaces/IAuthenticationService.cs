using Client.Models;

namespace Client.Services.Interfaces;

public interface IAuthenticationService
{
    Task<Employee> Register(Register register);
    Task<Employee> Login(Account account);
}
