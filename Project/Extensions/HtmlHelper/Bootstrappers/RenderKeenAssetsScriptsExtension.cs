using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Extensions.HtmlHelper.Bootstrappers;

public static class RenderKeenAssetsScriptsExtension
{
    public static async Task RenderKeenAssetsScripts(this IHtmlHelper html)
    {
        IEnumerable<string> scripts = await html.GetKeenAssetsScripts();

        foreach (string script in scripts)
        {
            TagBuilder scriptTag = new TagBuilder("script")
            {
                TagRenderMode = TagRenderMode.Normal,
                Attributes =
                {
                    { "src", script }
                }
            };
            
            scriptTag.WriteTo(html.ViewContext.Writer, HtmlEncoder.Default);
        }
    }
}