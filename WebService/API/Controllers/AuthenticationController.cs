using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Dtos;
using Application.Dtos;
using Application.Exceptions;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthenticationController
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration, ILogger<AuthenticationController> logger)
    {
        _authenticationService = authenticationService;
        _configuration = configuration;
        _logger = logger;
    }
    
    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult<EmployeeDto>> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            var employee = await _authenticationService.Register(registerDto.Account, registerDto.Employee);
            _logger.LogInformation("Successfully register new employee with id {EmployeeId}", employee.Id);
            return new OkObjectResult(
                new {ProfileCredentials = employee, Token = GetToken(employee.Id, employee.Email)});
        }
        catch (AccountWithEmailAlreadyExistException e)
        {
            _logger.LogError(e, e.Message);
            return new ConflictObjectResult(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
    
    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<EmployeeDto>> Login([FromBody] AccountDto accountDto)
    {
        try
        {
            EmployeeDto employee = await _authenticationService.Login(accountDto);
            _logger.LogInformation("Successfully login employee with id {EmployeeId}", employee.Id);
            return new OkObjectResult(new { ProfileCredentials = employee, Token = GetToken(employee.Id, employee.Email) });
        }
        catch (InvalidLoginOrPasswordException e)
        {
            _logger.LogError(e, e.Message);
            return new UnauthorizedObjectResult(e.Message);
        }
    }
    
    private string GetToken(Guid employeeId, string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.Unicode.GetBytes(_configuration["jwt:SecretKey"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Sid, employeeId.ToString()),
                new (ClaimTypes.Name, email)
            }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = _configuration["jwt:Audience"],
            Issuer = _configuration["jwt:Issuer"]
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}