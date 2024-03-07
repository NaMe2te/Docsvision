using Client.Infrastructure.Validators;
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

    public override bool CanExecute(object? parameter)
    {
        if (parameter is not MessageForSend)
            return false;
        if (parameter is null)
            return false;

        return IsMessageValid((MessageForSend) parameter);
    }

    public override async void Execute(object? parameter)
    {
        await _messageService.SendMessage((MessageForSend) parameter);
    }

    private bool IsMessageValid(MessageForSend message)
    {
        return MessageValidator.ValidateTitle(message.Title) &&
                MessageValidator.ValidateContent(message.Content) &&
                MessageValidator.ValidateSelectedAddressee(message.AddresseeId);
    }
}
