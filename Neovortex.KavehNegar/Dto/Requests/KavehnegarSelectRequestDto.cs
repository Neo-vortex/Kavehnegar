using Neovortex.KavehNegar.Model.Interfaces;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarSelectRequestDto : IKavehNegarRequest
{
    public required List<long> Ids { get; set; }

    public Dictionary<string, string> ConvertToDictionary()
    {
        return new Dictionary<string, string>
        {
            {
                "messageid", string.Join(",", Ids.Select(item => item.ToString()))
            }
        };
    }

    public void Validate()
    {
        if (Ids.Any(item => item < 0)) throw new Exception("Ids must be positive");

        if (Ids.Count < 1) throw new Exception("At least one Id is required");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarSelectRequestDto FromEntity(List<long> ids)
    {
        return new KavehnegarSelectRequestDto
        {
            Ids = ids
        };
    }
}