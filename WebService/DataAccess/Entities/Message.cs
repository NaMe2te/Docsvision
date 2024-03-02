namespace DataAccess.Entities;

public class Message
{
    public Message(string title, DateTime dateSending, string content, Employee sender, Employee addressee)
    {
        Title = title;
        DateSending = dateSending;
        Content = content;
        Sender = sender;
        Addressee = addressee;
    }
    
    protected Message() {}

    public Guid Id { get; init; }
    public string Title { get; set; }
    public DateTime DateSending { get; init; }
    public string Content { get; set; }
    
    public Employee Sender { get; init; }
    public Employee Addressee { get; init; }
}