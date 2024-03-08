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
/*{
"account": {
    "email": "4324",
    "password": "123"
},
"employee": {
    "name": "ferferfer",
    "department": "It",
    "email": "",
    "sentMessages": [],
    "receivedMessages": []
}
}*/
/*
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiI0OWU2NDE4Zi1mMzUwLTRkZDktYWViNS0wOGRjM2YyNmY4ZGUiLCJ1bmlxdWVfbmFtZSI6ImhmZ3Zlc2RzZmMiLCJuYmYiOjE3MDk4NzE1NzksImV4cCI6MTcwOTg3NTE3OSwiaWF0IjoxNzA5ODcxNTc5LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDMwNyIsImF1ZCI6ImF1ZGllbmNlX3RvX2RvIn0.ItRN0HPIDFaEuqNs-7mW4YKCwAnmjaH6owtOvRg0GwM
 */