using Client.Infrastructure.Commands;
using Client.Infrastructure.Validators;
using Client.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.ViewModels;

public class SentMessageViewWindow : BaseViewModel, IDataErrorInfo
{
    private Employee _account;

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

    public SentMessageViewWindow(Employee account, Guid? employeeIdForSending = null)
    {
        _account = new Employee();
        _employees = [new Employee(), new Employee(), new Employee()];
        _messageForSend = new MessageForSend(string.Empty, string.Empty, _account.Id, default(Guid));
        if (employeeIdForSending is not null)
        {
            SelectedAddressee = _employees.First(e => e.Id == employeeIdForSending);
            _messageForSend.AddresseeId = SelectedAddressee.Id;
        }

        SendMessageCommand = new SendMessageCommand();
    }
}
