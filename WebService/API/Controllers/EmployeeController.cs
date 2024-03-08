using Application.Dtos;
using Application.Services.Abstractions;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EmployeeController : Controller
{
    private readonly IBaseCrudService<Employee, EmployeeDto> _employeeService;

    public EmployeeController(IBaseCrudService<Employee, EmployeeDto> employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet]
    [Route(nameof(GetById))]
    public async Task<ActionResult<EmployeeDto>> GetById([FromQuery] Guid id)
    {
        var employee = await _employeeService.Get(e => e.Id == id);
        return Ok(employee);
    }
    
    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
    {
        var employees = await _employeeService.GetAll();
        return Ok(employees);
    }
}