using Neovortex.KavehNegar.Model.Enums;

namespace Neovortex.KavehNegar.Model;

public record KavenegarSmsMessage
{
    public MessageType? MessageType;

    public required List<Number> Receptors { get; set; }

    public required string Message { get; set; }

    public Number? Sender { get; set; }

    public DateTime? Date { get; set; }

    public long? LocalId { get; set; }

    public bool? Hide { get; set; }
}