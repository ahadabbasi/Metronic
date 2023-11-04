using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Cards;
using Ahada.Metronic.Models.Elements.Abstracts;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Cards;

internal class KeenHtmlCardBodyInnerElement : KeenHtmlElement<IKeenHtmlCardBodyInnerElement, KeenHtmlCardBodyInnerElement>, IKeenHtmlCardBodyInnerElement
{
    private IKeenPartialRenderer PartialRenderer { get; }
    
    private IHtmlContent Body { get; set; }

    public KeenHtmlCardBodyInnerElement(IKeenPartialRenderer partialRenderer)
    {
        PartialRenderer = partialRenderer;
        Body = new HtmlString(string.Empty);
    }
    
    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        TagBuilder tag = new TagBuilder("div");
        
        MergeClasses("card-body");
        
        tag.MergeAttributes(Attributes);

        tag.InnerHtml.AppendHtml(Body);
        
        tag.WriteTo(writer, encoder);
        
    }
    

    public async Task<IKeenHtmlCardBodyInnerElement> RenderAsBody<TModel>(string partialName, TModel? model)
    {
        return RenderAsBody(
            new HtmlString(
            await PartialRenderer.Render(partialName, model)
            )
        ) ;
    }

    public async Task<IKeenHtmlCardBodyInnerElement> RenderAsBody(Task<IHtmlContent> partial)
    {
        return RenderAsBody(await partial);
    }

    public IKeenHtmlCardBodyInnerElement RenderAsBody(IHtmlContent partial)
    {
        Body = partial;

        return this;
    }
}