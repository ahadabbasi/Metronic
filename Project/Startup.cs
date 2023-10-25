using Ahada.Metronic.Contracts;
using Ahada.Metronic.Contracts.Assets;
using Ahada.Metronic.Models;
using Ahada.Metronic.Services;
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
        
        services.AddScoped<IKeenHtmlHelper, KeenHtmlHelper>();
        
        services.AddScoped<IKeenBootstrapper, KeenBootstrapper>();

        /*
        

        

        services.AddHttpContextAccessor();
        */
        
        return services;
    }
}