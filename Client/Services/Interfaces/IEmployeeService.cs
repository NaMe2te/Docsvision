using Client.Models;

namespace Client.Services.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAll();
}
