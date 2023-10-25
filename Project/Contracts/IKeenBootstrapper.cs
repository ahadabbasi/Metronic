namespace Ahada.Metronic.Contracts;

public interface IKeenBootstrapper
{
    Task<string> GetAddressOf(string fileAddress);

    Task<IEnumerable<string>> GetScripts();
    
    Task<IEnumerable<string>> GetStyles();
    
    Task<IEnumerable<string>> GetFonts();
}