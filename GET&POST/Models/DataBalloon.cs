namespace GET_POST;

public class DataBalloon
{
    [JsonPropertyName("recordId")]
    public int? RecordId { get; set; }

    [JsonPropertyName("items")]
    public List<DataB_Parameters>? BaloonParameters{ get; set; } = [];
}
