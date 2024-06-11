namespace Neovortex.KavehNegar.Utilities;

public class PathBuilderUtilities
{
    private readonly string _apiKey;

    public PathBuilderUtilities(string apiKey)
    {
        _apiKey = apiKey;
    }

    public Uri BuildUri(string scope, string methodName, string outputFormat = "json")
    {
        return new Uri($"{Consts.BASE_URL}{_apiKey}/{scope}/{methodName}.{outputFormat}");
    }
}