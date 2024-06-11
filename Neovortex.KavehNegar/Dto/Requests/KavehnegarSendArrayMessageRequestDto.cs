using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Model.Enums;
using Neovortex.KavehNegar.Model.Interfaces;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar.Dto.Requests;

public class KavehnegarSendArrayMessageRequestDto : IKavehNegarRequest
{
    private static readonly JsonSerializerOptions _jsonSerializer = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public required string[] Receptors { get; set; }
    public required string[] Messages { get; set; }

    public required string[] Senders { get; set; }

    public long? Date { get; set; }

    public MessageType? Type { get; set; }

    public long[]? LocalIds { get; set; }

    public byte? Hide { get; set; }


    public Dictionary<string, string> ConvertToDictionary()
    {
        var result = new Dictionary<string, string>
        {
            { "receptor", JsonSerializer.Serialize(Receptors, _jsonSerializer) },
            {
                "message", JsonSerializer.Serialize(Messages
                        .Select(message => message
                            .ReplaceSpacesAndTabsWithThinSpace()).Select(WebUtility.HtmlEncode),
                    _jsonSerializer
                )
            },
            { "sender", JsonSerializer.Serialize(Senders, _jsonSerializer) }
        };
        if (Date != null) result.Add("date", Date.Value.ToString());
        if (Type != null) result.Add("type", ((int)Type).ToString());
        if (LocalIds != null) result.Add("localmessageids", JsonSerializer.Serialize(LocalIds, _jsonSerializer));
        if (Hide != null) result.Add("hide", Hide.Value.ToString());
        return result;
    }

    public void Validate()
    {
        if (Messages.Any(message => message.Length > Consts.MESSAGE_MAX_LEN))
            throw new Exception($"At least one Message is too long (>{Consts.MESSAGE_MAX_LEN} char)");

        if (Receptors.Length > Consts.RECEPTORS_MAX_COUNT)
            throw new Exception($"At least one Receptor is too long (>{Consts.RECEPTORS_MAX_COUNT} char)");

        if (Senders.Any(string.IsNullOrWhiteSpace)) throw new Exception("At least one Sender is empty");

        if (Messages.Any(string.IsNullOrWhiteSpace)) throw new Exception("At least one Message is empty");

        if (Receptors.Any(string.IsNullOrWhiteSpace)) throw new Exception("At least one Receptor is empty");

        if (LocalIds != null && LocalIds.Length != Receptors.Length)
            throw new Exception("LocalId length must be equal to Receptors length");

        if (LocalIds != null && LocalIds.Length != Receptors.Length)
            throw new Exception("LocalId length must be equal to Receptors length");

        if (Senders.Length != Receptors.Length) throw new Exception("Senders length must be equal to Receptors length");

        if (Receptors.Length != Messages.Length)
            throw new Exception("Receptors length must be equal to Messages length");
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent()
    {
        return new FormUrlEncodedContent(ConvertToDictionary());
    }

    public static KavehnegarSendArrayMessageRequestDto FromEntity(List<KavenegarSmsMessage> kavenegarSmsMessages,
        bool convertSpacesAndTabsToThinSpace = false)
    {
        if (kavenegarSmsMessages.Count == 0) throw new Exception("At least one message is required in SendArray API");
        if (kavenegarSmsMessages.DistinctBy(item => item.Date).Count() > 1)
            throw new Exception(
                " All messages must have the same date, as different dates are not supported in a single request yet.");

        if (kavenegarSmsMessages.DistinctBy(item => item.Hide).Count() > 1)
            throw new Exception(
                " All messages must have the same hide properties, as different hide properties are not supported in a single request yet.");

        if (kavenegarSmsMessages.Any(item => item.Receptors.Count > 1))
            throw new Exception(
                " All messages must have the one receptor, as different number of receptors are not supported in a single request yet.");
        return new KavehnegarSendArrayMessageRequestDto
        {
            Receptors = kavenegarSmsMessages.SelectMany(message => message.Receptors.Select(item => item.ToString()))
                .ToArray(),
            Messages = kavenegarSmsMessages.Select(message =>
                    convertSpacesAndTabsToThinSpace
                        ? message.Message.ReplaceSpacesAndTabsWithThinSpace()
                        : message.Message)
                .ToArray(),
            Senders = kavenegarSmsMessages.Select(message =>
                message.Sender?.ToString() ?? throw new Exception("Sender is required in SendArray API")).ToArray(),
            Date = kavenegarSmsMessages.First().Date?.GetUnixTimestamp(),
            Type = kavenegarSmsMessages.First().MessageType,
            LocalIds = kavenegarSmsMessages.First().LocalId.HasValue
                ? kavenegarSmsMessages.Select(message => message.LocalId!.Value).ToArray()
                : null,
            Hide = kavenegarSmsMessages.First().Hide.HasValue
                ? kavenegarSmsMessages.First().Hide!.Value ? (byte)1 : (byte)0
                : null
        };
    }
}