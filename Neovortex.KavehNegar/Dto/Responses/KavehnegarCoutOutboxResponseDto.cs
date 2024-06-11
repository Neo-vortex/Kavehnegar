using System.Text.Json.Serialization;

namespace Neovortex.KavehNegar.Dto.Responses;

public class KavehnegarCoutOutboxResponseDto
{
    [JsonPropertyName("return")] public KavehnegarCoutOutboxResponseDtoReturn Return { get; set; }

    [JsonPropertyName("entries")] public KavehnegarCoutOutboxResponseDtoEntries Entries { get; set; }
}

public class KavehnegarCoutOutboxResponseDtoEntries
{
    [JsonPropertyName("startdate")] public long Startdate { get; set; }

    [JsonPropertyName("enddate")] public long Enddate { get; set; }

    [JsonPropertyName("sumpart")] public long Sumpart { get; set; }

    [JsonPropertyName("sumcount")] public long Sumcount { get; set; }

    [JsonPropertyName("cost")] public long Cost { get; set; }
}

public class KavehnegarCoutOutboxResponseDtoReturn
{
    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
}