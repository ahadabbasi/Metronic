using Ahada.Metronic.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace Ahada.Metronic.Extensions.HtmlHelper.Bootstrappers;

public static class GetKeenAssetsStylesExtension
{
    public static async Task<IEnumerable<string>> GetKeenAssetsStyles(this IHtmlHelper html)
    {
        IList<string> result = new List<string>();

        IKeenBootstrapper? bootstrap = html.ViewContext.HttpContext.RequestServices.GetService<IKeenBootstrapper>();

        if (bootstrap != null)
        {
            foreach (string style in await bootstrap.GetStyles())
            {
                result.Add(style);
            }
        }

        return result;
    }
}