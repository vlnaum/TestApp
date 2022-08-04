using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Rest;

namespace TestApp.Api.AppCenter;

public class AppCenterClient: IAppCenterClient, IDisposable
{
    private readonly HttpClient _client = new HttpClient();
    public IBuilds Builds { get; set; }

    public AppCenterClient(string token)
    {
        _client.DefaultRequestHeaders.Add("X-Api-Token", token);
        Init();
    }

    public async Task<TResponse> PostJsonAsync<TRequest, TResponse>(
        string resource,
        TRequest request,
        CancellationToken cancellationToken = default
    ) where TRequest : class
    {
        var response = await _client.PostAsJsonAsync(resource, request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return default;
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpOperationException($"status code {response.StatusCode}");
        }

        var body = JsonSerializer.Deserialize<TResponse>(
            await response.Content.ReadAsStreamAsync(cancellationToken));
        return body;
    }
    
    public async Task<TResponse> GetJsonAsync<TResponse>(
        string resource,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.GetAsync(resource, cancellationToken);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return default;
        }
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpOperationException($"status code {response.StatusCode}");
        }
        var body = JsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStreamAsync(cancellationToken));
        return body;
    }

    private void Init()
    {
        _client.BaseAddress = new Uri("https://api.appcenter.ms/");
        Builds = new Builds(this);
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}