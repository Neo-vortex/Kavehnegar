using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarLocalMessageIdStatusRequestDto : IKavehNegarRequest
{
    public required List<long> Ids { get; set; }

    public Dictionary<string, string> ConvertToDictionary()
    {
        return new Dictionary<string, string>
        {
            {
                "localid", string.Join(",", Ids.Select(item => item.ToString()))
            }
        };
    }

    public void Validate()
    {
        if (Ids.Any(item => item < 0)) throw new ArgumentException("Ids must be positive");

        if (Ids.Count > Consts.RECEPTORS_MAX_COUNT)
            throw new ArgumentException($"Ids count must be less than {Consts.RECEPTORS_MAX_COUNT} ");

        if (Ids.Count < 1) throw new ArgumentException("At least one Id is required");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarLocalMessageIdStatusRequestDto FromEntity(List<long> ids)
    {
        return new KavehnegarLocalMessageIdStatusRequestDto
        {
            Ids = ids
        };
    }
}