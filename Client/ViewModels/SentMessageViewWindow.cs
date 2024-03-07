using Client.Infrastructure.Commands;
using Client.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Windows.Input;

namespace Client.ViewModels;

public class SentMessageViewWindow : BaseViewModel
{
    private Employee _account;

    private Employee _selectedRecipient;
    public Employee SelectedRecipient
    {
        get => _selectedRecipient;
        set => Set(ref _selectedRecipient, value);
    }

    private ObservableCollection<Employee> _employees;
    public ObservableCollection<Employee> Employees
    {
        get => _employees;
        set => Set(ref _employees, value);
    }

    private string _messageTitle;
    public string MessageTitle
    {
        get => _messageTitle;
        set
        {
            Set(ref _messageTitle, value);
            _messageForSend.Title = value;
        }
    }

    private string _messageContent;
    public string MessageContent
    {
        get => _messageContent;
        set
        {
            Set(ref _messageContent, value);
            _messageForSend.Content = value;
        }
    }

    private MessageForSend _messageForSend;

    public MessageForSend MessageForSend 
    {
        get => _messageForSend;
    }

    protected override bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        return base.Set(ref field, value, propertyName);
    }

    public ICommand SendMessageCommand { get; }

    public SentMessageViewWindow(/*Employee currentEmployee, List<Employee> employees, Employee? employeeForSending = null*/)
    {
        _account = new Employee();
        _employees = [new Employee(), new Employee(), new Employee()];
        Employee? employeeForSending = new Employee();
        if (employeeForSending is not null)
        {
            SelectedRecipient = _employees.First(e => e.Id == employeeForSending.Id);
        }

        SendMessageCommand = new SendMessageCommand();
        _messageForSend = new MessageForSend(_messageTitle, _messageContent, SelectedRecipient.Id, _account.Id);
    }
}
