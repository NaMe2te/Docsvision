namespace Application.Dtos;

public record MessageDto(Guid Id, string Title, DateTime DateSending, string Content, Guid SenderId, Guid AddresseeId);