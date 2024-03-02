using DataAccess.CodeForms.Enums;

namespace DataAccess.Entities;

public class Employee
{
    public Employee(string name, Department department)
    {
        Name = name;
        Department = department;
        Messages = new List<Message>();
    }

    protected Employee() { }
    
    public Guid Id { get; init; }
    public string Name { get; set; }
    public Department Department { get; set; }
    public ICollection<Message> Messages { get; init; }
}