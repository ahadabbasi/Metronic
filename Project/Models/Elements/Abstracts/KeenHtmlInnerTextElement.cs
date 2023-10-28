using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Models.Elements.Abstracts;

internal abstract class KeenHtmlInnerTextElement<TSelf, TBase> : KeenHtmlElement<TSelf, TBase>, IKeenHtmlInnerTextElement<TSelf> 
    where TSelf : IKeenHtmlElement<TSelf> 
    where TBase : KeenHtmlInnerTextElement<TSelf, TBase>, TSelf
{
    protected IHtmlContent InnerHtml { get; set; }

    public KeenHtmlInnerTextElement()
    {
        InnerHtml = new HtmlString(string.Empty);
    }
    
    public TSelf InnerText(string text)
    {
        InnerHtml = new HtmlString(text);
        
        return (TBase)this;
    }
}