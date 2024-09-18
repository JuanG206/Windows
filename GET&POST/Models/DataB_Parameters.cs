namespace GET_POST;

public class DataB_Parameters
{
    [JsonPropertyName("deliveryDateTime")]
    public DateTime? DeliveryDateTime { get; set; }

    [JsonPropertyName("record")]
    public int? Record { get; set; }
}