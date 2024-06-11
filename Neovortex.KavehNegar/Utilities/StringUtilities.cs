namespace Neovortex.KavehNegar.Utilities;

internal static class StringUtilities
{
    private const string THIN_SPACE = "\u2009";

    internal static string ReplaceSpacesAndTabsWithThinSpace(this string input)
    {
        return input
            .Replace(" ", THIN_SPACE)
            .Replace("\t", THIN_SPACE);
    }
}