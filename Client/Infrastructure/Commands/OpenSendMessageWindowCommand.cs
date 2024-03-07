using Client.Models;
using Client.Views.Windows;
using System.Security.Principal;
using System.Windows;

namespace Client.Infrastructure.Commands;

public class OpenSendMessageWindowCommand : BaseCommand
{
    private readonly Employee _account;

    public OpenSendMessageWindowCommand(Employee account)
    {
        _account = account;
    }

    public override bool CanExecute(object? parameter) => true;

    public override void Execute(object? parameter)
    {
        Guid? employeeIdForSending = parameter as Guid?;
        var window = new SentMessageWindow(_account, employeeIdForSending);
        window.Owner = Application.Current.MainWindow;
        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        window.Show();
    }
}
