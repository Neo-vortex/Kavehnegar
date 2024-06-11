using System.Text.Json.Serialization;

namespace Neovortex.KavehNegar.Dto.Responses;

public class KavehnegarTtsResponseDto
{
    [JsonPropertyName("return")] public KavehnegarTtsResponseDtoReturn Return { get; set; }

    [JsonPropertyName("entries")] public KavehnegarTtsResponseDtoEntries Entries { get; set; }
}

public class KavehnegarTtsResponseDtoEntries
{
    [JsonPropertyName("messageid")] public long Messageid { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }

    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("statustext")] public string Statustext { get; set; }

    [JsonPropertyName("sender")] public string Sender { get; set; }

    [JsonPropertyName("receptor")] public string Receptor { get; set; }

    [JsonPropertyName("date")] public long Date { get; set; }

    [JsonPropertyName("cost")] public long Cost { get; set; }
}

public class KavehnegarTtsResponseDtoReturn
{
    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
}