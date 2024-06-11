using System.Text.Json.Serialization;

namespace Neovortex.KavehNegar.Dto.Responses;

public class KavehnegarCancelResponseDto
{
    [JsonPropertyName("return")] public KavehnegarCancelResponseDtoReturn Return { get; set; }

    [JsonPropertyName("entries")] public List<KavehnegarCancelResponseDtoEntry> Entries { get; set; }
}

public class KavehnegarCancelResponseDtoEntry
{
    [JsonPropertyName("messageid")] public long Messageid { get; set; }

    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("statustext")] public string Statustext { get; set; }
}

public class KavehnegarCancelResponseDtoReturn
{
    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
}