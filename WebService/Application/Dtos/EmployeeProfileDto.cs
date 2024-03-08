namespace Application.Dtos;

public class EmployeeProfileDto
{
    public EmployeeProfileDto() { }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
}