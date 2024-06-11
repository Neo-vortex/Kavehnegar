using System.Text.Json.Serialization;

namespace Neovortex.KavehNegar.Dto.Responses;

public class KavehnegarTimeResponseDto
{
    [JsonPropertyName("return")] public KavehnegarTimeResponseDtoReturn Return { get; set; }

    [JsonPropertyName("entries")] public KavehnegarTimeResponseDtoEntries Entries { get; set; }
}

public class KavehnegarTimeResponseDtoEntries
{
    [JsonPropertyName("datetime")] public string Datetime { get; set; }

    [JsonPropertyName("year")] public long Year { get; set; }

    [JsonPropertyName("month")] public long Month { get; set; }

    [JsonPropertyName("day")] public long Day { get; set; }

    [JsonPropertyName("hour")] public long Hour { get; set; }

    [JsonPropertyName("minute")] public long Minute { get; set; }

    [JsonPropertyName("second")] public long Second { get; set; }

    [JsonPropertyName("unixtime")] public long Unixtime { get; set; }
}

public class KavehnegarTimeResponseDtoReturn
{
    [JsonPropertyName("status")] public long Status { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
}