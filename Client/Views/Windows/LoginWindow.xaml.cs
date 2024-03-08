using Client.ViewModels;
using Client.Views.UserControls;
using System.Windows;
using System.Windows.Controls;

namespace Client.Views.Windows;

/// <summary>
/// Interaction logic for LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        var registrationForm = new RegistrationForm();
        Content = registrationForm;
    }

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        var loginForm = new LoginForm();
        Content = loginForm;
    }
}
