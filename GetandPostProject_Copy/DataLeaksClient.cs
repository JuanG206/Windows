using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace GET_POST;

public class DataLeaksClient
{

    public DataLeaksClient()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors) => true
        };
        _httpClient = new HttpClient(handler);

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    }

    public async ValueTask<DataLeaks> GetDataAsync()
    {
        HttpResponseMessage response = 
            await _httpClient.GetAsync(URL).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        // Print the response content to the console
        Console.WriteLine("Response:");
        Console.WriteLine(responseBody);

        DataLeaks? result = 
            await response.Content.ReadFromJsonAsync <DataLeaks>()
                                    .ConfigureAwait(false);
        if (result == null)
            throw new Exception("result is null");

        return result;
    }

    public string URLExtraction()
    {
        return URL;
    }

    private readonly HttpClient _httpClient;

    private const string URL = 
    "https://dataleaks.dev.rke2-cnvx.com/Series?" +
    "requestTimeZone=Cet" +
    "&responseTimeZone=Cet" +
    "&resolution=Hour" +
    "&function=Average" +
    "&decimals=0" +
    "&ids=1264";
}


