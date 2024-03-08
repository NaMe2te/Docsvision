namespace Application.Dtos;

public class MessageWithProfilsDto
{
    public MessageWithProfilsDto() { }
    
    public Guid Id { get; init; }
    public string Title { get; init; }
    public DateTime DateSending { get; init; }
    public string Content { get; init; }
    public EmployeeProfileDto Sender { get; init; }
    public EmployeeProfileDto Addressee { get; init; }
}