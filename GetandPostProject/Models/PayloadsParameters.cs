namespace GET_POST;

public class PayloadsParameters
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("delivery")]
    public DateTime Delivery { get; set; }

    [JsonPropertyName("value")]
    public int Value { get; set; }
}


