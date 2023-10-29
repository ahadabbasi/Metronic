using System.IO;
using System.Text.Encodings.Web;
using Ahada.Metronic.Contracts.Elements.Cards;
using Ahada.Metronic.Models.Elements.Abstracts;

namespace Ahada.Metronic.Models.Elements.Cards;

internal class KeenHtmlCardBodyInnerElement : KeenHtmlElement<IKeenHtmlCardBodyInnerElement, KeenHtmlCardBodyInnerElement>, IKeenHtmlCardBodyInnerElement
{
    
    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        throw new System.NotImplementedException();
    }
    

    public IKeenHtmlCardBodyInnerElement RenderAsBody()
    {
        throw new System.NotImplementedException();
    }
}