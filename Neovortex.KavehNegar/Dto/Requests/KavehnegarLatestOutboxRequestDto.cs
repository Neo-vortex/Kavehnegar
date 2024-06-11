using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarLatestOutboxRequestDto : IKavehNegarRequest
{
    public string? Sender { get; set; }

    public long? PageSize { get; set; }


    public Dictionary<string, string> ConvertToDictionary()
    {
        var result = new Dictionary<string, string>();
        if (Sender != null) result.Add("sender", Sender);
        if (PageSize != null) result.Add("pagesize", PageSize.ToString()!);
        return result;
    }

    public void Validate()
    {
        if (PageSize > Consts.MAX_PAGE_SIZE)
            throw new ArgumentException($"Page size must be less than {Consts.MAX_PAGE_SIZE}");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarLatestOutboxRequestDto FromEntity(
        KavehnegarLatestOutboxRequest kavehnegarLatestOutboxRequest)
    {
        return new KavehnegarLatestOutboxRequestDto
        {
            Sender = kavehnegarLatestOutboxRequest.Sender,
            PageSize = kavehnegarLatestOutboxRequest.PageSize
        };
    }
}