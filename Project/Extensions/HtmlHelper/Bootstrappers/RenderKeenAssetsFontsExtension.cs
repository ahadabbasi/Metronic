using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Extensions.HtmlHelper.Bootstrappers;

public static class RenderKeenAssetsFontsExtension
{
    public static async Task RenderKeenAssetsFonts(this IHtmlHelper html)
    {
        IEnumerable<string> fonts = await html.GetKeenAssetsFonts();

        foreach (string font in fonts)
        {
            TagBuilder fontTag = new TagBuilder("link")
            {
                TagRenderMode = TagRenderMode.SelfClosing,
                Attributes =
                {
                    { "rel", "stylesheet" },
                    { "href", font }
                }
            };

            fontTag.WriteTo(html.ViewContext.Writer, HtmlEncoder.Default);
        }
    }
}