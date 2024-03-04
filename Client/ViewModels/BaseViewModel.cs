using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModels;

internal class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (field.Equals(value)) 
            return false;

        field = value;
        OnPropertyChanged(propertyName); 

        return true;
    }
}
