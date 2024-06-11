using System.Text.Json.Serialization;

namespace Neovortex.KavehNegar.Dto.Responses;

public class KavehnegarSendMessageResponseDto
{
    [JsonPropertyName("return")] public KavehnegarSendSimpleMessgeResponseDtoReturn Return { get; set; }

    [JsonPropertyName("entries")] public List<KavehnegarSendSimpleMessgeResponseDtoEntry> Entries { get; set; }
}

public class KavehnegarSendSimpleMessgeResponseDtoEntry
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

public class KavehnegarSendSimpleMessgeResponseDtoReturn
{
    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
}