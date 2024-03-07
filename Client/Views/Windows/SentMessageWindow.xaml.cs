using Client.Models;
using Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Client.Views.Windows;

/// <summary>
/// Interaction logic for SentMessageWindow.xaml
/// </summary>
public partial class SentMessageWindow : Window
{
    public SentMessageWindow(/*Employee currentEmployee, List<Employee> employees, Employee? employeeForSending = null*/)
    {
        InitializeComponent();
        DataContext = new SentMessageViewWindow(/*currentEmployee, employees, employeeForSending*/);
    }
}
