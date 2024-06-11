using System.Text.Json.Serialization;
using Neovortex.KavehNegar.Model.Enums;

namespace Neovortex.KavehNegar.Dto.Responses;

public class KavehnegarMessageStatusResponseDto
{
    [JsonPropertyName("return")] public KavehnegarMessageStatusResponseDtoReturn Return { get; set; }

    [JsonPropertyName("entries")] public List<KavehnegarMessageStatusResponseDtoEntry> Entries { get; set; }
}

public class KavehnegarMessageStatusResponseDtoEntry
{
    [JsonPropertyName("messageid")] public long Messageid { get; set; }

    [JsonPropertyName("status")] public MessageStatus Status { get; set; }

    [JsonPropertyName("statustext")] public string Statustext { get; set; }
}

public class KavehnegarMessageStatusResponseDtoReturn
{
    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
}