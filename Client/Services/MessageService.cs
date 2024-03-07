using Client.Models;
using Client.Services.Interfaces;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Client.Services;

public class MessageService : IMessageService
{
    private readonly HttpClient _httpClient;

    public MessageService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task SendMessage(MessageForSend message)
    {
        //await _httpClient.PostAsync("api/Message/Create", JsonContent.Create(message));
    }
}
