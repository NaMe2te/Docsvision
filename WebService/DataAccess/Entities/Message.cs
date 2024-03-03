namespace DataAccess.Entities;

public class Message
{
    public Message(string title, DateTime dateSending, string content, Guid senderId, Guid addresseeId)
    {
        Title = title;
        DateSending = dateSending;
        Content = content;
        SenderId = senderId;
        AddresseeId = addresseeId;
    }
    
    protected Message() {}

    public Guid Id { get; init; }
    public string Title { get; set; }
    public DateTime DateSending { get; init; }
    public string Content { get; set; }
    
    public Guid SenderId { get; init; }
    public virtual Employee Sender { get; init; }
    public Guid AddresseeId { get; init; }
    public virtual Employee Addressee { get; init; }
}