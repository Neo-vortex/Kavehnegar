using Neovortex.KavehNegar.Model.Enums;

namespace Neovortex.KavehNegar.Model;

public class KavehnegarLookupRequest
{
    public KavehnegarLookupRequest(Number receptor, string templateName, LookupMessageType? type = null,
        params string[] token)
    {
        Receptor = receptor;
        Tokens = token;
        TemplateName = templateName;
        MessageType = type;
    }

    public KavehnegarLookupRequest()
    {
    }

    public required Number Receptor { get; set; }

    public required string[] Tokens { get; set; }

    public required string TemplateName { get; set; }

    public LookupMessageType? MessageType { get; private set; }
}