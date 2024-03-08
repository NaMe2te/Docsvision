namespace Client.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public List<Message> SentMessages { get; set; }
    public List<Message> ReceivedMessages { get; set; }
}
