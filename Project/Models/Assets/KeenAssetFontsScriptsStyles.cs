using System.Collections.Generic;
using Ahada.Metronic.Contracts.Assets;
using Microsoft.Extensions.Configuration;

namespace Ahada.Metronic.Models.Assets;

internal record KeenAssetsBind
{
    public string[] Scripts { get; set; } = { };
    public string[] Fonts { get; set; } = { };
    public string[] Styles { get; set; } = { };
}

internal class KeenAssetFontsScriptsStyles : IKeenAssetFontsScriptsStyles
{
    private KeenAssetsBind Bind { get; }

    private IConfiguration Configuration { get; }

    public KeenAssetFontsScriptsStyles(IConfiguration configuration)
    {
        Configuration = configuration;
        KeenAssetsBind? bind = Configuration.Get<KeenAssetsBind>();
        Bind = bind ?? new KeenAssetsBind();
    }

    public IEnumerable<string> Scripts
        => Bind.Scripts;

    public IEnumerable<string> Styles
        => Bind.Styles;

    public IEnumerable<string> Fonts
        => Bind.Fonts;
}