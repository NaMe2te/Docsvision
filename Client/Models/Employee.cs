namespace Client.Models;

public class Employee
{
    public Guid Id { get; set; } = Guid.Parse("b248bfa9-2d59-4eaf-8f1a-77e7c1beb8ff");
    public string FullName { get; set; } = "Daniil Khalikov Vladislavovich";
    public string Department { get; set; } = "IT";
    public string Email { get; set; } = "vladyushashishkin95@gmail.com";
    public List<Message> SentMessages { get; set; } = new List<Message>();
    public List<Message> ReceivedMessages { get; set; } = new List<Message>();
}
