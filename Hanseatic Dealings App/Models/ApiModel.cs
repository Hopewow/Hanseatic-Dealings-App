using System.Net.Http.Headers;

namespace Hanseatic_Dealings_App.Models;

internal class ApiModel
{
    public HttpClient getClient()
    {
        HttpClient client = new();
        client.BaseAddress = new Uri("http://10.130.54.25:5000/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return client;
    }
}
