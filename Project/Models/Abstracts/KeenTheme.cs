using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Assets;
using Ahada.Metronic.Models.Assets;
using Microsoft.Extensions.Configuration;

namespace Ahada.Metronic.Models.Abstracts;

internal record KeenThemeBind
{
    public string Path { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    public string Theme { get; set; } = string.Empty;
}

internal class KeenTheme : IKeenTheme<IKeenAssetFontsScriptsStyles>
{
    private IConfiguration Configuration { get; }

    private KeenThemeBind Bind { get; }


    public KeenTheme(IConfiguration configuration)
    {
        Configuration = configuration;
        KeenThemeBind? bind = Configuration.Get<KeenThemeBind>();
        Bind = bind ?? new KeenThemeBind();
    }

    public string Path
        => Bind.Path;

    public string Version
        => Bind.Version;

    public string Theme
        => Bind.Theme;

    public IKeenAssetFontsScriptsStyles Assets
        => new KeenAssetFontsScriptsStyles(Configuration.GetSection(nameof(Assets)));
}