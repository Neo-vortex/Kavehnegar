namespace Neovortex.KavehNegar.Model.Interfaces;

public interface IKavehNegarRequest
{
    Dictionary<string, string> ConvertToDictionary();
    void Validate();
    FormUrlEncodedContent ToFormUrlEncodedContent();
}