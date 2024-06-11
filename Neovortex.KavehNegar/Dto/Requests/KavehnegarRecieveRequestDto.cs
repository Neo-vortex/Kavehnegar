using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Model.Enums;
using Neovortex.KavehNegar.Model.Interfaces;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarReceiveRequestDto : IKavehNegarRequest
{
    public required MessageReadStatus ReadStatus { get; set; }
    public required string LineNumber { get; set; }

    public Dictionary<string, string> ConvertToDictionary()
    {
        return new Dictionary<string, string>
        {
            { "isread", ((int)ReadStatus).ToString() },
            { "linenumber", LineNumber }
        };
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(LineNumber)) throw new Exception("LineNumber must be provided");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarReceiveRequestDto FromEntity(KavehnegarReceiveRequest receiveRequest)
    {
        return new KavehnegarReceiveRequestDto
        {
            ReadStatus = receiveRequest.ReadStatus,
            LineNumber = receiveRequest.LineNumber
        };
    }
}