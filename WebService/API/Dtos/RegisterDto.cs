using Application.Dtos;

namespace API.Dtos;

public record RegisterDto(AccountDto Account, EmployeeDto Employee);