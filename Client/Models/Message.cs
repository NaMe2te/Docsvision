namespace Client.Models;

public class Message
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "Hello";
    public DateTime DateSending { get; set; } = DateTime.Now;
    public string Content { get; set; } = "fvrhenfjiernjferjfrejfierjifjoerjferkj;lfrekjferijfierjfioerj";
}
