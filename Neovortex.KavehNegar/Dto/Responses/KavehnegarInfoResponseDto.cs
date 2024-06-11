using System.Text.Json.Serialization;

namespace Neovortex.KavehNegar.Dto.Responses;

public class KavehnegarInfoResponseDto
{
    [JsonPropertyName("return")] public KavehnegarInfoResponseDtoReturn Return { get; set; }

    [JsonPropertyName("entries")] public KavehnegarInfoResponseDtoEntries Entries { get; set; }
}

public class KavehnegarInfoResponseDtoEntries
{
    [JsonPropertyName("remaincredit")] public long Remaincredit { get; set; }

    [JsonPropertyName("expiredate")] public long Expiredate { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }
}

public class KavehnegarInfoResponseDtoReturn
{
    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
}