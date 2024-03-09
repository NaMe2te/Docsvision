using Client.Models;
using Client.ViewModels;
using Client.Views.Windows;
using System.Security.Principal;
using System.Windows;

namespace Client.Infrastructure.Commands;

public class OpenSendMessageWindowCommand : BaseCommand
{
    private readonly Employee _account;
    private readonly Action<SentMessageViewWindow> _init;

    public OpenSendMessageWindowCommand(Employee account, Action<SentMessageViewWindow> init)
    {
        _account = account;
        _init = init;
    }

    public override bool CanExecute(object? parameter) => true;

    public override void Execute(object? parameter)
    {
        Guid? employeeIdForSending = parameter as Guid?;
        var viewModel = new SentMessageViewWindow(_account, employeeIdForSending);
        _init(viewModel);
        var window = new SentMessageWindow(_account, viewModel);
        window.Show();
    }
}