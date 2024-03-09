using Client.Models;

namespace Client.Services.Interfaces;

public interface IMessageService
{
    Task<Message> SendMessage(MessageForSend message);
    Task<Message> GetMessageById(Guid id);
}
