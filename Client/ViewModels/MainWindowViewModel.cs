using Client.Infrastructure.Commands;
using Client.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Client.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private string _title = "Docsvision";
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    private ObservableCollection<Employee> _employees;
    public ObservableCollection<Employee> Employees
    {
        get => _employees; 
        set => Set(ref _employees, value);
    }

    private Employee _currentAccount;
    public Employee CurrentAccount
    {
        get => _currentAccount;
        set => Set(ref _currentAccount, value);
    }


    private ICommand _openReadMessageWindowCommand;
    public ICommand OpenReadMessageWindowCommand => _openReadMessageWindowCommand;




    public MainWindowViewModel()
    {
        _employees = [new Employee(), new Employee(), new Employee()];

        _currentAccount = new Employee();

        _currentAccount.SentMessages.Add(new Message());
        _currentAccount.SentMessages.Add(new Message());
        _currentAccount.SentMessages.Add(new Message());

        _currentAccount.ReceivedMessages.Add(new Message());
        _currentAccount.ReceivedMessages.Add(new Message());

        _openReadMessageWindowCommand = new OpenReadMessageWindowCommand();
    }
}