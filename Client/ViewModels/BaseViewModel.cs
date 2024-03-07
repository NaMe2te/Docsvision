using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        field = value;
        OnPropertyChanged(propertyName); 

        return true;
    }
}
