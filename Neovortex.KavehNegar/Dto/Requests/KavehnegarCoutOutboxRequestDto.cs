using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Model.Enums;
using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarCoutOutboxRequestDto : IKavehNegarRequest
{
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public MessageStatus? MessageStatus { get; set; }

    public Dictionary<string, string> ConvertToDictionary()
    {
        var result = new Dictionary<string, string>();
        if (Start != null) result.Add("startdate", Start.Value.GetUnixTimestamp().ToString());
        if (End != null) result.Add("enddate", End.Value.GetUnixTimestamp().ToString());
        if (MessageStatus != null) result.Add("status", ((int)MessageStatus).ToString());
        return result;
    }

    public void Validate()
    {
        if (End < Start) throw new Exception("End time must be greater than start time");

        if (End - Start > TimeSpan.FromDays(1)) throw new Exception("Time range must be less than one day");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarCoutOutboxRequestDto FromEntity(KavehnegarCoutOutboxRequest coutOutboxRequest)
    {
        return new KavehnegarCoutOutboxRequestDto
        {
            Start = coutOutboxRequest.Start,
            End = coutOutboxRequest.End,
            MessageStatus = coutOutboxRequest.MessageStatus
        };
    }
}