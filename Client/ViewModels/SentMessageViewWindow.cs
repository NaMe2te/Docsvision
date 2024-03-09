using Client.Infrastructure.Commands;
using Client.Infrastructure.Validators;
using Client.Models;
using Client.Services;
using Client.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.ViewModels;

public class SentMessageViewWindow : BaseViewModel, IDataErrorInfo
{
    private readonly IEmployeeService _employeeService;
    private readonly IMessageService _messageService;


    private Employee _account;
    public Employee Account
    {
        get => _account;
        set => Set(ref _account, value);
    }

    private Employee? _selectedAddressee;
    public Employee? SelectedAddressee
    {
        get => _selectedAddressee;
        set
        {
            Set(ref _selectedAddressee, value);
            _messageForSend.AddresseeId = _selectedAddressee.Id;
        }
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

    public MessageForSend MessageForSend => _messageForSend;

    public ICommand SendMessageCommand { get; }

    public string Error => "";

    public string this[string columnName]
    {
        get
        {
            string error = string.Empty;
            switch (columnName)
            {
                case nameof(SelectedAddressee):
                    if (!MessageValidator.ValidateSelectedAddressee(SelectedAddressee?.Id))
                    {
                        error = "Должен быть выбран получатель";
                    }
                    break;
                case nameof(MessageContent):
                    if (!MessageValidator.ValidateContent(MessageContent))
                    {
                        error = "Контент часть не может быть пустой";
                    }
                    break;
                case nameof(MessageTitle):
                    if (!MessageValidator.ValidateTitle(MessageTitle))
                    {
                        error = "Заголовок не может быть пустым";
                    }
                    break;
            }
            
            return error;
        }
    }

    public ICommand SendMessage { get; }

    public SentMessageViewWindow(Employee account, Guid? employeeIdForSending = null)
    {
        _account = account;
        _messageForSend = new MessageForSend(string.Empty, string.Empty, _account.Id, default(Guid));
        _employeeService = new EmployeeService();
        _messageService = new MessageService();
        SendMessageCommand = new SendMessageCommand(SendMessageAsync);
        InitializeAsync(employeeIdForSending);
    }

    private async void InitializeAsync(Guid? employeeIdForSending)
    {
        IEnumerable<Employee> employees = await _employeeService.GetAll();
        Employees = new ObservableCollection<Employee>(employees);
        if (employeeIdForSending is not null)
        {
            SelectedAddressee = _employees.First(e => e.Id == employeeIdForSending);
            _messageForSend.AddresseeId = SelectedAddressee.Id;
        }
    }

    private async Task SendMessageAsync()
    {
        Message message = await _messageService.SendMessage(MessageForSend);
        Account.SentMessages.Add(message);
       
    }
}
