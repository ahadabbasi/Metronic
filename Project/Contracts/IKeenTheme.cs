namespace Ahada.Metronic.Contracts;

public interface IKeenTheme<TAssets> where TAssets : IKeenAssets
{
    
    string Directory { get; }
    
    string Version { get; }
    
    string ThemeName { get; }
    
    TAssets Assets { get; }
}