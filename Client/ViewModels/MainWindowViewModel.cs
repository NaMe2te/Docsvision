using Client.Infrastructure.Commands;
using Client.Models;
using Client.Services;
using Client.Services.Interfaces;
using Client.Views.Windows;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Windows.Input;

namespace Client.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private readonly IEmployeeService _employeeService;

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
        _employeeService = new EmployeeService();
        OpenSentMessageFormCommand = new OpenSendMessageWindowCommand(Account, OpenSendMessageWindow);
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        IEnumerable<Employee> employees = await _employeeService.GetAll();
        Employees = new ObservableCollection<Employee>(employees);
    }

    private void OpenSendMessageWindow()
    {
        Guid? employeeIdForSending = null;
        if (SelectedEmployee is not null)
        {
            employeeIdForSending = SelectedEmployee.Id;
        }

        var window = new SentMessageWindow(_account, employeeIdForSending);
        window.Show();
    }
}