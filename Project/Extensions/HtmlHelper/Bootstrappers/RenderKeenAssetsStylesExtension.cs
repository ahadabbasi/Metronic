using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Extensions.HtmlHelper.Bootstrappers;

public static class RenderKeenAssetsStylesExtension
{
    public static async Task RenderKeenAssetsStyles(this IHtmlHelper html)
    {
        IEnumerable<string> styles = await html.GetKeenAssetsStyles();

        foreach (string style in styles)
        {
            TagBuilder styleTag = new TagBuilder("link")
            {
                TagRenderMode = TagRenderMode.SelfClosing,
                Attributes =
                {
                    { "rel", "stylesheet" },
                    { "href", style },
                    { "type", "text/css" }
                }
            };

            styleTag.WriteTo(html.ViewContext.Writer, HtmlEncoder.Default);
        }
    }
}