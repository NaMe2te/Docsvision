namespace Application.Dtos;

public class EmployeeDto
{
    public EmployeeDto() { }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public ICollection<MessageWithProfilsDto> SentMessages { get; set; }
    public ICollection<MessageWithProfilsDto> ReceivedMessages { get; set; }
}