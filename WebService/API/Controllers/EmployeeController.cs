using Application.Dtos;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<ActionResult<EmployeeDto>> Create([FromBody] EmployeeDto dto)
    {
        var employee = await _employeeService.Add(dto);
        return Ok(employee);
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