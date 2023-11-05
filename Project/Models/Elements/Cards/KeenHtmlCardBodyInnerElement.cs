using System.IO;
using System.Text.Encodings.Web;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Cards;
using Ahada.Metronic.Models.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Cards;

internal class KeenHtmlCardBodyInnerElement : KeenHtmlBodyInnerElement<IKeenHtmlCardBodyInnerElement, KeenHtmlCardBodyInnerElement>, IKeenHtmlCardBodyInnerElement
{
    public KeenHtmlCardBodyInnerElement(IKeenPartialRenderer partialRenderer) : base(partialRenderer)
    {
    }
    
    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        TagBuilder tag = new TagBuilder("div");
        
        MergeClasses("card-body");
        
        tag.MergeAttributes(Attributes);

        tag.InnerHtml.AppendHtml(Body);
        
        tag.WriteTo(writer, encoder);
        
    }
    
}