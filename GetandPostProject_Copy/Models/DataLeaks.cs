namespace GET_POST;

public class DataLeaks
{
    [JsonPropertyName("request")]
    public Request Request { get; set; }

    [JsonPropertyName("statistics")]
    public Statistics Statistics { get; set; }

    [JsonPropertyName("meta")]
    public object Meta { get; set; }

    [JsonPropertyName("payload")]
    public List<Payload> Payload { get; set; }
}

public class Request
{
    [JsonPropertyName("start")]
    public DateTime Start { get; set; }

    [JsonPropertyName("end")]
    public DateTime End { get; set; }

    [JsonPropertyName("responseTimeZone")]
    public string ResponseTimeZone { get; set; }

    [JsonPropertyName("requestTimeZone")]
    public string RequestTimeZone { get; set; }

    [JsonPropertyName("resolution")]
    public string Resolution { get; set; }

    [JsonPropertyName("function")]
    public string Function { get; set; }

    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    [JsonPropertyName("ids")]
    public List<int> Ids { get; set; }
}

public class Statistics
{
    [JsonPropertyName("itemCount")]
    public int ItemCount { get; set; }

    [JsonPropertyName("availableItems")]
    public int AvailableItems { get; set; }

    [JsonPropertyName("availability")]
    public double Availability { get; set; }

    [JsonPropertyName("requestDuration")]
    public int RequestDuration { get; set; }

    [JsonPropertyName("requestUnit")]
    public string RequestUnit { get; set; }
}

public class Payload
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("delivery")]
    public DateTime Delivery { get; set; }

    [JsonPropertyName("sysStartTime")]
    public DateTime? SysStartTime { get; set; }

    [JsonPropertyName("sysEndTime")]
    public DateTime? SysEndTime { get; set; }

    [JsonPropertyName("value")]
    public int? Value { get; set; }

    [JsonPropertyName("generated")]
    public bool Generated { get; set; }
}
