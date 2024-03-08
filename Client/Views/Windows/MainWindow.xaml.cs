using Client.Infrastructure.Commands;
using Client.Models;
using Client.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.Views.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(Employee currentAccount)
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(currentAccount);
    }

    private void OpenMessageWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (sender is ListBoxItem listBoxItem && listBoxItem.DataContext is Message message)
        {
            ICommand openReadMessageWindowCommand = new OpenReadMessageWindowCommand();
            if (openReadMessageWindowCommand.CanExecute(message))
            {
                openReadMessageWindowCommand.Execute(message);
            }
        }
    }
}