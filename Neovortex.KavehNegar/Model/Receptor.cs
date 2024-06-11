namespace Neovortex.KavehNegar.Model;

public record Number
{
    private readonly string _number;

    public Number(string number)
    {
        _number = number;
    }

    public override string ToString()
    {
        return _number;
    }

    public static implicit operator string?(Number? receptor)
    {
        return receptor?._number;
    }

    public static implicit operator Number(string receptor)
    {
        return new Number(receptor);
    }
}