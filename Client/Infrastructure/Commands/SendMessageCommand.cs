using Client.Models;
using Client.Services;
using Client.Services.Interfaces;

namespace Client.Infrastructure.Commands;

public class SendMessageCommand : BaseCommand
{
    private readonly IMessageService _messageService;

    public SendMessageCommand()
    {
        _messageService = new MessageService();
    }

    public override bool CanExecute(object? parameter) => true;

    public override async void Execute(object? parameter)
    {
        if (parameter is not null && parameter is MessageForSend message)
        {
            await _messageService.SendMessage(message);
        }
    }
}
