using Client.Models;
using Client.Services.Interfaces;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Client.Services;

public class EmployeeService : BaseService,
    IEmployeeService
{
    public async Task<IEnumerable<Employee>> GetAll()
    {
        string token = ConfigurationManager.AppSettings["Token"];
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await _httpClient.GetAsync("api/Employee/GetAll");
        response.EnsureSuccessStatusCode();
        string resultString = await response.Content.ReadAsStringAsync();
        dynamic resultObject = JsonConvert.DeserializeObject(resultString);
        List<Employee> employees= resultObject.ToObject<List<Employee>>();
        return employees;
    }
}
