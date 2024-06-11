namespace Neovortex.KavehNegar.Utilities;

public static class DatetimeUtilities
{
    public static long GetUnixTimestamp(this DateTime datetime)
    {
        return new DateTimeOffset(datetime).ToUnixTimeSeconds();
    }
}