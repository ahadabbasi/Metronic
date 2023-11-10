using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Models.Elements.Abstracts.Generics;

internal abstract class KeenHtmlBodyInnerElement<TSelf, TBase> : KeenHtmlElement<TSelf, TBase>, IKeenHtmlBodyInnerElement<TSelf>
    where TSelf : IKeenHtmlBodyInnerElement<TSelf>
    where TBase : KeenHtmlBodyInnerElement<TSelf, TBase>, TSelf 
    
{
    private IKeenPartialRenderer PartialRenderer { get; }
    
    protected IHtmlContent Body { get; set; }

    protected KeenHtmlBodyInnerElement(IKeenPartialRenderer partialRenderer)
    {
        PartialRenderer = partialRenderer;
        Body = new HtmlString(string.Empty);
    }


    public async Task<TSelf> RenderAsBody<TModel>(string partialName, TModel? model) =>
        RenderAsBody(
            new HtmlString(
                await PartialRenderer.Render(partialName, model)
            )
        );

    public async Task<TSelf> RenderAsBody(Task<IHtmlContent> partial) => 
        RenderAsBody(await partial);

    public TSelf RenderAsBody(IHtmlContent partial)
    {
        Body = partial;

        return (TBase)this;
    }
}