using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarSelectOutboxRequestDto : IKavehNegarRequest
{
    public string? Sender { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndTime { get; set; }

    public Dictionary<string, string> ConvertToDictionary()
    {
        var result = new Dictionary<string, string>();
        if (Sender != null) result.Add("sender", Sender);
        if (StartDate != null) result.Add("startdate", StartDate.Value.GetUnixTimestamp().ToString());
        if (EndTime != null) result.Add("enddate", EndTime.Value.GetUnixTimestamp().ToString());
        return result;
    }

    public void Validate()
    {
        if (EndTime < StartDate) throw new ArgumentException("End time must be greater than start time");

        if (EndTime - StartDate > TimeSpan.FromDays(1))
            throw new ArgumentException("Time range must be less than one day");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarSelectOutboxRequestDto FromEntity(string? sender, DateTime? startDate, DateTime? endTime)
    {
        return new KavehnegarSelectOutboxRequestDto
        {
            Sender = sender,
            StartDate = startDate,
            EndTime = endTime
        };
    }
}