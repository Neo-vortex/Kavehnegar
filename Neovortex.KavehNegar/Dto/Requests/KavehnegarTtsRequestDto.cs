using System.Net;
using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarTtsRequestDto : IKavehNegarRequest
{
    public required string Receptor { get; set; }

    public required string Message { get; set; }

    public DateTime? Date { get; set; }
    public long? LocalId { get; set; }
    public int? Repeat { get; set; }

    public Dictionary<string, string> ConvertToDictionary()
    {
        var result = new Dictionary<string, string>
        {
            { "receptor", Receptor },
            { "message", WebUtility.HtmlEncode(Message) }
        };

        if (Date.HasValue) result.Add("date", Date.Value.GetUnixTimestamp().ToString());

        if (LocalId.HasValue) result.Add("localid", LocalId.Value.ToString());

        if (Repeat.HasValue) result.Add("repeat", Repeat.Value.ToString());

        return result;
    }

    public void Validate()
    {
        if (Repeat.HasValue) throw new Exception("Repeat feature is not implemented yet.");

        if (string.IsNullOrWhiteSpace(Receptor)) throw new Exception("Receptor must be provided");

        if (string.IsNullOrWhiteSpace(Message)) throw new Exception("Message must be provided");

        if (LocalId is < 0) throw new Exception("LocalId must be greater than or equal to zero");

        if (Date.HasValue && Date < DateTime.UtcNow)
            throw new Exception("Date must be greater than or equal to current date");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarTtsRequestDto FromEntity(KavehnegarTtsRequest request)
    {
        return new KavehnegarTtsRequestDto
        {
            Receptor = request.Receptor.ToString(),
            Message = request.Message,
            Date = request.Date,
            LocalId = request.LocalId,
            Repeat = request.Repeat
        };
    }
}