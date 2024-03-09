using Client.Infrastructure.Commands;
using Client.Models;
using Client.Services;
using Client.Services.Interfaces;
using Client.Views.Windows;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Windows.Input;

namespace Client.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private readonly IEmployeeService _employeeService;

    private SentMessageViewWindow _sentMessageViewWindow;

    private string _title = "Docsvision";
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    private ObservableCollection<Message> _sentMessages;
    public ObservableCollection<Message> SentMessages
    {
        get => _sentMessages;
        set => Set(ref _sentMessages, value);
    }

    private ObservableCollection<Employee> _employees;
    public ObservableCollection<Employee> Employees
    {
        get => _employees; 
        set => Set(ref _employees, value);
    }

    private Employee _account;
    public Employee Account
    {
        get => _account;
        set => Set(ref _account, value);
    }

    private Employee _selectedEmployee;
    public Employee SelectedEmployee
    {
        get => _selectedEmployee;
        set => Set(ref _selectedEmployee, value);
    }

    public ICommand OpenSentMessageFormCommand { get; }

    public MainWindowViewModel() {}

    public MainWindowViewModel(Employee currentAccount)
    {
        Account = currentAccount;
        SentMessages = new ObservableCollection<Message>(Account.SentMessages);
        _employeeService = new EmployeeService();
        OpenSentMessageFormCommand = new OpenSendMessageWindowCommand(Account, InitSentMessageViewWindow);
        InitializeAsync();
    }

    private void InitSentMessageViewWindow(SentMessageViewWindow sentMessageViewWindow)
    {
        sentMessageViewWindow.SentMessageAdded += SentMessageViewWindow_SentMessageAdded;
    }

    private async void InitializeAsync()
    {
        IEnumerable<Employee> employees = await _employeeService.GetAll();
        Employees = new ObservableCollection<Employee>(employees);
    }

    private void SentMessageViewWindow_SentMessageAdded(object sender, Message message)
    {
        SentMessages.Add(message);
    }
}