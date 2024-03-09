using Client.Models;
using Client.Services.Interfaces;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Client.Services;

public class MessageService : BaseService,
    IMessageService
{
    public async Task<Message> GetMessageById(Guid id)
    {
        string token = ConfigurationManager.AppSettings["Token"];
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await _httpClient.GetAsync($"api/Message/GetById?id={id}");
        response.EnsureSuccessStatusCode();
        string resultString = await response.Content.ReadAsStringAsync();
        dynamic resultObject = JsonConvert.DeserializeObject(resultString);
        Message message = resultObject.ToObject<Message>();
        return message;
    }

    public async Task<Message> SendMessage(MessageForSend messageForSend)
    {
        string token = ConfigurationManager.AppSettings["Token"];
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await _httpClient.PostAsync("api/Message/Create", JsonContent.Create(messageForSend));
        response.EnsureSuccessStatusCode();
        string resultString = await response.Content.ReadAsStringAsync();
        dynamic resultObject = JsonConvert.DeserializeObject(resultString);
        Message message = resultObject.ToObject<Message>();
        return message;
    }
}
