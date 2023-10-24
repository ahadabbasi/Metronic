using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ahada.Metronic.Extensions.ServiceCollection;

public static class ImplementMetronicToServiceExtension
{
    public static IServiceCollection ImplementMetronicToService(this IServiceCollection collection,
        IConfiguration configuration)
    {
        Startup startup = new Startup();

        return startup.ConfigurationService(collection, configuration);
    }
}