using DataAccess.Entities;

namespace Application.Dtos;

public record EmployeeDto(Guid Id, string Name, string Department, ICollection<MessageDto>? Messages);