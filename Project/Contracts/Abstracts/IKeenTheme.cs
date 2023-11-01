namespace Ahada.Metronic.Contracts.Abstracts;

public interface IKeenTheme<TAssets> where TAssets : IKeenAssets
{
    
    string Path { get; }
    
    string Version { get; }
    
    string Theme { get; }
    
    TAssets Assets { get; }
}