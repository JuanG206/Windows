using System.Net.Http.Headers;
using System.Text.Json;

namespace GET_POST;

public class DataBalloonClient
{

    public DataBalloonClient()
    {
	    var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors) => true
        };
	    
        _httpClient = new HttpClient(handler);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async ValueTask PostDataAsync(List<DataBalloon> payload)
    {
        string payloadAsString = JsonSerializer.Serialize(payload);

        var content = new StringContent(payloadAsString, Encoding.UTF8, MEDIATYPE);
      
        HttpResponseMessage response = 
            await _httpClient.PostAsync(URL, content)
                                .ConfigureAwait(false);

        // get to this point!

        response.EnsureSuccessStatusCode();
    }

    private readonly HttpClient _httpClient;
    private const string URL = "https://databalloon.dev.rke2-cnvx.com/series/dryrun";
    private static readonly MediaTypeHeaderValue MEDIATYPE = new("application/json");
}

