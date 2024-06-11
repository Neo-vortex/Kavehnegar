using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Model.Enums;
using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarLookupRequestDto : IKavehNegarRequest
{
    public required string Receptor { get; set; }

    public required string[] Tokens { get; set; }

    public required string TemplateName { get; set; }

    public LookupMessageType? MessageType { get; set; }


    public Dictionary<string, string> ConvertToDictionary()
    {
        var result = new Dictionary<string, string>
        {
            { "receptor", Receptor },
            { "template", TemplateName }
        };
        if (MessageType != null) result.Add("type", (MessageType.ToString()));
        for (var i = 0; i < Tokens.Length; i++)
            result.Add($"token{(i == 0 ? string.Empty : i)}", Tokens[i].ReplaceSpacesAndTabsWithThinSpace());
        return result;
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Receptor)) throw new Exception("Receptor must be provided");

        if (string.IsNullOrWhiteSpace(TemplateName)) throw new Exception("TemplateName must be provided");
        if (Tokens == null || Tokens.Length == 0) throw new Exception("Tokens must be provided");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarLookupRequestDto FromEntity(KavehnegarLookupRequest request)
    {
        return new KavehnegarLookupRequestDto
        {
            Receptor = request.Receptor!,
            MessageType = request.MessageType,
            TemplateName = request.TemplateName,
            Tokens = request.Tokens
        };
    }
}