using Client.Models;

namespace Client.ViewModels;

public class ReadMessageViewModel : BaseViewModel
{
    private Message _currentMessage;

    public Message CurrentMessage
    {
        get => _currentMessage;
        set => Set(ref _currentMessage, value);
    }

    public ReadMessageViewModel() { }
    
    public ReadMessageViewModel(Message currentMessage)
    {
        _currentMessage = currentMessage;
    }
}
