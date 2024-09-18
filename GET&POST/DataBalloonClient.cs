using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace GET_POST;
public class DataBalloonClient
{
    public DataBalloonClient(ILogger<DataBalloonClient> logger)
    {
        _logger = logger;
        
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors) => true
        };

        _httpClient = new HttpClient(handler);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("X-CNVX.Sender", "Juan");
        _httpClient.DefaultRequestHeaders.Add("X-CNVX.ContributorId", "-1");
        _httpClient.DefaultRequestHeaders.Add("X-CNVX.ClientId", "Corpus");   
    }
    public async ValueTask PostDataAsync(List<DataBalloon> payload)
    {
        string payloadAsString = JsonSerializer.Serialize(payload);

        _logger.LogInformation("Sending payload: {Payload}", payloadAsString);
       
        var content = new StringContent(payloadAsString, Encoding.UTF8, MEDIATYPE);

        try
        {
         HttpResponseMessage response =
         await _httpClient.PostAsync(URL, content)
                          .ConfigureAwait(false);

         string responseContent =
         await response.Content.ReadAsStringAsync();
            
        if (response.IsSuccessStatusCode)
        {
        _logger.LogInformation("Succesful request!, Status code: {StatusCode}, response: {ResponseContent}", response.StatusCode, responseContent);
        }
        else
        {
        _logger.LogError("request failed!, Status code: {StatusCode}, response: {ResponseContent}", response.StatusCode, responseContent);
        }

        response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
              _logger.LogError
              ("Request error HTTP!: {Message}", e.Message);
        throw;
        }
        catch (Exception e)
        {
              _logger.LogError
              ("Error inesperado: {Message}", e.Message);
        throw;
        }
    }

    private readonly HttpClient _httpClient;
    private readonly ILogger<DataBalloonClient> _logger;
    private const string URL = "https://databalloon.dev.rke2-cnvx.com/series/dryrun";
    private static readonly MediaTypeHeaderValue MEDIATYPE = new("application/json")
}
     
