namespace Neovortex.KavehNegar.Model;

public class KavehnegarTtsRequest
{
    public required Number Receptor { get; set; }

    public required string Message { get; set; }

    public DateTime? Date { get; set; }

    public long? LocalId { get; set; }

    public int? Repeat { get; set; }
}