using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Abstracts;

internal abstract class KeenHtmlBodyElement<TSelf, TBase> : KeenHtmlElement<TSelf, TBase>, IKeenHtmlDisposableHtmlElement
    where TSelf : IKeenHtmlBodyElement<TSelf>
    where TBase : KeenHtmlElement<TSelf, TBase>, TSelf, IKeenHtmlDisposableHtmlElement
{
    public IHtmlHelper Html { get; }
    
    public abstract TagBuilder Tag { get; }

    public KeenHtmlBodyElement(IHtmlHelper html)
    {
        Html = html;
    }

    public abstract Task Build();

    public virtual async Task Initial()
    {
        await Build();
        
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