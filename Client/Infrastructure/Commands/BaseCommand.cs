using System.Windows.Input;

namespace Client.Infrastructure.Commands;

public abstract class BaseCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public abstract bool CanExecute(object? parameter);

    public abstract void Execute(object? parameter);
}
