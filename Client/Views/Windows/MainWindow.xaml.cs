using Client.Infrastructure.Commands;
using Client.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.Views.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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