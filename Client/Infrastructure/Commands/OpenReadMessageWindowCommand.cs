
using Client.Models;
using Client.Views.Windows;

namespace Client.Infrastructure.Commands;

public class OpenReadMessageWindowCommand : BaseCommand
{
    public override bool CanExecute(object? parameter)
    {
        return parameter is not null && parameter is Message message;
    }

    public override void Execute(object? parameter)
    {
        ReadMessageWindow readMessageWindow = new ReadMessageWindow((Message) parameter);
        readMessageWindow.Show();
    }
}