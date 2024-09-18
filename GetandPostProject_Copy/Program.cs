var dataLeaksClient = new DataLeaksClient();
var dataBalloonClient = new DataBalloonClient();

try
{
    DataLeaks api_response =
        await dataLeaksClient.GetDataAsync()
                             .ConfigureAwait(false);

    var payload = api_response.Payload;


    if (payload == null || payload.Count == 0)
        throw new Exception("I have no data.");

    // MAP FROM DATALEAKS TO DATABALLOON!

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

        new DataBalloon
        {
            RecordId = items.Id
        };

        balloon.BaloonParameters = new List<DataB_Parameters>
        {
            new DataB_Parameters
            {
                DeliveryDateTime = items.Delivery ,
                Record = items.Value,
            }
        };


        balloonList.Add(balloon);
    }

    return balloonList;
    }
