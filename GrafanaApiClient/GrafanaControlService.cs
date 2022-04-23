using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace GrafanaApiClient;

public partial interface IGrafanaControlService
{
}
public partial class GrafanaControlService : IGrafanaControlService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly string _serviceUrl;

    private readonly string _apiKey;

    private const string MediaTypeJson = "application/json";
    public GrafanaControlService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;

        _serviceUrl = TrimUrl(configuration.GetValue<string>("Grafana:Url"));
        _apiKey = configuration.GetValue<string>("Grafana:ApiKey");
    }

    private HttpClient GetHttpClient()
    {
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        return client;
    }
    private static string TrimUrl(string url)
    {
        if (url.EndsWith("?"))
            url = url[..^1];
        if (url.EndsWith("&"))
            url = url[..^1];
        if (url.EndsWith("/"))
            url = url[..^1];
        return url;
    }
}