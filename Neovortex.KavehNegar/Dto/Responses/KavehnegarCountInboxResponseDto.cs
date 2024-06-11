using System.Text.Json.Serialization;

namespace Neovortex.KavehNegar.Dto.Responses;

public class KavehnegarCountInboxResponseDto
{
    [JsonPropertyName("return")] public KavehnegaCountInboxResponseDtoReturn Return { get; set; }

    [JsonPropertyName("entries")] public KavehnegaCountInboxResponseDtoEntries Entries { get; set; }
}

public class KavehnegaCountInboxResponseDtoEntries
{
    [JsonPropertyName("startdate")] public long Startdate { get; set; }

    [JsonPropertyName("enddate")] public long Enddate { get; set; }

    [JsonPropertyName("sumcount")] public long Sumcount { get; set; }
}

public class KavehnegaCountInboxResponseDtoReturn
{
    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
}