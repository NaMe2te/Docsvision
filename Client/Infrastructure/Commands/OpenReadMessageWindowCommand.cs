﻿
using Client.Models;
using Client.Views.Windows;

namespace Client.Infrastructure.Commands;

public class OpenReadMessageWindowCommand : BaseCommand
{
    public override bool CanExecute(object? parameter) => true;

    public override void Execute(object? parameter)
    {
        if (parameter is not null && parameter is Message message)
        {
            ReadMessageWindow readMessageWindow = new ReadMessageWindow(message);
            readMessageWindow.Show();
        }
    }
}