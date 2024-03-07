using Client.Models;

namespace Client.Services.Interfaces;

public interface IMessageService
{
    Task SendMessage(MessageForSend message);
}
