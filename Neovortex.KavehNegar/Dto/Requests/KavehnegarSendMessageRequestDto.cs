using System.Net;
using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Model.Enums;
using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarSendMessageRequestDto : IKavehNegarRequest
{
    public required string Receptor { get; set; }

    public required string Message { get; set; }

    public string? Sender { get; set; }

    public long? Date { get; set; }

    public MessageType? Type { get; set; }

    public long? LocalId { get; set; }

    public byte? Hide { get; set; }


    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public Dictionary<string, string> ConvertToDictionary()
    {
        var result = new Dictionary<string, string>
        {
            { "receptor", Receptor },
            {
                "message", WebUtility.HtmlEncode(Message
                    .ReplaceSpacesAndTabsWithThinSpace())
            }
        };
        if (Sender != null) result.Add("sender", Sender);
        if (Date != null) result.Add("date", Date.Value.ToString());
        if (Type != null) result.Add("type", ((int)Type).ToString());
        if (LocalId != null) result.Add("localid", LocalId.ToString()!);
        if (Hide != null) result.Add("hide", Hide.Value.ToString());


        return result;
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Receptor))
            throw new Exception("Receptor is required and cannot be null or empty");
        if (string.IsNullOrWhiteSpace(Message)) throw new Exception("Message is required and cannot be null or empty");

        if (string.IsNullOrWhiteSpace(Sender)) throw new Exception("Sender is required in Send API");

        if (Message.Length > Consts.MESSAGE_MAX_LEN)
            throw new Exception($"Message length is more than allowed limit of {Consts.MESSAGE_MAX_LEN} characters");

        if (Receptor.Length > Consts.RECEPTORS_MAX_COUNT)
            throw new Exception($"Receptor count is more than allowed limit of {Consts.RECEPTORS_MAX_COUNT} item");
    }

    public static KavehnegarSendMessageRequestDto FromEntity(KavenegarSmsMessage kavenegarSmsMessage,
        bool convertSpacesAndTabsToThinSpace = false)
    {
        return new KavehnegarSendMessageRequestDto
        {
            Receptor = string.Join(",", kavenegarSmsMessage.Receptors),
            Message = convertSpacesAndTabsToThinSpace
                ? kavenegarSmsMessage.Message.ReplaceSpacesAndTabsWithThinSpace()
                : kavenegarSmsMessage.Message,
            Sender = kavenegarSmsMessage.Sender?.ToString(),
            Date = kavenegarSmsMessage.Date?.GetUnixTimestamp(),
            Type = kavenegarSmsMessage.MessageType,
            LocalId = kavenegarSmsMessage.LocalId,
            Hide = kavenegarSmsMessage.Hide.HasValue ? kavenegarSmsMessage.Hide.Value ? (byte)1 : (byte)0 : null
        };
    }
}