using DataAccess.CodeForms.Enums;

namespace DataAccess.Entities;

public class Employee
{
    public Employee(string name, Department department)
    {
        Name = name;
        Department = department;
        SentMessages = new List<Message>();
        ReceivedMessages = new List<Message>();
    }

    protected Employee() { }
    
    public Guid Id { get; init; }
    public string Name { get; set; }
    public Department Department { get; set; }
    public virtual Account Account { get; set; }
    public virtual ICollection<Message> SentMessages { get; set; }
    public virtual ICollection<Message> ReceivedMessages { get; set; }
}