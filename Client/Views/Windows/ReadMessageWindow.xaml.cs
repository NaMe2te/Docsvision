using Client.Models;
using Client.ViewModels;
using System.Windows;

namespace Client.Views.Windows;

/// <summary>
/// Interaction logic for ReadMessageWindow.xaml
/// </summary>
public partial class ReadMessageWindow : Window
{
    public ReadMessageWindow(Message message)
    {
        InitializeComponent();
        DataContext = new ReadMessageViewModel(message);
    }
}
