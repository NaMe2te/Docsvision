using Client.Models;
using Client.Views.Windows;
using System.Windows;

namespace Client.Infrastructure.Commands;

public class OpenSentMessageFormCommand : BaseCommand
{
    public override bool CanExecute(object? parameter) => true;

    public override void Execute(object? parameter)
    {
        var window = new SentMessageWindow();
        window.Owner = Application.Current.MainWindow;
        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        window.Show();
    }
}
