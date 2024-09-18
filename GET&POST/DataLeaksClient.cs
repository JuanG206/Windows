using System.Net.Http.Headers;
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

           string responseBody = 
           await response.Content.ReadAsStringAsync();

           Console.WriteLine("Response:");
           Console.WriteLine(responseBody);

           DataLeaks? result = 
           await response.Content.ReadFromJsonAsync <DataLeaks>()
                                 .ConfigureAwait(false);
       
        if (result == null)
            throw new Exception("result is null");

            return result;
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


