using Client.Infrastructure.Commands;
using Client.Models;
using Client.Services;
using Client.Services.Interfaces;
using Client.Views.Windows;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly IAuthenticationService _authenticationService;

    private Employee _account;
    public Employee Account
    {
        get => _account;
        set => Set(ref _account, value);
    }

    private string _email;
    public string Email
    {
        get => _email;
        set => Set(ref _email, value);
    }

    private string _password;
    public string Password
    {
        get => _password;
        set => Set(ref _password, value);
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    }

    private string _department;
    public string Department
    {
        get => _department;
        set => Set(ref _department, value);
    }

    private string _error;
    public string Error
    {
        get => _error;
        set => Set(ref _error, value);
    }

    public ObservableCollection<string> Departments { get; }

    public ICommand RegisterCommand { get; }
    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        _authenticationService = new AuthenticationService();
        Departments = new ObservableCollection<string> { "IT", "Marketing" };
        RegisterCommand = new AsyncCommand(RegisterAsync);
        LoginCommand = new AsyncCommand(Login);
    }

    private void OpenMainWindow()
    {
        MainWindow mainWindow = new MainWindow(Account);
        mainWindow.Show();
        Application.Current.MainWindow?.Close();
    }

    private async Task Login()
    {
        try
        {
            var account = new Account
            {
                Email = Email,
                Password = Password,
            };


            Account = await _authenticationService.Login(account);

            OpenMainWindow();
        }
        catch (HttpRequestException e)
        {
            switch (e.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    Error = "Не все параметры были переданы";
                    break;
                case HttpStatusCode.Unauthorized:
                    Error = "Неверный eмель или пароль";
                    break;
            }
        }
        catch (Exception ex)
        {
            Error = "Что-то пошло не так, попробуйте повторить попытку позже";
        }
    }

    private async Task RegisterAsync()
    {
        try
        {
            var register = new Register
            {
                Employee = new Employee
                {
                    Name = Name,
                    Department = Department,
                    Email = Email,
                    SentMessages = new List<Message>(),
                    ReceivedMessages = new List<Message>()
                },
                Account = new Account
                {
                    Email = Email,
                    Password = Password,
                }
            };

            Account = await _authenticationService.Register(register);

            OpenMainWindow();
        }
        catch(HttpRequestException e)
        {
            switch (e.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    Error = "Не все параметры были переданы";
                    break;
                case HttpStatusCode.Conflict:
                    Error = "Аккаунт с таким eмейл уже используется";
                    break;
            }
        }
        catch (Exception ex)
        {
            Error = "Что-то пошло не так, попробуйте повторить попытку позже";
        }
    }
}
