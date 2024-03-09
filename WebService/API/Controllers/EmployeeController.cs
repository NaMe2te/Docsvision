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
    private readonly ILogger _logger;

    public EmployeeController(IBaseCrudService<Employee, EmployeeDto> employeeService, ILogger<EmployeeController> logger)
    {
        _employeeService = employeeService;
        _logger = logger;
    }
    
    [HttpGet]
    [Route(nameof(GetById))]
    public async Task<ActionResult<EmployeeDto>> GetById([FromQuery] Guid id)
    {
        try
        {
            var employee = await _employeeService.Get(e => e.Id == id);
            _logger.LogInformation("Successfully have returned {EmployeeId} employee", employee.Id);
            return Ok(employee);
        }
        catch (ArgumentNullException e)
        {
            _logger.LogError(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred in GetById method");
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
    {
        try
        {
            var employees = await _employeeService.GetAll();
            _logger.LogInformation("Successfully retrieved {EmployeeCount} messages", employees.Count());
            return Ok(employees);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in GetAll method");
            return StatusCode(500);
        }
    }
}