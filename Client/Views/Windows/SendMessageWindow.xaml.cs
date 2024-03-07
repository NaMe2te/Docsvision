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
    public SentMessageWindow(Employee account, Guid? employeeIdForSending = null)
    {
        InitializeComponent();
        DataContext = new SentMessageViewWindow(account, employeeIdForSending);
    }
}
