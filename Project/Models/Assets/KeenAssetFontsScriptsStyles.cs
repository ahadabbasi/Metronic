using System.Collections.Generic;
using Ahada.Metronic.Contracts.Assets;
using Microsoft.Extensions.Configuration;

namespace Ahada.Metronic.Models.Assets;

internal class KeenAssetFontsScriptsStyles : IKeenAssetFontsScriptsStyles
{
    private IConfiguration Configuration { get; }

    public KeenAssetFontsScriptsStyles(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IEnumerable<string> Scripts
        => Conversion(Configuration.GetSection(nameof(Scripts)).ToString());

    public IEnumerable<string> Styles 
        => Conversion(Configuration.GetSection(nameof(Styles)).ToString());

    public IEnumerable<string> Fonts 
        => Conversion(Configuration.GetSection(nameof(Fonts)).ToString());

    private IEnumerable<string> Conversion(string? entry)
        => System.Text.Json.JsonSerializer.Deserialize<IEnumerable<string>>(
            entry ??
            System.Text.Json.JsonSerializer.Serialize(new string[] { })
        ) ?? new string[] { };
}