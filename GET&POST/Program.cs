using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder => {builder.AddConsole();});
var logger = loggerFactory.CreateLogger<DataBalloonClient>();
var dataLeaksClient = new DataLeaksClient();
var dataBalloonClient = new DataBalloonClient(logger);

try
{
    DataLeaks api_response = await dataLeaksClient.GetDataAsync().ConfigureAwait(false);

    var payload = api_response.Payload;

    if (payload == null || payload.Count == 0)
        throw new Exception("I have no data.");

    var balloonPayload = Map(payload);
    await dataBalloonClient.PostDataAsync(balloonPayload).ConfigureAwait(false);

}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
static List<DataBalloon> Map(List<Payload> dataleaksItems)
{
    List<DataBalloon> balloonList = new List<DataBalloon>();

    foreach (var items in dataleaksItems)
    {
        DataBalloon balloon = new DataBalloon();

        balloon.RecordId = items.Id;
        balloon.BaloonParameters = new List<DataB_Parameters>();

        DateTime roundedTime = Methods.RoundToNearestQuarterHour(DateTime.UtcNow);
        DataB_Parameters parameters = new DataB_Parameters
        {
            DeliveryDateTime = roundedTime,
            Record = items.Value
        };
        balloon.BaloonParameters.Add(parameters);

        balloonList.Add(balloon);
    }

    return balloonList;
}

