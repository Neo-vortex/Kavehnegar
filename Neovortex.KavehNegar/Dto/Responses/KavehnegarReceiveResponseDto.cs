using System.Text.Json.Serialization;

namespace Neovortex.KavehNegar.Dto.Responses;

public class KavehnegarReceiveResponseDto
{
    [JsonPropertyName("return")] public KavehnegaRecievelResponseDtoReturn Return { get; set; }

    [JsonPropertyName("entries")] public List<KavehnegaRecievelResponseDtoEntry> Entity { get; set; }
}

public class KavehnegaRecievelResponseDtoEntry
{
    [JsonPropertyName("messageid")] public long Messageid { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }

    [JsonPropertyName("sender")] public string Sender { get; set; }

    [JsonPropertyName("receptor")] public string Receptor { get; set; }

    [JsonPropertyName("date")] public long Date { get; set; }
}

public class KavehnegaRecievelResponseDtoReturn
{
    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
}