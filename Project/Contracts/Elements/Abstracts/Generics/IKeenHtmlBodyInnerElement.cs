using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

public interface IKeenHtmlBodyInnerElement<TElement> : IKeenHtmlElement<TElement> 
    where TElement : IKeenHtmlElement<TElement>, IKeenHtmlBodyInnerElement<TElement>
{
    Task<TElement> RenderAsBody<TModel>(string partialName, TModel? model);
    
    Task<TElement> RenderAsBody(Task<IHtmlContent> partial);
    
    TElement RenderAsBody(IHtmlContent partial);
}