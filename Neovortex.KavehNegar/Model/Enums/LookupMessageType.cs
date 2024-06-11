namespace Neovortex.KavehNegar.Model.Enums;

public abstract class LookupMessageType
{
    
}

public class SMS : LookupMessageType
{
    public override string ToString()
    {
        return "sms";
    }
}

public class CALL : LookupMessageType
{
    public override string ToString()
    {
        return "call";
    }
}