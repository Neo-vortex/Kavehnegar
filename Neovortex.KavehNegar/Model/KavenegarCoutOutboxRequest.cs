using Neovortex.KavehNegar.Model.Enums;

namespace Neovortex.KavehNegar.Model;

public class KavehnegarCoutOutboxRequest
{
    public required DateTime Start { get; set; }

    public DateTime End { get; set; } = DateTime.UtcNow;

    public MessageStatus? MessageStatus { get; set; }
}