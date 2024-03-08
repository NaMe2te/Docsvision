using Client.Models;
using Client.Services.Interfaces;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Client.Services;

public class AuthenticationService : BaseService,
    IAuthenticationService
{
    public async Task<Employee> Register(Register register)
    {
        string json = JsonConvert.SerializeObject(register);
        StringContent content = new StringContent(json, Encoding.UTF8, new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await _httpClient.PostAsync("api/Authentication/Register", content);
        response.EnsureSuccessStatusCode();
        return await GetEmployeeFromJson(response);
    }

    public async Task<Employee> Login(Account account)
    {
        string json = JsonConvert.SerializeObject(account);
        StringContent content = new StringContent(json, Encoding.UTF8, new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await _httpClient.PostAsync("api/Authentication/Login", content);
        response.EnsureSuccessStatusCode();
        return await GetEmployeeFromJson(response);
    }


    private async Task<Employee> GetEmployeeFromJson(HttpResponseMessage response)
    {
        string resultString = await response.Content.ReadAsStringAsync();
        dynamic resultObject = JsonConvert.DeserializeObject(resultString);
        Employee employee = resultObject.profileCredentials.ToObject<Employee>();
        string token = resultObject.token;
        SaveToken(token);
        return employee;
    }

    private void SaveToken(string token)
    {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        config.AppSettings.Settings["Token"].Value = token;
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
    }
}
