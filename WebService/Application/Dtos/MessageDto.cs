namespace Application.Dtos;

public class MessageDto
{
    public MessageDto() { }
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime DateSending { get; set; }
    public string Content { get; set; }
    public Guid SenderId { get; set; }
    public Guid AddresseeId { get; set; }
}