using Ahada.Metronic.Contracts;
using Ahada.Metronic.Contracts.Assets;
using Ahada.Metronic.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ahada.Metronic;

public class Startup
{
    public IServiceCollection ConfigurationService(IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IKeenTheme<IKeenAssetFontsScriptsStyles>>(_ =>
            new KeenTheme(configuration.GetSection(nameof(Metronic)))
        );

        /*
        services.AddScoped<IKeenBootstrap, KeenBootstrap>();

        services.AddScoped<IHtmlGenerator, HtmlGenerator>();

        services.AddHttpContextAccessor();
        */
        
        return services;
    }
}