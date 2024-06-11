using Neovortex.KavehNegar.Model.Enums;

namespace Neovortex.KavehNegar.Model;

public class KavehnegarCountInboxRequest
{
    public required DateTime Start { get; set; }

    public DateTime? End { get; set; } = DateTime.UtcNow;

    public required Number LineNumber { get; set; }

    public required MessageReadStatus Status { get; set; }
}