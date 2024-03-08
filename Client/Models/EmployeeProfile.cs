namespace Client.Models;

public class EmployeeProfile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = "Daniil Khalikov Vladislavovich";
    public string Department { get; set; } = "IT";
    public string Email { get; set; } = "vladyushashishkin95@gmail.com";
}
