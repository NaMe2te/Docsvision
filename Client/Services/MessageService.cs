using Client.Models;
using Client.Services.Interfaces;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Client.Services;

public class MessageService : BaseService,
    IMessageService
{
    public async Task SendMessage(MessageForSend message)
    {
        //await _httpClient.PostAsync("api/Message/Create", JsonContent.Create(message));
    }
}
