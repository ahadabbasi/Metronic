using Ahada.Metronic.Contracts.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace Ahada.Metronic.Extensions.HtmlHelper.Bootstrappers;

public static class GetKeenAssetPathOfExtension
{
    public static async Task<string> GetKeenAssetPathOf(this IHtmlHelper html, string assetsAddress)
    {
        string result = assetsAddress;

        IKeenBootstrapper? bootstrap = html.ViewContext.HttpContext.RequestServices.GetService<IKeenBootstrapper>();

        if (bootstrap != null)
        {
            result = await bootstrap.GetAddressOf(result);
        }
        
        return result;
    }
}