using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Abstracts;

internal abstract class KeenHtmlBodyElement : KeenHtmlElement<IKeenHtmlBodyElement, KeenHtmlBodyElement>, 
    IKeenHtmlBodyElement, 
    IKeenHtmlDisposableHtmlElement
{
    public IHtmlHelper Html { get; }
    
    public abstract TagBuilder Tag { get; }

    public KeenHtmlBodyElement(IHtmlHelper html)
    {
        Html = html;
    }

    public virtual async Task Initial()
    {
        Tag.MergeAttributes(Attributes);
        
        await using StringWriter writer = new StringWriter();
        Tag.RenderStartTag().WriteTo(writer, HtmlEncoder.Default);
        await Html.ViewContext.Writer.WriteAsync(writer.ToString());
    }

    public virtual async Task Terminate()
    {
        await using StringWriter writer = new StringWriter();
        Tag.RenderEndTag().WriteTo(writer, HtmlEncoder.Default);
        await Html.ViewContext.Writer.WriteAsync(writer.ToString());
    }
}