using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Assets;
using Ahada.Metronic.Models.Abstracts;
using Ahada.Metronic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ahada.Metronic;

internal class Startup
{
    public IServiceCollection ConfigurationService(IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IKeenTheme<IKeenAssetFontsScriptsStyles>>(_ =>
            new KeenTheme(configuration.GetSection(nameof(Metronic)))
        );
        
        services.AddScoped<IKeenHtmlHelper, KeenHtmlHelper>();
        
        services.AddScoped<IKeenBootstrapper, KeenBootstrapper>();

        services.AddTransient<IKeenPartialRenderer, KeenPartialRenderer>();

        /*
        

        

        services.AddHttpContextAccessor();
        */
        
        return services;
    }
}