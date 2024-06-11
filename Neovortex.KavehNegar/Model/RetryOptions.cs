namespace Neovortex.KavehNegar.Model;

public record RetryOptions
{
    public required int MaxTry { get; set; }

    public required int WaitBetweenTriesMilliseconds { get; set; }
}