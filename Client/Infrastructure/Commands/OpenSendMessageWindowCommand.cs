using Client.Models;
using Client.Views.Windows;
using System.Security.Principal;
using System.Windows;

namespace Client.Infrastructure.Commands;

public class OpenSendMessageWindowCommand : BaseCommand
{
    private readonly Employee _account;
    private readonly Action _execute;

    public OpenSendMessageWindowCommand(Employee account, Action execute)
    {
        _account = account;
        _execute = execute;
    }

    public override bool CanExecute(object? parameter) => true;

    public override void Execute(object? parameter)
    {
        Guid? employeeIdForSending = parameter as Guid?;
        var window = new SentMessageWindow(_account, employeeIdForSending);
        window.Show();
        // _execute();
    }
}
