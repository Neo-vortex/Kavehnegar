using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Model.Interfaces;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavenegarCancelRequestDto : IKavehNegarRequest
{
    public long Id { get; set; }


    public Dictionary<string, string> ConvertToDictionary()
    {
        return new Dictionary<string, string>
        {
            { "messageid", Id.ToString() }
        };
    }

    public void Validate()
    {
        if (Id < 0) throw new Exception("Id must be greater than zero");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavenegarCancelRequestDto FromEntity(KavenegarCancelRequest cancelRequest)
    {
        return new KavenegarCancelRequestDto
        {
            Id = cancelRequest.Id
        };
    }
}