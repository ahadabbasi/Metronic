using System.Collections.Generic;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace Ahada.Metronic.Extensions.HtmlHelper.Bootstrappers;

public static class GetKeenAssetsFontsExtension
{
    public static async Task<IEnumerable<string>> GetKeenAssetsFonts(this IHtmlHelper html)
    {
        IList<string> result = new List<string>();

        IKeenBootstrapper? bootstrap = html.ViewContext.HttpContext.RequestServices.GetService<IKeenBootstrapper>();

        if (bootstrap != null)
        {
            foreach (string script in await bootstrap.GetFonts())
            {
                result.Add(script);
            }
        }

        return result;
    }
}