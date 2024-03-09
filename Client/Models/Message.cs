namespace Client.Models;

public class Message
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime DateSending { get; set; }
    public string Content { get; set; }
    public EmployeeProfile Sender { get; set; }
    public EmployeeProfile Addressee { get; set; }
}
