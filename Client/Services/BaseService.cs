using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Client.Services;

public abstract class BaseService
{
    protected readonly HttpClient _httpClient;

    public BaseService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseHttpUrl"]);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}
