using Ahada.Metronic.Contracts;
using Ahada.Metronic.Contracts.Assets;
using Microsoft.AspNetCore.Hosting;

namespace Ahada.Metronic.Services;

public class KeenBootstrapper : IKeenBootstrapper
{
    private IKeenTheme<IKeenAssetFontsScriptsStyles> Theme { get; }
    
    private IHostingEnvironment Environment { get; }
    
    private string AssestsPath { get; }

    public KeenBootstrapper(IKeenTheme<IKeenAssetFontsScriptsStyles> theme, IHostingEnvironment environment)
    {
        Theme = theme;
        
        Environment = environment;
        
        AssestsPath = string.Format(Theme.Directory, Theme.Version);

        if (!string.IsNullOrEmpty(Theme.Version))
        {
            AssestsPath = $"{AssestsPath}themes/{Theme.ThemeName}/";
        }
        
        AssestsPath = $"{AssestsPath}dist/";

        if (!Path.Exists(Path.Combine(Environment.WebRootPath, AssestsPath.Substring(1))))
        {
            throw new Exception(string.Empty);
        }
    }

    public Task<string> GetAddressOf(string fileAddress)
    {
        fileAddress = fileAddress.StartsWith('/') ? fileAddress.Substring(1) : fileAddress;
        
        fileAddress = $"{AssestsPath}{fileAddress}";
        
        if (!Path.Exists(Path.Combine(Environment.WebRootPath, fileAddress.Substring(1))))
        {
            throw new Exception(string.Empty);
        }

        return Task.FromResult(fileAddress); 
    }

    public async Task<IEnumerable<string>> GetScripts()
    {
        IList<string> scripts = new List<string>();
        
        foreach (string script in Theme.Assets.Scripts)
        {
            scripts.Add(await GetAddressOf(script));
        }
        
        return scripts;
    }

    public async Task<IEnumerable<string>> GetStyles()
    {
        IList<string> styles = new List<string>();
        
        foreach (string style in Theme.Assets.Styles)
        {
            styles.Add(await GetAddressOf(style));
        }
        
        return styles;
    }

    public async Task<IEnumerable<string>> GetFonts()
    {
        IList<string> fonts = new List<string>();
        
        foreach (string font in Theme.Assets.Fonts)
        {
            fonts.Add(await GetAddressOf(font));
        }
        
        return fonts;
    }
}