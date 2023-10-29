using System;
using System.IO;
using System.Text.Encodings.Web;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Cards;
using Ahada.Metronic.Models.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Cards;

internal class KeenHtmlCardElement : KeenDisposableHtmlElement<IKeenHtmlCardElement, KeenHtmlCardElement, IKeenHtmlCardBodyElement, KeenHtmlCardBodyElement>, 
    IKeenHtmlCardElement, IKeenHtmlDisposableHtmlElement
{
    public KeenHtmlCardElement(IHtmlHelper html) : base(html)
    {
        Tag = new TagBuilder("div");
    }

    public override TagBuilder Tag { get; }
    
    
    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        throw new NotImplementedException();
    }

    public IKeenHtmlCardElement Body(Func<IKeenHtmlCardBodyInnerElement, IKeenHtmlCardBodyInnerElement> body)
    {
        throw new NotImplementedException();
    }
}