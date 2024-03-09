using Client.Infrastructure.Validators;
using Client.Models;
using Client.Services;
using Client.Services.Interfaces;

namespace Client.Infrastructure.Commands;

public class SendMessageCommand : BaseCommand
{
    private readonly Func<Task> _asyncAxecute;

    public SendMessageCommand(Func<Task> asyncAxecute)
    {
        _asyncAxecute = asyncAxecute;
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
        await _asyncAxecute();
    }

    private bool IsMessageValid(MessageForSend message)
    {
        return MessageValidator.ValidateTitle(message.Title) &&
                MessageValidator.ValidateContent(message.Content) &&
                MessageValidator.ValidateSelectedAddressee(message.AddresseeId);
    }
}
