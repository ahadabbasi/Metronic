namespace Ahada.Metronic.Contracts.Abstracts;

public interface IKeenBootstrapper
{
    Task<string> GetAddressOf(string fileAddress);

    Task<IEnumerable<string>> GetScripts();
    
    Task<IEnumerable<string>> GetStyles();
    
    Task<IEnumerable<string>> GetFonts();
}