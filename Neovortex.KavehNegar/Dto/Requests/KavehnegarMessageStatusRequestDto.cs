using System.Text.Encodings.Web;
using System.Text.Json;
using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarMessageStatusRequestDto : IKavehNegarRequest
{
    private static readonly JsonSerializerOptions _jsonSerializer = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

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
        if (Ids.Any(item => item < 0)) throw new ArgumentException("Ids must be positive");

        if (Ids.Count > Consts.RECEPTORS_MAX_COUNT)
            throw new ArgumentException($"Ids count must be less than {Consts.RECEPTORS_MAX_COUNT} ");

        if (Ids.Count < 1) throw new ArgumentException("At least one Id is required");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarMessageStatusRequestDto FromEntity(List<long> ids)
    {
        return new KavehnegarMessageStatusRequestDto
        {
            Ids = ids
        };
    }
}