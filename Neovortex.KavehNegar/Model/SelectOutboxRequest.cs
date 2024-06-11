namespace Neovortex.KavehNegar.Model;

public class SelectOutboxRequest
{
    public Number? Sender { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }
}