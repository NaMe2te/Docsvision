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
}