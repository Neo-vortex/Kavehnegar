using Neovortex.KavehNegar.Model.Enums;

namespace Neovortex.KavehNegar.Model;

public class KavehnegarReceiveRequest
{
    public required MessageReadStatus ReadStatus { get; set; }
    public required string LineNumber { get; set; }
}