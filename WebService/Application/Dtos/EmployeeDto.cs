namespace Application.Dtos;

public record EmployeeDto(Guid Id, string Name, string Department, ICollection<MessageDto> SentMessages, ICollection<MessageDto> ReceivedMessages);