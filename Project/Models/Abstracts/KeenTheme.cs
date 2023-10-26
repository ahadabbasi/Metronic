using Ahada.Metronic.Contracts;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Assets;
using Ahada.Metronic.Models.Assets;
using Microsoft.Extensions.Configuration;

namespace Ahada.Metronic.Models.Abstracts;

public class KeenTheme : IKeenTheme<IKeenAssetFontsScriptsStyles>
{
    private IConfiguration Configuration { get; }

    public KeenTheme(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public string Directory 
        => Configuration.GetSection(nameof(Directory)).ToString() ?? string.Empty;
    
    public string Version 
        => Configuration.GetSection(nameof(Version)).ToString() ?? string.Empty;
    
    public string ThemeName
        => Configuration.GetSection(nameof(ThemeName)).ToString() ?? string.Empty;
    
    public IKeenAssetFontsScriptsStyles Assets 
        => new KeenAssetFontsScriptsStyles(Configuration.GetSection(nameof(Directory)));
}