namespace Client.Models;

public class MessageForSend
{
    public MessageForSend(string title, string content, Guid senderId, Guid addresseeId)
    {
        Title = title;
        Content = content;
        DateSending = DateTime.Now;
        SenderId = senderId;
        AddresseeId = addresseeId;
    }

    public string Title { get; set; }
    public DateTime DateSending { get; set; }
    public string Content { get; set; }
    public Guid SenderId { get; set; }
    public Guid AddresseeId { get; set; }
}
