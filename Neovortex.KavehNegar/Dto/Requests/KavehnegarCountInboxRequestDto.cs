using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Model.Enums;
using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarCountInboxRequestDto : IKavehNegarRequest
{
    public DateTime Start { get; set; }

    public DateTime? End { get; set; }

    public string? LineNumber { get; set; }

    public MessageReadStatus? Status { get; set; }

    public Dictionary<string, string> ConvertToDictionary()
    {
        var result = new Dictionary<string, string>
        {
            { "startdate", Start.GetUnixTimestamp().ToString() }
        };
        if (End != null) result.Add("enddate", End.Value.GetUnixTimestamp().ToString());
        if (LineNumber != null) result.Add("linenumber", LineNumber);
        if (Status != null) result.Add("isread", ((int)Status).ToString());
        return result;
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(LineNumber)) throw new Exception("LineNumber must be provided");

        if (Start > End) throw new Exception("End time must be greater than start time");

        if (string.IsNullOrWhiteSpace(LineNumber)) throw new Exception("LineNumber must be provided");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarCountInboxRequestDto FromEntity(KavehnegarCountInboxRequest request)
    {
        return new KavehnegarCountInboxRequestDto
        {
            Start = request.Start,
            End = request.End,
            LineNumber = request.LineNumber,
            Status = request.Status
        };
    }
}